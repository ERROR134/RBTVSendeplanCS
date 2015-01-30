using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTVSendeplanCS.Reader
{
    class GoogleIcsReader : IPlanReader
    {

        public GoogleIcsReader()
        {

        }

        public async Task<bool> Init()
        {
            throw new NotImplementedException();
        }

        public List<RbtvEvent> FetchEvents()
        {
            throw new NotImplementedException();
        }
    }
}
