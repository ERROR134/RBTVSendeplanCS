﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTVSendeplanCS
{
    public enum RbtvEventType
    {
        Live,
        New,
        Replay
    }

    public class RbtvEvent
    {

        #region Membersvars + Props
        
        private string m_name;
        public string Name
        {
            set { m_name = value; }
            get { return m_name; }
        }

        private RbtvEventType m_rbtvEventType;
        public RbtvEventType EventType
        {
            set { m_rbtvEventType = value; }
            get { return m_rbtvEventType; }
        }

        private DateTime m_startDateTime;
        public DateTime Start
        {
            set { m_startDateTime = value; }
            get { return m_startDateTime; }
        }

        private DateTime m_endDateTime;
        public DateTime End
        {
            set { m_endDateTime = value; }
            get { return m_endDateTime; }
        }

        private DateTime m_lastTrayIconNotifyDateTime;
        public DateTime LastTrayIconNotify
        {
            set { m_lastTrayIconNotifyDateTime = value; }
            get { return m_lastTrayIconNotifyDateTime; }
        }


        private bool m_wasPushedToTrayIcon = false;
        public bool WasPushedToTrayIcon
        {
            set { m_wasPushedToTrayIcon = value; }
            get { return m_wasPushedToTrayIcon; }
        }

        #endregion


        public RbtvEvent(DateTime start, DateTime end, string summary)
        {
            //check for Type of event
            if(summary[0] == '[')
            {
                if (summary[1] == 'L')
                    m_rbtvEventType = RbtvEventType.Live;
                else if (summary[1] == 'N')
                    m_rbtvEventType = RbtvEventType.New;
                summary = summary.Substring(3);
            }
            else
                m_rbtvEventType = RbtvEventType.Replay;
            
            m_name = summary;
            m_startDateTime = start;
            m_endDateTime = end;
        }
    }
}
