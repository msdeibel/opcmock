using System;
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
            Protocols = new List<OpcMockProtocol>();
        }

        /// <summary>
        /// Add a protocol to the project
        /// </summary>
        /// <param name="protocolToAdd"></param>
        /// <exception cref="OpcMock.DuplicateProtocolNameException">In case the project already contains a protocol with this name</exception>
        public void AddProtocol(OpcMockProtocol protocolToAdd)
        {
            if (Protocols.Contains(protocolToAdd))
            {
                throw new DuplicateProtocolNameException("Project already contains a protocol with this name.", protocolToAdd.Name);
            }

            Protocols.Add(protocolToAdd);
        }
    }
}