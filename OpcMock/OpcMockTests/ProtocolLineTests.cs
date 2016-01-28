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
    }
}