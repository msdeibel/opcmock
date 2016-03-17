using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpcMock;

namespace OpcMockTests
{
    [TestClass]
    public class OpcMockProjectTests
    {
        private const int NEW_PROJECT_PROTOCOL_COUNT = 0;
        private const string PROTOCOL_NAME = "protocolName";

        private string projectName;
        private OpcMockProject opcMockProject;

        [TestInitialize]
        public void TestInitialize()
        {
            projectName = "projectName";
            opcMockProject = new OpcMockProject(projectName);
        }

        [TestMethod]
        public void New_Project_Has_A_Name_Set()
        {
            Assert.AreEqual(projectName, opcMockProject.Name);
        }

        [TestMethod]
        public void New_Project_Has_An_Empty_List_Of_Protocols()
        {
            Assert.AreEqual(NEW_PROJECT_PROTOCOL_COUNT, opcMockProject.Protocols.Count);
        }

        [TestMethod]
        public void Protocols_Can_Be_Added_To_The_Project()
        {
            OpcMockProtocol protocolToAdd = new OpcMockProtocol(PROTOCOL_NAME);

            opcMockProject.AddProtocol(protocolToAdd);

            Assert.AreEqual(protocolToAdd, opcMockProject.Protocols[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateProtocolNameException))]
        public void Adding_Duplicate_Protocol_Name_Throws_Exception()
        {
            OpcMockProtocol protocolToAdd = new OpcMockProtocol(PROTOCOL_NAME);

            opcMockProject.AddProtocol(protocolToAdd);
            opcMockProject.AddProtocol(protocolToAdd);
        }
    }
}
