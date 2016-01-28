using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpcMock.Tests
{
    public class OpcMockTestsBase
    {
        protected TestContext testContext;
        protected string dataFilePath;

        public TestContext TestContext
        {
            get { return this.testContext; }
            set { this.testContext = value; }
        }

        protected void CreateDataFileIfDoesNotExist()
        {
            if (!File.Exists(dataFilePath))
            {
                File.Create(dataFilePath).Close();
            }
        }

        protected void DeleteDataFileIfExists()
        {
            if (File.Exists(dataFilePath))
            {
                File.Delete(dataFilePath);
            }
        }
    }
}