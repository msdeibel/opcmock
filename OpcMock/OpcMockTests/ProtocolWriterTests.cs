using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpcMock;
using System;
using System.IO;

namespace OpcMockTests
{
    [TestClass]
    public class ProtocolWriterTests : OpcMockTestsBase
    {
        [TestMethod]
        public void ProtocolWriter_Is_Created_With_A_Folder_Path()
        {
            string folderPath = "folderPath";
            string projectName = "projectName";

            ProtocolWriter protocolWriter = new ProtocolWriter(folderPath, projectName);

            Assert.AreEqual(folderPath, protocolWriter.FolderPath);
            Assert.AreEqual(projectName, protocolWriter.ProjectName);
        }

        [TestMethod]
        public void Save_Creates_A_Protocol_File_In_The_FolderPath()
        {
            string projectName = "projectName";
            string protocolName = "protocolName";

            OpcMockProtocol opcMockProtocol = new OpcMockProtocol(protocolName);

            ProtocolWriter protocolWriter = new ProtocolWriter(TestContext.TestDeploymentDir, projectName);

            protocolWriter.Save(opcMockProtocol);

            string protocolFilePath = TestContext.TestDeploymentDir + Path.DirectorySeparatorChar + protocolName + FileExtensionContants.FileExtensionProtocol;

            Assert.IsTrue(File.Exists(protocolFilePath));

            File.Delete(protocolFilePath);
        }

        [TestMethod]
        public void Save_Stores_ProtocolLines_In_The_File()
        {
            string projectName = "projectName";
            string protocolName = "protocolName";

            OpcMockProtocol omp = new OpcMockProtocol(protocolName);
            string ompLine1 = "Set;tagPath1;tagValue1;192";
            string ompLine2 = "Set;tagPath2;tagValue2;192";
            omp.Append(new ProtocolLine(ompLine1));
            omp.Append(new ProtocolLine(ompLine2));

            string protocolFilePath = TestContext.TestDeploymentDir + Path.DirectorySeparatorChar + protocolName + FileExtensionContants.FileExtensionProtocol;

            ProtocolWriter protocolWriter = new ProtocolWriter(TestContext.TestDeploymentDir, projectName);

            protocolWriter.Save(omp);

            string expectedFileContent = ompLine1 + Environment.NewLine + ompLine2 + Environment.NewLine;

            string actualFileContent = File.ReadAllText(protocolFilePath);

            Assert.AreEqual(expectedFileContent, actualFileContent);

            File.Delete(protocolFilePath);
        }
    }
}
