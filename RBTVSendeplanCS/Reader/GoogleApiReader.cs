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
	class GoogleApiReader 
	{
		private String m_apiKey;

		private CalendarService m_calendarService;
		public CalendarService Service 
		{
			set { m_calendarService = value; }
			get { return m_calendarService; }
		}



		public GoogleApiReader(String apiKey) 
		{
			m_apiKey = apiKey;
		}


		public async Task<bool> Init()
		{
			try
			{
				Service = new CalendarService(new BaseClientService.Initializer { ApplicationName = "RBTV Sendeplan", ApiKey = "PUT OWN KEY HERE" }); //Sorry, I can't leave my key here....
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

				EventsResource.ListRequest lr = Service.Events.List("h6tfehdpu3jrbcrn9sdju9ohj8@group.calendar.google.com");
				lr.TimeMin = DateTime.Now;
				lr.TimeMax = DateTime.Now.AddDays(7);
				lr.SingleEvents = true;
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
