using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RBTVSendeplanCS
{
    public partial class Form1 : Form
    {
        //Membervars
        List<Event> Events;
        ToolTip toolTip;

        public Form1()
        {
            InitializeComponent();
        }

        //Sort all events with bubblesort. The events are in some weird order in the ics file
        public void SortEvents(List<Event> events)
        {
            int n = events.Count;
            do
            {
                int newn = 1;
                for (int i = 0; i < n - 1; i++)
                {
                    if (events[i].getStart() > events[i + 1].getStart())
                    {
                        Event e = events[i + 1];
                        events[i + 1] = events[i];
                        events[i] = e;
                        newn = i + 1;
                    }
                }
                n = newn;
            } while (n > 1);
        }

        private bool LoadEvents()
        {
            Events = new List<Event>();
            PlanReader reader = new PlanReader();
            reader.setPath("https://www.google.com/calendar/ical/h6tfehdpu3jrbcrn9sdju9ohj8%40group.calendar.google.com/public/basic.ics");
            if(reader.loadPlan())
                Events = reader.readPlan();
            else
                MessageBox.Show("Can't read file");


            SortEvents(Events);

            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
            LoadEvents();

            //put all the events in the panels
            for (int i = 0; i < Events.Count - 1; i++)
            {
                Panel p = new Panel();
                p.Size = new Size(panel.Size.Width, 50);
                p.Location = new Point(0, i * 50);

                switch(Events[i].getType())
                {
                    case EventType.Alt:
                        p.Controls.Add(new PictureBox() { Image = RBTVSendeplanCS.Properties.Resources.rerun, SizeMode = PictureBoxSizeMode.Zoom,  Location = new Point(0, 0), Size = new Size(30,30)});
                        break;
                    case EventType.Live:
                        p.Controls.Add(new PictureBox() { Image = RBTVSendeplanCS.Properties.Resources.live, SizeMode = PictureBoxSizeMode.Zoom, Location = new Point(0, 0), Size = new Size(30, 30) });
                        break;
                    case EventType.Neu:
                        p.Controls.Add(new PictureBox() { Image = RBTVSendeplanCS.Properties.Resources._new, SizeMode = PictureBoxSizeMode.Zoom, Location = new Point(0, 0), Size = new Size(30, 30) });
                        break;
                }
                p.Controls.Add(new Label() { Text = Events[i].getName(), Font = new Font(Font.Name, 10, FontStyle.Bold), Location = new Point(30,10), Size = new Size(p.Size.Width,20)});
                p.Controls.Add(new Label() { Text = Events[i].getStart().ToString("dd.MM.yyyy HH:mm") , Location = new Point(40, 30) });

                panel.Controls.Add(p);
            }
        }

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

        


        //Update Sendeplan every interval
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            LoadEvents();
        }
    }
}