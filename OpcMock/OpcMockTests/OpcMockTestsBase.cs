using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpcMockTests
{
    public class OpcMockTestsBase
    {
        protected TestContext testContext;
        protected string dataFilePath;
        protected string projectFilePath;

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

        protected void DeleteProjectFileIfExists()
        {
            if (File.Exists(projectFilePath))
            {
                File.Delete(projectFilePath);
            }
        }
    }
}