using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpcMock.Tests;
using System.IO;
using OpcMock;

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
            //
            // TODO: Konstruktorlogik hier hinzufügen
            //
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
        public void Create_Project_File_In_Project_Path()
        {
            projectFileWriter.Save();

            Assert.IsTrue(File.Exists(projectFilePath));
        }

        [TestMethod]
        public void Create_Project_File_With_Correct_Name_And_Extension()
        {
            projectFileWriter.Save();

            Assert.AreEqual(PROJECT_NAME, Path.GetFileNameWithoutExtension(projectFileWriter.FilePath));
            Assert.AreEqual(OpcMockConstants.FileExtensionProject, Path.GetExtension(projectFileWriter.FilePath));
        }

        [TestMethod]
        public void Create_Project_File_Contains_Name_Segment()
        {
            string expectedFileContentStart = "<project>" + Environment.NewLine
                                         + "    <project_name>" + PROJECT_NAME + "</project_name>" 
                                         + Environment.NewLine;

            SaveContentToFileAndCheckResult(expectedFileContentStart);
        }

        [TestMethod]
        public void Save_Project_File_Contains_Empty_ProtocolList_Segment()
        {
            string expectedFileContentStart = "<project>" + Environment.NewLine
                                              + "    <project_name>" + PROJECT_NAME + "</project_name>" 
                                              + Environment.NewLine
                                              + "    <protocol_list />"
                                              + Environment.NewLine;

            SaveContentToFileAndCheckResult(expectedFileContentStart);
        }

        [TestMethod]
        public void Save_Project_File_Contains_ProtocolList_With_One_Protocol()
        {
            OpcMockProject projectWithOneProtocol = new OpcMockProject(PROJECT_NAME);
            projectWithOneProtocol.AddProtocol(new OpcMockProtocol("firstProtocol"));

            projectFileWriter = new ProjectFileWriter(projectWithOneProtocol, TestContext.TestDir);

            string expectedFileContentStart =   "<project>" + Environment.NewLine
                                              + "    <project_name>" + PROJECT_NAME + "</project_name>" + Environment.NewLine
                                              + "    <protocol_list>"
                                              + Environment.NewLine
                                              + "        <protocol>firstProtocol</protocol>"
                                              + Environment.NewLine
                                              + "    </protocol_list>"
                                              + Environment.NewLine;

            SaveContentToFileAndCheckResult(expectedFileContentStart);
        }

        [TestMethod]
        public void Project_Folder_Returns_Path_Without_Trailing_Backslash()
        {
            Assert.AreEqual(TestContext.TestDir, projectFileWriter.FolderPath);
            Assert.IsFalse(TestContext.TestDir.EndsWith("\\"));
        }

        void SaveContentToFileAndCheckResult(string expectedFileContentStart)
        {
            projectFileWriter.Save();

            string actualFileContent = File.ReadAllText(projectFilePath).Substring(0, expectedFileContentStart.Length);

            Assert.AreEqual(expectedFileContentStart, actualFileContent);
        }
    }
}
