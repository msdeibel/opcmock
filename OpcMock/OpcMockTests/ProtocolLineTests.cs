using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpcMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcMock.Tests
{
    [TestClass()]
    public class ProtocolLineTests
    {
        [TestMethod()]
        public void ConstructorShould_Parse_Valid_Protocol_Line_Without_Blanks()
        {
            ProtocolLine protocolLine = new ProtocolLine("Set;tagPath;tagValue;192");

            Assert.AreEqual(ProtocolLine.Actions.Set, protocolLine.Action);
            Assert.AreEqual("tagPath", protocolLine.TagPath);
            Assert.AreEqual("tagValue", protocolLine.TagValue);
            Assert.AreEqual("192", protocolLine.TagQualityInt);
        }

        [TestMethod()]
        public void ConstructorShould_Parse_Valid_Protocol_Line_With_Blanks()
        {
            ProtocolLine protocolLine = new ProtocolLine("Set; tagPath; tagValue; 192");

            Assert.AreEqual(ProtocolLine.Actions.Set, protocolLine.Action);
            Assert.AreEqual("tagPath", protocolLine.TagPath);
            Assert.AreEqual("tagValue", protocolLine.TagValue);
            Assert.AreEqual("192", protocolLine.TagQualityInt);
        }

        /// FIXME Core Exceptions should be encapsulated
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void WhitespacesOnlyProtocolLineShould_Cause_An_ArgumentException()
        {
            ProtocolLine protocolLine = new ProtocolLine(" \t");
        }

        /// FIXME Core Exceptions should be encapsulated
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyProtocolLineShould_Cause_An_ArgumentExceptionn()
        {
            ProtocolLine protocolLine = new ProtocolLine(string.Empty);
        }

        [TestMethod()]
        [ExpectedException(typeof(ProtocolActionException))]
        public void UnknownActionShould_Cause_A_ProtocolActionException()
        {
            ProtocolLine protocolLine = new ProtocolLine("UnSet; tagPath; tagValue; 192");
        }

        /// FIXME Core Exceptions should be encapsulated
        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InvalidLineShould_Cause_An_IndexOutOfRangeException()
        {
            ProtocolLine protocolLine = new ProtocolLine("Set; tagPath; tagValue");
        }

        [TestMethod()]
        public void DummyShould_Be_A_Valid_Contructor_Parameter()
        {
            ProtocolLine protocolLine = new ProtocolLine("Dummy");
        }

        [TestMethod()]
        public void EqualsShould_Work_For_Equal_Protocol_Lines()
        {
            ProtocolLine pl1 = new ProtocolLine("Set;tagPath1;tagValue1;192");
            ProtocolLine pl2 = new ProtocolLine("Set;tagPath1;tagValue1;192");

            Assert.IsTrue(pl1.Equals(pl2));
        }

        [TestMethod]
        public void EqualsShould_Work_For_UnEqual_Protocol_Lines()
        {
            ProtocolLine pl1 = new ProtocolLine("Set;tagPath1;tagValue1;192");

            ProtocolLine pl2 = new ProtocolLine("Dummy;tagPath1;tagValue1;192");
            Assert.IsFalse(pl1.Equals(pl2));

            pl2 = new ProtocolLine("Set;tagPath2;tagValue1;192");
            Assert.IsFalse(pl1.Equals(pl2));

            pl2 = new ProtocolLine("Set;tagPath1;tagValue2;192");
            Assert.IsFalse(pl1.Equals(pl2));

            pl2 = new ProtocolLine("Set;tagPath1;tagValue1;0");
            Assert.IsFalse(pl1.Equals(pl2));

            pl2 = new ProtocolLine("Dummy;tagPath1;tagValue1;0");
            Assert.IsFalse(pl1.Equals(pl2));
        }

        [TestMethod]
        public void EqualityOperatorShould_Work_OK_For_Protocol_Lines()
        {
            ProtocolLine pl1 = new ProtocolLine("Set;tagPath1;tagValue1;192");
            ProtocolLine pl2 = new ProtocolLine("Set;tagPath1;tagValue1;192");

            Assert.IsTrue(pl1 == pl2);
        }

        [TestMethod]
        public void NotEqualOperatorShould_Work_For_Unequal_Protocol_Lines()
        {
            ProtocolLine pl1 = new ProtocolLine("Set;tagPath1;tagValue1;192");
            ProtocolLine pl2 = new ProtocolLine("Dummy;tagPath1;tagValue1;192");

            Assert.IsTrue(pl1 != pl2);
        }

        [TestMethod]
        public void ToStringWithoutParametersShould_Produce_Semicolon_Separated_String()
        {
            ProtocolLine protocolLine = new ProtocolLine("Set;tagPath;tagValue;192");

            Assert.AreEqual("Set;tagPath;tagValue;192", protocolLine.ToString());
        }
    }
}