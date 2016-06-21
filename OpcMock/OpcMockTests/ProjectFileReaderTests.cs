using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpcMock;
using System.IO;
using System.Xml.Linq;

namespace OpcMockTests
{
    [TestClass]
    public class ProjectFileReaderTests : OpcMockTestsBase
    {
        private const string PROJECT_NAME = "testName";
        

        [TestInitialize]
        public void TestInitialize()
        {
            projectFilePath = Path.Combine(TestContext.TestDir, PROJECT_NAME + OpcMockConstants.FileExtensionProject);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DeleteProjectFileIfExists();
        }

        [TestMethod]
        public void ConstructorShould_Load_Project_File_Content_Into_Member()
        {
            XElement fileContentAsXml = new XElement("project", new XElement("project_name", PROJECT_NAME));

            File.WriteAllText(projectFilePath, fileContentAsXml.ToString());

            ProjectFileReader pfr = new ProjectFileReader(projectFilePath);

            Assert.AreEqual(fileContentAsXml.ToString(), pfr.ProjectFileContent);
        }

        [TestMethod]
        public void ContructorShouldCreates_OpcMockProject_With_Correct_Name()
        {
            XElement fileContentAsXml = new XElement("project", new XElement("project_name", PROJECT_NAME));

            File.WriteAllText(projectFilePath, fileContentAsXml.ToString());

            ProjectFileReader pfr = new ProjectFileReader(projectFilePath);

            Assert.AreEqual(PROJECT_NAME, pfr.OpcMockProject.Name);
        }

        [TestMethod]
        public void ContructorShould_Load_ProtocolNames_Of_The_Project()
        {
            string protocol1Name = "protocol1";
            string protocol2Name = "protocol2";

            XElement fileContentAsXml = new XElement("project", new XElement("project_name", PROJECT_NAME),
                                                                new XElement("protocol_list", 
                                                                    new XElement("protocol", protocol1Name),
                                                                    new XElement("protocol", protocol2Name)));

            File.WriteAllText(projectFilePath, fileContentAsXml.ToString());

            ProjectFileReader pfr = new ProjectFileReader(projectFilePath);

            Assert.AreEqual(2, pfr.OpcMockProject.Protocols.Count);

            Assert.AreEqual(protocol1Name, pfr.OpcMockProject.Protocols[0].Name);
            Assert.AreEqual(protocol2Name, pfr.OpcMockProject.Protocols[1].Name);
        }
    }
}
