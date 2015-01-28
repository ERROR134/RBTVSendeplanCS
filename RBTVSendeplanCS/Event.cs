using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTVSendeplanCS
{
    public enum EventType
    {
        Live,
        Neu,
        Alt
    }
    public class Event
    {

        public Event(DateTime start, DateTime end, string summary)
        {
            //check for Type of event
           /* summary = summary.Substring(8)
            //set membervars
            */
            if(summary[0] == '[')
            {
                if (summary[1] == 'L')
                    Type = EventType.Live;
                else if (summary[1] == 'N')
                    Type = EventType.Neu;
                summary = summary.Substring(3);
            }
            else
                Type = EventType.Alt;
            Name = summary;
            Start = start;
            End = end;
            
        }
        
        //Membervars
        string Name;
        EventType Type;
        DateTime Start;
        DateTime End;


        //Getter/Setter
        public string getName()
        {
            return Name;
        }
        public void setName(string name)
        {
            Name = name;
        }

        public EventType getType()
        {
            return Type;
        }
        public void setType(EventType type)
        {
            Type = type;
        }

        public DateTime getStart()
        {
            return Start;
        }
        public void setStart(DateTime dat)
        {
            Start = dat;
        }

        public DateTime getEnd()
        {
            return End;
        }
        public void setEnd(DateTime dat)
        {
            End = dat;
        }
    }
}
