using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpcMock;

namespace OpcMockTests
{
    [TestClass]
    public class OpcMockProjectTests
    {
        private const int NEW_PROJECT_PROTOCOL_COUNT = 0;
        private const string PROTOCOL_NAME = "protocolName";
        private const string PROJECT_NAME = "projectName";

        private OpcMockProject opcMockProject;

        [TestInitialize]
        public void TestInitialize()
        {
            opcMockProject = new OpcMockProject(PROJECT_NAME);
        }

        [TestMethod]
        public void NewOpcMockProjectShould_Have_The_Name_Field_Set()
        {
            Assert.AreEqual(PROJECT_NAME, opcMockProject.Name);
        }

        [TestMethod]
        public void NewOpcMockProjectShould_Have_An_Empty_List_Of_Protocols()
        {
            Assert.AreEqual(NEW_PROJECT_PROTOCOL_COUNT, opcMockProject.Protocols.Count);
        }

        [TestMethod]
        public void AddProtocolShould_Add_A_Protocol_To_The_End_Of_The_List()
        {
            OpcMockProtocol protocolToAdd = new OpcMockProtocol(PROTOCOL_NAME);

            opcMockProject.AddProtocol(protocolToAdd);

            Assert.AreEqual(protocolToAdd, opcMockProject.Protocols[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateProtocolNameException))]
        public void AddProtocolShould_Raise_DuplicateProtocolNameException_On_Duplicate_ProtocolName()
        {
            OpcMockProtocol protocolToAdd = new OpcMockProtocol(PROTOCOL_NAME);

            opcMockProject.AddProtocol(protocolToAdd);
            opcMockProject.AddProtocol(protocolToAdd);
        }

        [TestMethod]
        public void AddProtocolShould_Not_Raise_OnProtocolAdded_Event_For_Duplicates()
        {
            bool eventRaised = false;

            try
            {
                OpcMockProtocol protocolToAdd = new OpcMockProtocol(PROTOCOL_NAME);

                opcMockProject.AddProtocol(protocolToAdd);

                //Add the handler only after the first addition otherwise eventRaised
                //is wrongly set to true
                opcMockProject.OnProtocolAdded += delegate (object sender, ProtocolAddedArgs paArgs) { eventRaised = true; };

                opcMockProject.AddProtocol(protocolToAdd);
            }
            catch (DuplicateProtocolNameException)
            {
                Assert.IsFalse(eventRaised);
            }
        }
    }
}
