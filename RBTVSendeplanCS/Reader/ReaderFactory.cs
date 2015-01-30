using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTVSendeplanCS.Reader
{
    public enum ReaderType {
        GoogleIcs,
        GoogleApi
    }

    public class ReaderFactory
    {
        public IPlanReader CreateReader(ReaderType readerTypeToCreate)
        {
            IPlanReader planReader = null;
            switch(readerTypeToCreate) {
                case ReaderType.GoogleApi:
                    planReader = new GoogleApiReader();
                    break;
                case ReaderType.GoogleIcs:
                    planReader = new GoogleIcsReader();
                    break;
            }

            return planReader;
        }
    }
}
