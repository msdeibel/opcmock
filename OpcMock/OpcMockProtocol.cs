using System;
using System.Collections.Generic;
using System.Security.Cryptography;

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

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return obj is OpcMockProtocol && this == (OpcMockProtocol)obj;
        }

        public override int GetHashCode()
        {
            return MD5.Create(Name).GetHashCode();
        }

        public static bool operator ==(OpcMockProtocol opcMockProtocol1, OpcMockProtocol opcMockProtocol2)
        {
            return opcMockProtocol1.Name == opcMockProtocol2.Name;
        }

        public static bool operator !=(OpcMockProtocol opcMockProtocol1, OpcMockProtocol opcMockProtocol2)
        {
            return !(opcMockProtocol1 == opcMockProtocol2);
        }
    }
}