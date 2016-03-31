using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcMock
{
    public class ProtocolAddedArgs : EventArgs
    {
        public OpcMockProtocol OpcMockProtocol { get; internal set; }

        public ProtocolAddedArgs(OpcMockProtocol opcMockProtocol)
        {
            OpcMockProtocol = opcMockProtocol;
        }
    }
}
