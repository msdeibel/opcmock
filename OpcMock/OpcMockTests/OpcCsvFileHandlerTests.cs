using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpcMock;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcMockTests
{
    [TestClass()]
    public class OpcCsvFileHandlerTests : OpcMockTestsBase
    {
        private int lockAcquistionRetriesAnyIntGreater0;

        [TestInitialize]
        public void TestInitialize()
        {
            dataFilePath = TestContext.TestDir + "\\testdatafile" + FileExtensionContants.FileExtensionData;
            lockAcquistionRetriesAnyIntGreater0 = 23;
            DeleteDataFileIfExists();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DeleteDataFileIfExists();
        }

        [TestMethod()]
        public void CsvFileHandlerShould_Set_DataFilePath()
        {
            CreateDataFileIfDoesNotExist(dataFilePath);

            OpcCsvFileHandler ocfh = new OpcCsvFileHandler(dataFilePath, lockAcquistionRetriesAnyIntGreater0);

            Assert.AreEqual(dataFilePath, ocfh.DataFilePath);
        }

        /// PROPOSAL separate out/hide FileSystemAccess exception
        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Contructor_Throws_Exception_For_Non_Existent_File()
        {
            OpcCsvFileHandler ocfh = new OpcCsvFileHandler(dataFilePath, lockAcquistionRetriesAnyIntGreater0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Contructor_Throws_Exception_For_Wrong_File_Extension()
        {
            string arbitraryFileExtension = ".abc";

            dataFilePath = dataFilePath.Replace(FileExtensionContants.FileExtensionData, arbitraryFileExtension);

            OpcCsvFileHandler ocfh = new OpcCsvFileHandler(dataFilePath, lockAcquistionRetriesAnyIntGreater0);
        }
    }
}