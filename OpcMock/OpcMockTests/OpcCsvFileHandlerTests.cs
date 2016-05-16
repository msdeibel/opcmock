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

        /// PROPOSAL
        /// CsvFileHandlerShould_Set_DataFilePath
        [TestMethod()]
        public void Constructor_Sets_DataFilePath()
        {
            /// PROPOSAL
            /// Pass dataFilePath as parameter (see proposal below)
            CreateDataFileIfDoesNotExist();

            OpcCsvFileHandler ocfh = new OpcCsvFileHandler(dataFilePath, lockAcquistionRetriesAnyIntGreater0);

            /// PROPOSAL
            //If something is part of the assertion it should be visible
            //in the setup part of the test(method)
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
            dataFilePath = dataFilePath.Replace(FileExtensionContants.FileExtensionData, ".abc");

            OpcCsvFileHandler ocfh = new OpcCsvFileHandler(dataFilePath, lockAcquistionRetriesAnyIntGreater0);
        }


    }
}