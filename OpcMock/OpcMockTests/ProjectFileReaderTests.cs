using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpcMock;
using System.IO;

namespace OpcMockTests
{
    [TestClass]
    public class ProjectFileReaderTests : OpcMockTestsBase
    {
        private string PROJECT_NAME = "testName";

        [TestMethod]
        public void Constructor_Loads_Project_File_Content_Into_Member()
        {
            string projectFileContent = string.Empty;

            projectFilePath = TestContext.TestDir + "\\" + PROJECT_NAME + OpcMockConstants.FileExtensionProject;

            projectFileContent = "<project>" + Environment.NewLine
                                    + "    <project_name>" + PROJECT_NAME + "</project_name>"
                                    + Environment.NewLine
                                    + "</project>";

            File.WriteAllText(projectFilePath, projectFileContent);

            ProjectFileReader pfr = new ProjectFileReader(projectFilePath);

            Assert.AreEqual(projectFileContent, pfr.ProjectFileContent);

            DeleteProjectFileIfExists();
        }

        [TestMethod]
        public void Contructor_Creates_OpcMockProject_With_Correct_Name()
        {
            string projectFileContent = string.Empty;

            projectFilePath = TestContext.TestDir + "\\" + PROJECT_NAME + OpcMockConstants.FileExtensionProject;

            projectFileContent = "<project>" + Environment.NewLine
                                    + "    <project_name>" + PROJECT_NAME + "</project_name>"
                                    + Environment.NewLine
                                    + "</project>";

            File.WriteAllText(projectFilePath, projectFileContent);

            ProjectFileReader pfr = new ProjectFileReader(projectFilePath);

            Assert.AreEqual(PROJECT_NAME, pfr.OpcMockProject.Name);

            DeleteProjectFileIfExists();
        }

        [TestMethod]
        public void Contructor_Loads_Protocols_Of_The_Project()
        {
            Assert.Fail("Test not implemented");
        }
    }
}
