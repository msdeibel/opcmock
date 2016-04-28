using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using OpcMock;

namespace OpcMockTests
{
    [TestClass]
    public class ProtocolReaderTests : OpcMockTestsBase
    {
        private string testProtocolFilePath;

        [TestInitialize]
        public void TestInitialize()
        {
            testProtocolFilePath = testContext.DeploymentDirectory + Path.DirectorySeparatorChar + "testProtocol.protocol";
        }

        [TestMethod]
        public void ProtocolReader_Is_Created_With_A_Complete_Filepath()
        {
            ProtocolReader protocolReader = new ProtocolReader(testProtocolFilePath);

            Assert.AreEqual(testProtocolFilePath, protocolReader.FilePath);
        }

        [TestMethod]
        public void Load_Operation_Gets_File_Content_Into_StringArray()
        {
            string testFileContent = "Line 1" + Environment.NewLine + "Line 2 Line 2" + Environment.NewLine + "Line 3 Line 3 Line 3";

            File.WriteAllText(testProtocolFilePath, testFileContent);

            ProtocolReader protocolReader = new ProtocolReader(testProtocolFilePath);

            protocolReader.Load();

            CollectionAssert.AreEqual(testFileContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.None), protocolReader.LinesFromFile);
        }
    }
}
