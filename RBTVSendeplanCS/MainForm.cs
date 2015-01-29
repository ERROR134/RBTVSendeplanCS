using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBTVSendeplanCS.Reader;
using System.Threading;


namespace RBTVSendeplanCS
{

    public delegate void OnEventsLoaded(object sender, EventArgs e);

    public partial class MainForm : Form
    {

        #region Membervars

        private List<RbtvEvent> m_events;
        private ToolTip m_toolTip;
        private String m_calendarPath = "https://www.google.com/calendar/ical/h6tfehdpu3jrbcrn9sdju9ohj8%40group.calendar.google.com/public/basic.ics";
        private event OnEventsLoaded Event_OnEventsLoaded;

        #endregion

        public MainForm()
        {
            InitializeComponent();
            Event_OnEventsLoaded += new OnEventsLoaded(RenderEvents);
        }

        /// <summary>
        /// Sort all events with bubblesort. The events are in some weird order in the ics file
        /// </summary>
        /// <param name="events"></param>
        public void SortEvents(List<RbtvEvent> events)
        {
            int n = events.Count;
            do
            {
                int newn = 1;
                for (int i = 0; i < n - 1; i++)
                {
                    if (events[i].Start > events[i + 1].Start)
                    {
                        RbtvEvent e = events[i + 1];
                        events[i + 1] = events[i];
                        events[i] = e;
                        newn = i + 1;
                    }
                }
                n = newn;
            } while (n > 1);
        }



        /// <summary>
        /// 
        /// </summary>
        private void RenderEvents(object sender, EventArgs e) {

            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker) delegate
                {
                    RenderEvents(sender, e);
                });

                return;
            }


            eventListPanel.Controls.Clear();

            // put all the events in the panels
            for (int i = 0; i < m_events.Count - 1; i++)
            {
                Panel p = new Panel();
                p.Size = new Size(eventListPanel.Size.Width, 50);
                p.Location = new Point(0, i * 50);

                switch(m_events[i].EventType)
                {
                    case RbtvEventType.Old:
                        p.Controls.Add(new PictureBox() { Image = RBTVSendeplanCS.Properties.Resources.rerun, SizeMode = PictureBoxSizeMode.Zoom, Location = new Point(0, 0), Size = new Size(30, 30) });
                        break;
                    case RbtvEventType.Live:
                        p.Controls.Add(new PictureBox() { Image = RBTVSendeplanCS.Properties.Resources.live, SizeMode = PictureBoxSizeMode.Zoom, Location = new Point(0, 0), Size = new Size(30, 30) });
                        break;
                    case RbtvEventType.New:
                        p.Controls.Add(new PictureBox() { Image = RBTVSendeplanCS.Properties.Resources._new, SizeMode = PictureBoxSizeMode.Zoom, Location = new Point(0, 0), Size = new Size(30, 30) });
                        break;
                }

                p.Controls.Add(new Label() { Text = m_events[i].Name, Font = new Font(Font.Name, 10, FontStyle.Bold), Location = new Point(30, 10), Size = new Size(p.Size.Width-5, 20) });
                p.Controls.Add(new Label() { Text = m_events[i].Start.ToString("dd.MM.yyyy HH:mm"), Location = new Point(40, 30) });

                eventListPanel.Controls.Add(p);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void LoadEvents()
        {
            m_events = new List<RbtvEvent>();
            PlanReader reader = new PlanReader();
            reader.CalendarPath = m_calendarPath;
            if(reader.loadPlan())
                m_events = reader.readPlan();
            else
                MessageBox.Show("Can't read file");


            SortEvents(m_events);

            if (Event_OnEventsLoaded != null)
            {
                Event_OnEventsLoaded.Invoke(this, null);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
            new Thread(new ThreadStart(LoadEvents)).Start();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                NotifyIcon.Visible = true;
                NotifyIcon.BalloonTipTitle = "RBTVSendeplan";
                NotifyIcon.BalloonTipText = "Minimized to tray";
                NotifyIcon.ShowBalloonTip(500);
                this.Hide();
            }
        }


        /// <summary>
        ///         
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIcon_Click(object sender, System.EventArgs e)
        {
            //If form already minimized: show it above the mouse
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Location = new Point(System.Windows.Forms.Control.MousePosition.X - this.Width / 2, System.Windows.Forms.Control.MousePosition.Y - this.Height);
            }
                //if form is normal visible hide it
            else if(this.WindowState == FormWindowState.Normal)
            {
                this.Hide();
                this.WindowState = FormWindowState.Minimized;
            }
        }


        /// <summary>
        /// Update Sendeplan every interval
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            LoadEvents();
        }
    }
}