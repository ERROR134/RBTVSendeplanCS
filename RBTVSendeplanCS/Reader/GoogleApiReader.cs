using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;

namespace RBTVSendeplanCS.Reader
{
    public class GoogleApiReader : IPlanReader
    {

        #region Members + Props

        private String m_calenderId;


        private String m_apiKey = "";
        public String ApiKey
        {
            set { m_apiKey = value; }
            get { return m_apiKey; }
        }


        private CalendarService m_calendarService;
        public CalendarService Service
        {
            set { m_calendarService = value; }
            get { return m_calendarService; }
        }

        #endregion


        public GoogleApiReader(String calendarId)
        {
            m_calenderId = calendarId;
        }


        public GoogleApiReader(String calendarId, String apiKey)
        {
            m_apiKey = apiKey;
            m_calenderId = calendarId;
        }


        public async Task<bool> Init()
        {
            try
            {
                Service = new CalendarService(new BaseClientService.Initializer { ApplicationName = "RBTV Sendeplan", ApiKey = ApiKey }); 
                return true;
            }
            catch
            {
                return false;
            }
        }


        public List<RbtvEvent> FetchEvents()
        {
            List<RbtvEvent> newEvents = new List<RbtvEvent>();
            try
            {

                EventsResource.ListRequest lr = Service.Events.List(m_calenderId);
                lr.SingleEvents = true;
                lr.TimeMin = DateTime.Now;
                lr.TimeMax = DateTime.Now.AddDays(7);
                lr.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

                Events result = lr.Execute();

                for (int i = 0; i < result.Items.Count; i++)
                {
                    newEvents.Add(new RbtvEvent(result.Items[i].Start.DateTime.Value, result.Items[i].End.DateTime.Value, result.Items[i].Summary));
                }
            }
            catch
            {
            }

            return newEvents;
        }
    }
}
