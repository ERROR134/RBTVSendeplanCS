using System;
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
        Old
    }

    public class RbtvEvent
    {

        #region Membersvars
        
        private string m_name;
        private RbtvEventType m_rbtvEventType;
        private DateTime m_startDateTime;
        private DateTime m_endDateTime;

        #endregion

        #region Getter / Setter

        public string getName()
        {
            return m_name;
        }

        public void setName(string name)
        {
            m_name = name;
        }

        public RbtvEventType getType()
        {
            return m_rbtvEventType;
        }

        public void setType(RbtvEventType type)
        {
            m_rbtvEventType = type;
        }

        public DateTime getStart()
        {
            return m_startDateTime;
        }

        public void setStart(DateTime dat)
        {
            m_startDateTime = dat;
        }

        public DateTime getEnd()
        {
            return m_endDateTime;
        }

        public void setEnd(DateTime dat)
        {
            m_endDateTime = dat;
        }

        #endregion

        public RbtvEvent(DateTime start, DateTime end, string summary)
        {
            //check for Type of event
            summary = summary.Substring(8);
            if(summary[0] == '[')
            {
                if (summary[1] == 'L')
                    m_rbtvEventType = RbtvEventType.Live;
                else if (summary[1] == 'N')
                    m_rbtvEventType = RbtvEventType.New;
                summary = summary.Substring(3);
            }
            else
                m_rbtvEventType = RbtvEventType.Old;
            
            m_name = summary;
            m_startDateTime = start;
            m_endDateTime = end;
        }
    }
}
