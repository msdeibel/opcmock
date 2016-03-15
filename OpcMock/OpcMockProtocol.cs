using System;
using System.Collections.Generic;

namespace OpcMock
{
    public class OpcMockProtocol
    {
        public string Name { get; internal set; }
        private List<ProtocolLine> lines;

        public OpcMockProtocol(string newProtocolName)
        {
            Name = newProtocolName;
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