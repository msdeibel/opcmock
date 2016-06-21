using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace OpcMock
{
    [Serializable]
    public class DuplicateProtocolNameException : Exception
    {
        public DuplicateProtocolNameException(string message, string protocolName)
            : base(message)
        {
            ProtocolName = protocolName;
        }

        public string ProtocolName { get; }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("ProtocolName", ProtocolName);
        }
    }
}