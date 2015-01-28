using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Globalization;

namespace RBTVSendeplanCS.Reader
{
    class PlanReader
    {

        const String Prefix_EventLine = "BEGIN:VEVENT";
        const String SummaryString = "SUMMARY:";

        #region Membervars

        private string m_calendarPath;
        private string m_document;

        #endregion

        #region Getter / Setter

        public string getCalendarPath()
        {
            return m_calendarPath;
        }

        public void setCalendarPath(string path)
        {
            m_calendarPath = path;
        }

        #endregion

        /// <summary>
        /// download Sendeplan as string
        /// </summary>
        /// <returns></returns>
        public bool loadPlan()
        {
            try
            {
                WebClient client = new WebClient();

                //UTF8 for Schröckert
                client.Encoding = System.Text.Encoding.UTF8;

                //Link to the calendar .ics file (XML date format sucks)
                m_document = client.DownloadString(m_calendarPath);//"
            }
            catch (Exception e)//Could not download file. Assuming no internet connection
            {
                return false;
            }

            //File was download without any problems
            return true;
        }

        /// <summary>
        /// read and interpret downloaded plan
        /// </summary>
        /// <returns></returns>
        public List<RbtvEvent> readPlan()
        {
            List<RbtvEvent> events = new List<RbtvEvent>();
            StringReader strReader = new StringReader(m_document);

            //current line in strReader
            string line;
            while((line = strReader.ReadLine()) != null)//Loop through whole doc
            {
                if(line.Equals(Prefix_EventLine))//Every event starts with this line
                {
                    string start = strReader.ReadLine();//start time is next line
                    string end = strReader.ReadLine();//end time is next line again
                    string ls = line.Substring(0,8);
                    while (!ls.Equals(SummaryString) )//Read till the first letters are "SUMMARY:"
                    {
                        line = strReader.ReadLine();
                        ls  = line.Substring(0,8);
                    }

                    string summary = line;
                    DateTime Start = DateTime.ParseExact(start.Substring(8), "yyyyMMddTHHmmssssZ", CultureInfo.InvariantCulture);
                    DateTime End = DateTime.ParseExact(end.Substring(6), "yyyyMMddTHHmmssssZ", CultureInfo.InvariantCulture);
                    if(End >= DateTime.Now)
                        events.Add(new RbtvEvent(Start, End, summary));//Ad new Event 
                }

            }

            return events;
        }
    }
}
