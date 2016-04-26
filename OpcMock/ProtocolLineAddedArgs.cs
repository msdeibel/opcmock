using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcMock
{
    public class ProtocolLineAddedArgs : EventArgs
    {
        public ProtocolLine AddedProtocolLine { get; internal set; }

        public ProtocolLineAddedArgs(ProtocolLine addedProtocolLine)
        {
            AddedProtocolLine = addedProtocolLine;
        }
    }
}
