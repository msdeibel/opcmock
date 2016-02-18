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
            projectFilePath = TestContext.TestDir + Path.DirectorySeparatorChar + PROJECT_NAME + OpcMockConstants.FileExtensionProject;
            projectFileWriter = new ProjectFileWriter(projectFilePath);
        }

        [TestMethod]
        public void Create_Project_File_In_Project_Path()
        {
            DeleteProjectFileIfExists();

            projectFileWriter.SaveProjectFileContent();

            Assert.IsTrue(File.Exists(projectFilePath));

            DeleteProjectFileIfExists();
        }

        [TestMethod]
        public void Create_Project_File_With_Correct_Name_And_Extension()
        {
            DeleteProjectFileIfExists();

            projectFileWriter.SaveProjectFileContent();

            Assert.AreEqual(PROJECT_NAME, Path.GetFileNameWithoutExtension(projectFileWriter.ProjectFilePath));
            Assert.AreEqual(OpcMockConstants.FileExtensionProject, Path.GetExtension(projectFileWriter.ProjectFilePath));

            DeleteProjectFileIfExists();
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
        public void Save_Project_File_Contains_ProjectDataFile_Segment()
        {
            string expectedFileContentStart = "<project>" + Environment.NewLine
                                              + "    <project_name>" + PROJECT_NAME + "</project_name>" 
                                              + Environment.NewLine
                                              + "    <project_data_file>" + PROJECT_NAME + OpcMockConstants.FileExtensionData + "</project_data_file>"
                                              + Environment.NewLine;

            SaveContentToFileAndCheckResult(expectedFileContentStart);
        }

        [TestMethod]
        public void Constructor_Sets_Project_Name()
        {
            projectFileWriter = new ProjectFileWriter(projectFilePath, PROJECT_NAME);

            Assert.AreEqual(PROJECT_NAME, projectFileWriter.ProjectName);
        }

        [TestMethod]
        public void Save_Project_File_Contains_Empty_ProtocolList_Segment()
        {
            string expectedFileContentStart = "<project>" + Environment.NewLine
                                              + "    <project_name>" + PROJECT_NAME + "</project_name>" + Environment.NewLine
                                              + "    <project_data_file>" + PROJECT_NAME + OpcMockConstants.FileExtensionData + "</project_data_file>"
                                              + Environment.NewLine
                                              + "    <protocol_list />"
                                              + Environment.NewLine;

            SaveContentToFileAndCheckResult(expectedFileContentStart);
        }

        [TestMethod]
        public void Add_ProtocolName_Adds_Item_At_The_End_Of_The_List()
        {
            projectFileWriter.AddProtocolName("firstProtocol");
            projectFileWriter.AddProtocolName("secondProtocol");

            Assert.AreEqual("firstProtocol", projectFileWriter.ProtocolNames[0]);
            Assert.AreEqual("secondProtocol", projectFileWriter.ProtocolNames[1]);
        }

        [TestMethod]
        public void Same_Protocol_Name_Cannot_Be_Added_More_Than_Once()
        {
            projectFileWriter.AddProtocolName("firstProtocol");
            projectFileWriter.AddProtocolName("firstProtocol");

            Assert.AreEqual(1, projectFileWriter.ProtocolNames.Count);
        }

        [TestMethod]
        public void Save_Project_File_Contains_ProtocolList_With_One_Protocol()
        {
            string expectedFileContentStart =   "<project>" + Environment.NewLine
                                              + "    <project_name>" + PROJECT_NAME + "</project_name>" + Environment.NewLine
                                              + "    <project_data_file>" + PROJECT_NAME + OpcMockConstants.FileExtensionData + "</project_data_file>"
                                              + Environment.NewLine
                                              + "    <protocol_list>"
                                              + Environment.NewLine
                                              + "        <protocol>firstProtocol</protocol>"
                                              + Environment.NewLine
                                              + "    </protocol_list>"
                                              + Environment.NewLine;

            projectFileWriter.AddProtocolName("firstProtocol");

            SaveContentToFileAndCheckResult(expectedFileContentStart);
        }

        void SaveContentToFileAndCheckResult(string expectedFileContentStart)
        {
            projectFileWriter.SaveProjectFileContent();

            string actualFileContent = File.ReadAllText(projectFilePath).Substring(0, expectedFileContentStart.Length);

            Assert.AreEqual(expectedFileContentStart, actualFileContent);
        }
    }
}
