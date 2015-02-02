using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RBTVSendeplanCS.Reader
{
    class GoogleIcsReader : IPlanReader
    {
        const String SummaryString      = "SUMMARY:";
        const String Prefix_EventLine   = "BEGIN:VEVENT";


        #region Members + Props
        
        private WebClient m_webClient;
        private String m_calenderId;


        private String m_calendarUri;
        public String CalendarUri
        {
            set { m_calendarUri = value; }
            get { return m_calendarUri; }
        }

        #endregion


        public GoogleIcsReader(String calendarId)
        {
            m_calenderId    = calendarId;
            m_calendarUri   = "https://www.google.com/calendar/ical/" + m_calenderId + "/public/basic.ics";
        }


        public async Task<bool> Init()
        {
            try
            {
                m_webClient = new WebClient();

                //UTF8 for Schröckert
                m_webClient.Encoding = System.Text.Encoding.UTF8;
            }
            catch (Exception e)//Could not download file. Assuming no internet connection
            {
                return false;
            }

            //File was download without any problems
            return true;
        }


        public List<RbtvEvent> FetchEvents()
        {
            //Link to the calendar .ics file (XML date format sucks)
            String document = m_webClient.DownloadString(CalendarUri);

            List<RbtvEvent> events = new List<RbtvEvent>();
            StringReader strReader = new StringReader(document);

            //current line in strReader
            string line;
            while ((line = strReader.ReadLine()) != null)//Loop through whole doc
            {
                if (line.Equals(Prefix_EventLine))//Every event starts with this line
                {
                    string start = strReader.ReadLine();//start time is next line
                    string end = strReader.ReadLine();//end time is next line again
                    string ls = line.Substring(0, 8);
                    while (!ls.Equals(SummaryString))//Read till the first letters are "SUMMARY:"
                    {
                        line = strReader.ReadLine();
                        ls = line.Substring(0, 8);
                    }
                    
                    string summary = line.Substring(8);
                    DateTime Start = DateTime.ParseExact(Regex.Match(start, "[0-9]{8}T[0-9]{6}").Groups[0].Value, "yyyyMMddTHHmmssss", CultureInfo.InvariantCulture);
                    DateTime End = DateTime.ParseExact(Regex.Match(end, "[0-9]{8}T[0-9]{6}").Groups[0].Value, "yyyyMMddTHHmmssss", CultureInfo.InvariantCulture);
                    if (End >= DateTime.Now)
                        events.Add(new RbtvEvent(Start, End, summary));//Ad new Event 
                }

            }

            return events;
        }
    }
}
