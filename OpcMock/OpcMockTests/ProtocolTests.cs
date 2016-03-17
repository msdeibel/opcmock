using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpcMock;

namespace OpcMockTests
{
    [TestClass]
    public class ProtocolTests
    {
        private const int NEW_PROTOCOL_LINE_COUNT = 0;
        private const string PROTOCOL_NAME = "protocolName";

        [TestMethod]
        public void New_Protocol_Has_No_Lines()
        {
            OpcMockProtocol omp = new OpcMockProtocol(PROTOCOL_NAME);

            Assert.AreEqual(NEW_PROTOCOL_LINE_COUNT, omp.Lines.Count);
        }

        [TestMethod]
        public void New_Protocol_Is_Created_With_A_Name()
        {
            OpcMockProtocol omp = new OpcMockProtocol(PROTOCOL_NAME);

            Assert.AreEqual(PROTOCOL_NAME, omp.Name);
        }

        [TestMethod]
        public void Add_Line_Appends_A_Line_At_The_End()
        {
            OpcMockProtocol omp = new OpcMockProtocol(PROTOCOL_NAME);

            string ompLine1 = "Set;tagPath1;tagValue1;192";
            string ompLine2 = "Set;tagPath2;tagValue2;192";

            omp.Append(new ProtocolLine(ompLine1));
            omp.Append(new ProtocolLine(ompLine2));

            Assert.AreEqual(new ProtocolLine(ompLine2), omp.Lines[1]);
        }

        [TestMethod]
        public void Equality_Operator_Works_Based_On_Protocol_Name()
        {
            Assert.IsTrue(new OpcMockProtocol(PROTOCOL_NAME).Equals(new OpcMockProtocol(PROTOCOL_NAME)));
        }
    }
}
