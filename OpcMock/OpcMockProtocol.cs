using System;
using System.Collections.Generic;

namespace OpcMock
{
    public class OpcMockProtocol
    {
        private List<ProtocolLine> lines;

        public OpcMockProtocol()
        {
            lines = new List<ProtocolLine>();
        }

        public List<ProtocolLine> Lines
        {
            get{ return lines; }
        }

        public void Append(ProtocolLine protocolLine)
        {
            lines.Add(protocolLine);
        }
    }
}