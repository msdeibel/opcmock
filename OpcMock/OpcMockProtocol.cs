using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace OpcMock
{
    public class OpcMockProtocol
    {
        public string Name { get; internal set; }
        private List<ProtocolLine> lines;

        public delegate void ProtocolLineAddedHandler(ProtocolLineAddedArgs plaArgs);

        public event ProtocolLineAddedHandler OnProtocolLineAdded;

        public OpcMockProtocol(string newProtocolName)
        {
            if (string.IsNullOrWhiteSpace(newProtocolName))
            {
                throw new ArgumentException("Parameter must not be an empty string or whitspace-only.", nameof(newProtocolName));
            }

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

            if (null != OnProtocolLineAdded)
            {
                OnProtocolLineAdded(new ProtocolLineAddedArgs(protocolLine));
            }
        }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            /// PROPOSAL check if the == operator should be replaced by call to Equals
            /// ==> MSDN
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

        public override string ToString()
        {
            return Name;
        }

        public void Append(string[] semicolonSeparatedLines)
        {
            foreach (string line in semicolonSeparatedLines)
            {
                Append(new ProtocolLine(line));
            }
        }
    }
}