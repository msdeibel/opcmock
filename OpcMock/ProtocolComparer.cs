using System.Collections.Generic;

namespace OpcMock
{
    public class ProtocolComparer : IComparer<OpcMockProtocol>
    {
        public int Compare(OpcMockProtocol x, OpcMockProtocol y)
        {
            return (x.Name.CompareTo(y.Name)) ;
        }
    }
}