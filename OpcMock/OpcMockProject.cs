using System.Collections.Generic;

namespace OpcMock
{
    public class OpcMockProject
    {
        public string Name { get; internal set; }
        public List<OpcMockProtocol> Protocols { get; internal set; }

        public OpcMockProject(string projectName)
        {
            Name = projectName;
            List<OpcMockProtocol> Protocols = new List<OpcMockProtocol>();
        }
    }
}