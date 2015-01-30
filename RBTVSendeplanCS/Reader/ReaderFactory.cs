using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTVSendeplanCS.Reader
{
    public enum ReaderType
    {
        GoogleApi,
        GoogleIcs
    }

    class ReaderFactory
    {
        public IPlanReader CreateReader(String calendarId, ReaderType readerTypeToCreate) 
        {
            IPlanReader planReader = null;
            switch (readerTypeToCreate)
            {
                case ReaderType.GoogleApi:
                    planReader = new GoogleApiReader(calendarId);
                    break;
                case ReaderType.GoogleIcs:
                    planReader = new GoogleIcsReader(calendarId);
                    break;
            }

            return planReader;
        }

    }
}
