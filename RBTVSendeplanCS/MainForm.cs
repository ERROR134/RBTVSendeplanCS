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

    public delegate void OnEventsLoadedHandler(object sender, EventArgs e);

    public partial class MainForm : Form
    {

        #region Membervars

        private List<RbtvEvent> m_events;
        private ToolTip m_toolTip;

		
		private bool MinimizedWithIcon;
		private IPlanReader m_planReader;
        private event OnEventsLoadedHandler Event_OnEventsLoaded;

        #endregion
        

        public MainForm()
        {
            InitializeComponent();
            Event_OnEventsLoaded += new OnEventsLoadedHandler(AddEventsToPanel);
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

       

		private void LoadEvents()
		{
			m_events = m_planReader.FetchEvents();

			if (Event_OnEventsLoaded != null)
			{
				Event_OnEventsLoaded.Invoke(this, null);
			}
		}


		private void MainForm_Load(object sender, EventArgs e)
        {
            m_planReader = new ReaderFactory().CreateReader(ReaderType.GoogleApi);
            bool r = m_planReader.Init().Result;
            Init();
     
			new Thread(new ThreadStart(LoadEvents)).Start();
            
        }


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                NotifyIcon.Visible = true;
                if (MinimizedWithIcon == false)
                {
                    NotifyIcon.BalloonTipTitle = "RBTVSendeplan";
                    NotifyIcon.BalloonTipText = "Minimized to tray";
                    NotifyIcon.ShowBalloonTip(500);
                }
                this.Hide();
                MinimizedWithIcon = false;
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
            else if (this.WindowState == FormWindowState.Normal)
            {
                MinimizedWithIcon = true;
                this.Hide();
                this.WindowState = FormWindowState.Minimized;
            }
        }


		private void AddEventsToPanel(object sender, EventArgs e)
		{
			if (InvokeRequired)
			{
				BeginInvoke(
					(MethodInvoker) delegate 
					{
						AddEventsToPanel(sender, e);
					});

				return;
			}

			AddEventsToPanel();
		}


        public void AddEventsToPanel()
        {
            //Clear panel first
			eventListPanel.Controls.Clear();

			// There are now events
			if (m_events.Count < 1)
			{
				Label loadingLabel = new Label() { Text = "No events found!", Font = new Font(Font.Name, 10, FontStyle.Regular), Location = new Point(5, 10), Size = new Size(eventListPanel.Size.Width, 20) };
				eventListPanel.Controls.Add(loadingLabel);
				return;
			}

            //put all the events in the panels
            for (int i = 0; i < m_events.Count; i++)
            {
                Panel p = new Panel();
				p.Size = new Size(eventListPanel.Size.Width, 50);
                p.Location = new Point(0, i * 50);

                PictureBox typePic = new PictureBox(){ SizeMode = PictureBoxSizeMode.Zoom, Location = new Point(0, 0), Size = new Size(30, 30) };
                switch (m_events[i].EventType)
                {
                    case RbtvEventType.Old:
                        typePic.Image = RBTVSendeplanCS.Properties.Resources.rerun;
                        break;
                    case RbtvEventType.Live:
                        typePic.Image = RBTVSendeplanCS.Properties.Resources.live;
                        break;
                    case RbtvEventType.New:
                        typePic.Image = RBTVSendeplanCS.Properties.Resources._new;
                        break;
                }
                typePic.MouseEnter += new EventHandler(this.ParentMouseEnter);
                typePic.MouseLeave += new EventHandler(this.ParentMouseLeave);
                p.Controls.Add(typePic);
                
				Label nameLabel = new Label() { Text = m_events[i].Name, Font = new Font(Font.Name, 10, FontStyle.Bold), Location = new Point(30, 10), Size = new Size(p.Size.Width, 20) };
                nameLabel.MouseEnter += new EventHandler(this.ParentMouseEnter);
                nameLabel.MouseLeave += new EventHandler(this.ParentMouseLeave);
                p.Controls.Add(nameLabel);
                
				Label timeLabel = new Label() { Text = m_events[i].Start.ToString("dd.MM.yyyy HH:mm"), Location = new Point(40, 30) };
                timeLabel.MouseEnter += new EventHandler(this.ParentMouseEnter);
                timeLabel.MouseLeave += new EventHandler(this.ParentMouseLeave);
                p.Controls.Add(timeLabel);
                
				p.MouseEnter += new EventHandler(this.PanelMouseEnter);
                p.MouseLeave += new EventHandler(this.PanelMouseLeave);

				eventListPanel.Controls.Add(p);
            }
        }


        private void ParentMouseEnter(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            PanelMouseEnter(c.Parent, EventArgs.Empty);
        }


        private void ParentMouseLeave(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            PanelMouseLeave(c.Parent, EventArgs.Empty);
        }


        private void PanelMouseEnter(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            p.BackColor = Color.CornflowerBlue;
        }


        private void PanelMouseLeave(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
			p.BackColor = eventListPanel.BackColor;
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