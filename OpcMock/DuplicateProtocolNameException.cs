using System;

namespace OpcMock
{
    public class DuplicateProtocolNameException : Exception
    {
        public DuplicateProtocolNameException(string message, string protocolName)
            : base(message)
        {
            ProtocolName = protocolName;
        }

        public string ProtocolName { get; }
    }
}