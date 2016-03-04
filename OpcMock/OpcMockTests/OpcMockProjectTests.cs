using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpcMock;

namespace OpcMockTests
{
    class OpcMockProjectTests
    {
        private const int NEW_PROJECT_PROTOCOL_COUNT = 0;

        [TestMethod]
        public void New_Project_Has_A_Name_Set()
        {
            string projectName = "projectName";
            OpcMockProject omp = new OpcMockProject(projectName);

            Assert.AreEqual(projectName, omp.ProjectName);
        }

        [TestMethod]
        public void New_Project_Has_An_Empty_List_Of_Protocols()
        {
            string projectName = "projectName";
            OpcMockProject omp = new OpcMockProject(projectName);

            Assert.AreEqual(NEW_PROJECT_PROTOCOL_COUNT, omp.Protocols.Count);
        }

    }
}
