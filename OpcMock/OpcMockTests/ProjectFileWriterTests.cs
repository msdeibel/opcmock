using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpcMock.Tests;
using System.IO;
using OpcMock;
using System.Xml.Linq;

namespace OpcMockTests
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für ProjectFileWriterTests
    /// </summary>
    [TestClass]
    public class ProjectFileWriterTests : OpcMockTestsBase
    {
        private string PROJECT_NAME = "testName";

        private ProjectFileWriter projectFileWriter;

        public ProjectFileWriterTests()
        {
            //void
        }

        [TestInitialize]
        public void TestInitialize()
        {
            DeleteProjectFileIfExists();

            projectFilePath = TestContext.TestDir + Path.DirectorySeparatorChar + PROJECT_NAME + OpcMockConstants.FileExtensionProject;

            projectFileWriter = new ProjectFileWriter(new OpcMockProject(PROJECT_NAME), TestContext.TestDir);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DeleteProjectFileIfExists();
        }

        [TestMethod]
        public void SaveShould_Create_File_In_Project_Path()
        {
            projectFileWriter.Save();

            Assert.IsTrue(File.Exists(projectFilePath));
        }

        [TestMethod]
        public void SaveShould_Use_Correct_FileName_And_Extension()
        {
            projectFileWriter.Save();

            Assert.AreEqual(PROJECT_NAME, Path.GetFileNameWithoutExtension(projectFileWriter.FilePath));
            Assert.AreEqual(OpcMockConstants.FileExtensionProject, Path.GetExtension(projectFileWriter.FilePath));
        }

        [TestMethod]
        public void SaveShould_Write_Project_Name_And_Empty_ProtocolList_Segment()
        {
            XElement expectedFileContent = new XElement("project",
                                                            new XElement("project_name", PROJECT_NAME),
                                                            new XElement("protocol_list"));

            SaveContentToFileAndCheckResult(expectedFileContent.ToString());
        }

        [TestMethod]
        public void SaveShould_Write_Protocol_Segment()
        {
            OpcMockProject projectWithOneProtocol = new OpcMockProject(PROJECT_NAME);
            string firstProtocolName = "firstProtocol";

            projectWithOneProtocol.AddProtocol(new OpcMockProtocol(firstProtocolName));

            projectFileWriter = new ProjectFileWriter(projectWithOneProtocol, TestContext.TestDir);
         
            XElement fileContentStartXml = new XElement("project", 
                                                            new XElement("project_name", PROJECT_NAME),
                                                            new XElement("protocol_list",
                                                                new XElement("protocol", firstProtocolName)));

            SaveContentToFileAndCheckResult(fileContentStartXml.ToString());
        }

        [TestMethod]
        public void FolderPathShould_Not_Contain_A_Trailing_DirectorySeparator()
        {
            Assert.AreEqual(TestContext.TestDir, projectFileWriter.FolderPath);
            Assert.IsFalse(projectFileWriter.FolderPath.EndsWith(Path.DirectorySeparatorChar.ToString()));
        }

        void SaveContentToFileAndCheckResult(string expectedFileContentStart)
        {
            projectFileWriter.Save();

            string actualFileContent = File.ReadAllText(projectFilePath);
                
            string contentToCheck = actualFileContent.Substring(0, expectedFileContentStart.Length);

            Assert.AreEqual(expectedFileContentStart, contentToCheck);
        }
    }
}
