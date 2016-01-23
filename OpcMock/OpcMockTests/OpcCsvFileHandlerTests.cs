using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpcMock;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcMock.Tests
{
    [TestClass()]
    public class OpcCsvFileHandlerTests
    {
        private TestContext testContext;
        private string dataFilePath;
        private int lockAcquistionRetries;

        public TestContext TestContext
        {
            get { return this.testContext; }
            set { this.testContext = value; }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            dataFilePath = TestContext.TestDir + "\\testdatafile.csv";
            lockAcquistionRetries = 23;
        }

        [TestMethod()]
        public void Constructor_Correctly_Sets_DataFilePath()
        {
            CreateDataFileIfDoesNotExist();

            OpcCsvFileHandler ocfh = new OpcCsvFileHandler(dataFilePath, lockAcquistionRetries);

            Assert.AreEqual(dataFilePath, ocfh.DataFilePath);

            DeleteDataFileIfExists();
        }

        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Contructor_Throws_Exception_For_Non_Existent_File()
        {
            DeleteDataFileIfExists();

            OpcCsvFileHandler ocfh = new OpcCsvFileHandler(dataFilePath, lockAcquistionRetries);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Contructor_Throws_Exception_For_Wrong_File_Extension()
        {
            dataFilePath = dataFilePath.Replace(".csv", ".abc");

            DeleteDataFileIfExists();

            OpcCsvFileHandler ocfh = new OpcCsvFileHandler(dataFilePath, lockAcquistionRetries);
        }

        private void CreateDataFileIfDoesNotExist()
        {
            if (!File.Exists(dataFilePath))
            {
                File.Create(dataFilePath).Close();
            }
        }

        private void DeleteDataFileIfExists()
        {
            if (File.Exists(dataFilePath))
            {
                File.Delete(dataFilePath);
            }
        }
    }
}