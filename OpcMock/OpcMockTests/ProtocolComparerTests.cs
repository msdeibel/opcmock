using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpcMock;

namespace OpcMockTests
{
    [TestClass]
    public class ProtocolComparerTests
    {
        private const int EQUALITY = 0;

        [TestMethod]
        public void Protocols_With_The_Same_Name_Are_Equal()
        {
            ProtocolComparer pc = new ProtocolComparer();

            OpcMockProtocol omp1 = new OpcMockProtocol("omp1");
            OpcMockProtocol compare1 = new OpcMockProtocol("omp1");

            Assert.AreEqual(EQUALITY, pc.Compare(omp1, compare1));
        }
    }
}
