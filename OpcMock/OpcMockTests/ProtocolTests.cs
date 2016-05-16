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

            ///PROPOSAL refactor into variables to more express the equality
            omp.Append(new ProtocolLine(ompLine1));
            omp.Append(new ProtocolLine(ompLine2));

            ///PROPOSAL expose IEnumberable instead of List
            Assert.AreEqual(new ProtocolLine(ompLine2), omp.Lines[1]);
        }

        [TestMethod]
        public void Equality_Operator_Works_Based_On_Protocol_Name()
        {
            Assert.IsTrue(new OpcMockProtocol(PROTOCOL_NAME).Equals(new OpcMockProtocol(PROTOCOL_NAME)));
        }

        [TestMethod]
        public void ToString_Return_Name()
        {
            OpcMockProtocol omp = new OpcMockProtocol(PROTOCOL_NAME);

            Assert.AreEqual(PROTOCOL_NAME, omp.ToString());
        }

        /// PROPOSAL - parameterize test ==> NUnit
        /// 
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Empty or spaces-only name should not be accepted")]
        public void Empty_Or_SpacesOnly_Name_Raises_ArgumentException()
        {
            OpcMockProtocol omp = new OpcMockProtocol(string.Empty);
            
            ///FIXME these two lines are NEVER executed
            ///since the exception is already caught and the test ends
            ///after line 64
            omp = new OpcMockProtocol("    ");
            omp = new OpcMockProtocol("\t");

        }

        [TestMethod]
        public void Adding_A_Line_Raises_LineAdded_Event()
        {
            bool eventRaised = false;

            OpcMockProtocol protocol = new OpcMockProtocol(PROTOCOL_NAME);

            protocol.OnProtocolLineAdded += delegate (ProtocolLineAddedArgs plaArgs) { eventRaised = true; };

            protocol.Append(new ProtocolLine("Set;tagPath;tagValue;192"));

            Assert.IsTrue(eventRaised);
        }

        [TestMethod]
        public void Append_For_StringArray_Appends_All_Lines()
        {
            OpcMockProtocol protocol = new OpcMockProtocol(PROTOCOL_NAME);

            string[] testArray = new string[] { "Set; tagPath1; tagValue; 192", "Set;tagPath2;tagValue;192", "Set;tagPath3;tagValue;192" };

            protocol.Append(testArray);

            Assert.AreEqual(new ProtocolLine("Set;tagPath1;tagValue;192"), protocol.Lines[0]);
            Assert.AreEqual(new ProtocolLine("Set;tagPath2;tagValue;192"), protocol.Lines[1]);
            Assert.AreEqual(new ProtocolLine("Set;tagPath3;tagValue;192"), protocol.Lines[2]);
        }
    }
}
