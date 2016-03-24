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
        public void Constructor_Parses_Valid_Protocol_Line_Without_Blanks()
        {
            ProtocolLine protocolLine = new ProtocolLine("Set;tagPath;tagValue;192");

            Assert.AreEqual(ProtocolLine.Actions.Set, protocolLine.Action);
            Assert.AreEqual("tagPath", protocolLine.TagPath);
            Assert.AreEqual("tagValue", protocolLine.TagValue);
            Assert.AreEqual("192", protocolLine.TagQualityInt);
        }

        [TestMethod()]
        public void Constructor_Parses_Valid_Protocol_Line_With_Blanks()
        {
            ProtocolLine protocolLine = new ProtocolLine("Set; tagPath; tagValue; 192");

            Assert.AreEqual(ProtocolLine.Actions.Set, protocolLine.Action);
            Assert.AreEqual("tagPath", protocolLine.TagPath);
            Assert.AreEqual("tagValue", protocolLine.TagValue);
            Assert.AreEqual("192", protocolLine.TagQualityInt);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Whitespace_Only_Protocol_Line_Argument_Causes_Exception()
        {
            ProtocolLine protocolLine = new ProtocolLine(" \t");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Empty_Protocol_Line_Argument_Causes_Exception()
        {
            ProtocolLine protocolLine = new ProtocolLine(string.Empty);
        }

        [TestMethod()]
        [ExpectedException(typeof(ProtocolActionException))]
        public void Unknown_Action_Causes_Exception()
        {
            ProtocolLine protocolLine = new ProtocolLine("UnSet; tagPath; tagValue; 192");
        }

        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Invalid_Line_Causes_Exception()
        {
            ProtocolLine protocolLine = new ProtocolLine("Set; tagPath; tagValue");
        }

        [TestMethod()]
        public void Dummy_Line_Is_Valid()
        {
            ProtocolLine protocolLine = new ProtocolLine("Dummy");
        }

        [TestMethod()]
        public void Equals_Method_OK_For_Equal_Protocol_Lines()
        {
            ProtocolLine pl1 = new ProtocolLine("Set;tagPath1;tagValue1;192");
            ProtocolLine pl2 = new ProtocolLine("Set;tagPath1;tagValue1;192");

            Assert.IsTrue(pl1.Equals(pl2));
        }

        [TestMethod]
        public void Equals_Method_OK_For_UnEqual_Protocol_Lines()
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
        public void Equality_Operator_OK_For_Protocol_Lines()
        {
            ProtocolLine pl1 = new ProtocolLine("Set;tagPath1;tagValue1;192");
            ProtocolLine pl2 = new ProtocolLine("Set;tagPath1;tagValue1;192");

            Assert.IsTrue(pl1 == pl2);
        }

        [TestMethod]
        public void NotEqual_Operator_OK_For_Unequal_Protocol_Lines()
        {
            ProtocolLine pl1 = new ProtocolLine("Set;tagPath1;tagValue1;192");
            ProtocolLine pl2 = new ProtocolLine("Dummy;tagPath1;tagValue1;192");

            Assert.IsTrue(pl1 != pl2);
        }

        [TestMethod]
        public void ToString_Without_Parameter_Produces_Semicolon_Separated_String()
        {
            ProtocolLine protocolLine = new ProtocolLine("Set;tagPath;tagValue;192");

            Assert.AreEqual("Set;tagPath;tagValue;192", protocolLine.ToString());
        }
    }
}