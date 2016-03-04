using System.Collections.Generic;

namespace OpcMock
{
    public class OpcMockProject
    {
        public string ProjectName { get; internal set; }
        public List<OpcMockProtocol> Protocols { get; internal set; }

        public OpcMockProject(string projectName)
        {
            ProjectName = projectName;
            List<OpcMockProtocol> Protocols = new List<OpcMockProtocol>();
        }
    }
}