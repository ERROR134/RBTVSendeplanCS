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
        Neu,
        Alt
    }

    public class RbtvEvent
    {

        public RbtvEvent(DateTime start, DateTime end, string summary)
        {
            //check for Type of event
            summary = summary.Substring(8);
            if(summary[0] == '[')
            {
                if (summary[1] == 'L')
                    Type = RbtvEventType.Live;
                else if (summary[1] == 'N')
                    Type = RbtvEventType.Neu;
                summary = summary.Substring(3);
            }
            else
                Type = RbtvEventType.Alt;
            //set membervars
            Name = summary;
            Start = start;
            End = end;
        }
        
        //Membervars
        string Name;
        RbtvEventType Type;
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

        public RbtvEventType getType()
        {
            return Type;
        }
        public void setType(RbtvEventType type)
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
