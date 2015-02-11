using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTVSendeplanCS
{
    class RbtvEventNotification
    {
        #region Membervars
        private string m_title;
        public string Title
        {
            get { return m_title; }
            set { m_title = Title; }
        }

        private string m_text;
        public string Text
        {
            get { return m_text; }
            set { m_text = Text; }
        }

        private DateTime m_time;
        public DateTime Time
        {
            get { return m_time; }
            set { m_time = Time; }
        }
        #endregion

        public RbtvEventNotification(string title, string text, DateTime time)
        {
            Title = title;
            Text = text;
            Time = time;
        }
    }
}
