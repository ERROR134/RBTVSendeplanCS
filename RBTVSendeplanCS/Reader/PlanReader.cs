using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Globalization;

using System.Threading;
namespace RBTVSendeplanCS.Reader
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;



{
    class PlanReader
    {
        CalendarService Service;

        const String Prefix_EventLine = "BEGIN:VEVENT";
        const String SummaryString = "SUMMARY:";

        #region Membervars + Props

        private string m_document;
        
        private string m_calendarPath;
        public string CalendarPath 
        {
            set { m_calendarPath = value; }
            get { return m_calendarPath; }
        }

        public async Task<bool> Init()
        {
            try
            {
                //ClientSecrets cSecrets = new ClientSecrets() { ClientId = "1013054955529-ikp1u9umu52svmkn339sb0m0efrgll9r", ClientSecret = "Ui6YTLTybk3_jQNKEXJhCAvl " };
                //await GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = "1013054955529-go719ac80h62s47r9u27cdmgtskbh3ji.apps.googleusercontent.com", ClientSecret = "hTxJoX-KgI2QEk2_E0aYSw1C" }, new[] { CalendarService.Scope.CalendarReadonly }, "user", CancellationToken.None);//, new FileDataStore("RBTV")).Result;
                Service = new CalendarService(new BaseClientService.Initializer { ApplicationName = "RBTV Sendeplan", ApiKey = "AIzaSyDU4GUSAxWwBcltZaPToJyxWlg7n_SDHEw" });

                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool loadPlan()
        {
            try
            {
                //WebClient client = new WebClient();

                //UTF8 for Schröckert
                //client.Encoding = System.Text.Encoding.UTF8;

                //Link to the calendar .ics file (XML date format sucks)
                //Doc = client.DownloadString(Path);//"
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

        }

        public List<Event> FetchEvents()
        {
            List<Event> newEvents = new List<Event>();
            try
            {

                EventsResource.ListRequest lr = Service.Events.List("h6tfehdpu3jrbcrn9sdju9ohj8@group.calendar.google.com");
                //EventsResource.ListRequest lr = Service.Events.List("error134@googlemail.com");
                lr.TimeMin = DateTime.Now;
                lr.TimeMax = DateTime.Now.AddDays(7);
                lr.SingleEvents = true;

                Events result = lr.Execute();

                for(int i = 0; i < result.Items.Count; i++)
                {
                    newEvents.Add(new Event(result.Items[i].Start.DateTime.Value, result.Items[i].End.DateTime.Value, result.Items[i].Summary));
                }
                int debug_success;
            }
            catch
            {
                int debug_fail;
            }
            return newEvents;
        }
    }
}
