using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RBTVSendeplanCS
{
    class Notificator
    {
        private NotifyIcon m_notifyIcon;
        private List<RbtvEventNotification> Notifications;

        public Notificator(NotifyIcon icon)
        {
            m_notifyIcon = icon;
            Notifications = new List<RbtvEventNotification>();
        }

        public void AddNotifications(List<RbtvEvent> events)
        {
            foreach(RbtvEvent evt in events)
            {
                Notifications.Add(new RbtvEventNotification(evt.Name,"Startet in 5 Minuten!",evt.Start.AddMinutes(-5)));
            }
        }
        public void ShowMbNotification()
        {
            MessageBox.Show("Message Text", "Header", MessageBoxButtons.OK, MessageBoxIcon.None, 
                MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);  // MB_TOPMOST
        }
    }
}
