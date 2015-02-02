using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTVSendeplanCS
{
    public class OnErrorEventArgs : EventArgs
    {
        private Exception m_exception;
        public Exception Error
        {
            set {}
            get { return m_exception; }
        }

        public OnErrorEventArgs(Exception ex)
        {
            m_exception = ex;
        }
    }
}
