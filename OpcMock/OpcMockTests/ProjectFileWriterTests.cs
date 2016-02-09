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
        private string FILE_EXTENSION_PROJECT = ".project";
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
            projectFilePath = TestContext.TestDir + Path.DirectorySeparatorChar + PROJECT_NAME + FILE_EXTENSION_PROJECT;
            projectFileWriter = new ProjectFileWriter(projectFilePath);
        }

        [TestMethod]
        public void Create_Project_File_In_Project_Path()
        {
            DeleteProjectFileIfExists();

            projectFileWriter.SaveProjectFileContent(" ");

            Assert.IsTrue(File.Exists(projectFilePath));

            DeleteProjectFileIfExists();
        }

        [TestMethod]
        public void Create_Project_File_With_Correct_Name_And_Extension()
        {
            DeleteProjectFileIfExists();

            projectFileWriter.SaveProjectFileContent(" ");

            Assert.AreEqual(PROJECT_NAME, Path.GetFileNameWithoutExtension(projectFileWriter.ProjectFilePath));
            Assert.AreEqual(FILE_EXTENSION_PROJECT, Path.GetExtension(projectFileWriter.ProjectFilePath));

            DeleteProjectFileIfExists();
        }

        [TestMethod]
        public void Create_Project_File_Contains_Name_Segment()
        {
            string expectedFileContent = "<project>" + Environment.NewLine
                                         + "    <project_name>" + PROJECT_NAME + "</project_name" + Environment.NewLine
                                         + "</project>";

            projectFileWriter.SaveProjectFileContent(expectedFileContent);

            string actualFileContent = File.ReadAllText(projectFilePath);

            Assert.AreEqual(expectedFileContent, actualFileContent);
        }
    }
}
