using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBTVSendeplanCS.Reader;
using System.Threading;
using System.Text.RegularExpressions;


namespace RBTVSendeplanCS
{

    public delegate void OnEventsLoadedHandler(object sender, EventArgs e);
    public delegate void OnErrorHandler (object sender, OnErrorEventArgs e);

    public partial class MainForm : Form
    {
        //IF THE API KEY IS NOT INSERTED HERE THERE WILL BE ERRORS IN THE SENDEPLAN!
        #region Membervars

        private System.Threading.Timer m_checkDateTimeForNotify;

        // FIXME: to be removed from here loading from config?
        private String m_calendarId = "h6tfehdpu3jrbcrn9sdju9ohj8@group.calendar.google.com";

        // FIXME: to be removed from here loading from config?
        // Sorry, I can't leave my key here....
        private String m_apiKey = "";  // PUT OWN KEY HERE

        private List<RbtvEvent> m_events;
        public List<RbtvEvent> Events
        {
            get { return m_events; }
        }
        private ToolTip m_toolTip;
		
		private bool MinimizedWithIcon;
		private IPlanReader m_planReader;

        private event OnErrorHandler Event_OnError;
        private event OnEventsLoadedHandler Event_OnEventsLoaded;

        private Notificator notificator;

        //Both forms
        BigPlanForm bigForm;
        PlanForm activeForm;
        #endregion

        public MainForm()
        {
            Updater updater = new Updater();
            string link = updater.CheckForNewestVersion(RBTVSendeplanCS.Properties.Settings.Default.Version);
            if(link != null)
            {
                MyMessageBox.ShowDialog("New Version", "New Version available",link);
            }

            if(CheckForSettingsFile() == true)
            {
                LoadSettings();
            }
            else
            {
                SaveSettings();
            }

            InitializeComponent();
            Event_OnEventsLoaded += new OnEventsLoadedHandler(AddEventsToPanel);
            Event_OnError += new OnErrorHandler(DisplayErrorPopup);
            this.Show();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Fallback to ICS if there's no apiKey
                ReaderType readerTypeToCreate = (!String.IsNullOrEmpty(m_apiKey)) ? ReaderType.GoogleApi : ReaderType.GoogleIcs;

                // Get reader and init
                m_planReader = new ReaderFactory().CreateReader(m_calendarId, readerTypeToCreate);
                if (m_planReader is GoogleApiReader)
                {
                    ((GoogleApiReader)m_planReader).ApiKey = m_apiKey;
                }

                bool r = m_planReader.Init().Result;
                Init();

                // load event async (not waiting time for gui)
                new Thread(new ThreadStart(LoadEvents)).Start();

                m_checkDateTimeForNotify = new System.Threading.Timer(CheckDateTimeForNotify, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            }
            catch (Exception ex)
            {
                if (Event_OnError != null)
                {
                    Event_OnError.Invoke(this, new OnErrorEventArgs(ex));
                }
            }
            bigForm = new BigPlanForm(this);
            this.Hide();
            activeForm = bigForm;
            bigForm.ShowDialog();
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
                    if (events[i].Start.CompareTo(events[i + 1].Start) > 0)
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
            try
            {
                m_events = m_planReader.FetchEvents();
                SortEvents(m_events);
                if (Event_OnEventsLoaded != null)
		        {
                    Event_OnEventsLoaded.Invoke(this, null);
	            }
            }
            catch (Exception ex)
            {
                if (Event_OnError != null)
			    {
				    Event_OnError.Invoke(this, new OnErrorEventArgs(ex));
		        }
            }
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        private void CheckDateTimeForNotify(object sender)
        {
					if (m_events != null)
					{
						try
						{
							foreach (RbtvEvent currentEvent in m_events)
							{
								// just events which where never pushed to tooltip/tray icon
								if (!currentEvent.WasPushedToTrayIcon)
								{
									// 5 minutes before the show, trigger notify
									if (DateTime.Now >= currentEvent.Start.AddMinutes(0) && DateTime.Now <= currentEvent.Start)
									{
										if (this.WindowState == FormWindowState.Minimized)
										{
											// notifyicon should be already there (see MainForm_Resize)
											NotifyIcon.BalloonTipTitle = "[RBTV] Sendeplan";
											NotifyIcon.BalloonTipText = currentEvent.Name.Trim() + " | " + currentEvent.Start.ToString("HH:mm") + " - " + currentEvent.End.ToString("HH:mm") + " | " + currentEvent.EventType.ToString().ToUpper();
											NotifyIcon.ShowBalloonTip(1500);

											currentEvent.WasPushedToTrayIcon = true;
											currentEvent.LastTrayIconNotify = DateTime.Now;
										}
									}
								}
							}
						}
						catch (Exception ex)
						{
							if (Event_OnError != null)
							{
								Event_OnError.Invoke(this, new OnErrorEventArgs(ex));
							}
						}
					}


          bool r = m_planReader.Init().Result;
          Init();
     
          // load event async (not waiting time for gui)
					new Thread(new ThreadStart(LoadEvents)).Start();

          //notificator.ShowMbNotification();
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
                    string notifyTitle  = "[RBTV] Sendeplan";
                    string notifyText   = "Minimized to tray";
                    if (m_events.Count > 0)
                    {
                        // notifyTitle = "[RBTV] " + m_events[0].Name.Trim();
                        notifyText = m_events[0].Name.Trim() + " | " + m_events[0].Start.ToString("HH:mm") + " - " + m_events[0].End.ToString("HH:mm") + " | " + m_events[0].EventType.ToString().ToUpper();
                    }

                    NotifyIcon.BalloonTipTitle  = notifyTitle;
                    NotifyIcon.BalloonTipText   = notifyText;
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
            activeForm.RbtvEventsLoaded(m_events);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void DisplayErrorPopup(object sender, OnErrorEventArgs eventArgs)
        {
            if (InvokeRequired)
            {
                BeginInvoke(
                    (MethodInvoker) delegate {
                        DisplayErrorPopup(sender, eventArgs);
                    });
            }

            MessageBox.Show(eventArgs.Error.Message, "Es ist ein Fehler aufgetreten!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public MenuStrip GetMenuStrip()
        {
            return this.menuStrip1;
        }
    }
}