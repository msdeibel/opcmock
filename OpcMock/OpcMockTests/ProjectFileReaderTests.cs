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
        private XElement fileContetAsXml = new XElement("project", new XElement("project_name", PROJECT_NAME));

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
            File.WriteAllText(projectFilePath, fileContetAsXml.ToString());

            ProjectFileReader pfr = new ProjectFileReader(projectFilePath);

            Assert.AreEqual(fileContetAsXml.ToString(), pfr.ProjectFileContent);
        }

        [TestMethod]
        public void ContructorShouldCreates_OpcMockProject_With_Correct_Name()
        {
            File.WriteAllText(projectFilePath, fileContetAsXml.ToString());

            ProjectFileReader pfr = new ProjectFileReader(projectFilePath);

            Assert.AreEqual(PROJECT_NAME, pfr.OpcMockProject.Name);
        }

        [TestMethod]
        public void Contructor_Loads_Protocols_Of_The_Project()
        {
            Assert.Fail("Test not implemented");
        }
    }
}
