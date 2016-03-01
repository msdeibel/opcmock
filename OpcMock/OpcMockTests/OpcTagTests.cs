using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpcMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcMockTests
{
    [TestClass()]
    public class OpcTagTests
    {
        [TestMethod()]
        public void Equals_Method_OK_For_Equal_OpcTags()
        {
            OpcTag ot1 = new OpcTag("ot1", "value1");
            OpcTag ot1Compare = new OpcTag("ot1", "value1");

            Assert.IsTrue(ot1.Equals(ot1Compare));
        }

        [TestMethod]
        public void Equals_Method_OK_For_UnEqual_OpcTags()
        {
            OpcTag ot1 = new OpcTag("ot1", "value1", OpcTag.OpcTagQuality.Good);

            OpcTag ot2 = new OpcTag("ot2", "value1", OpcTag.OpcTagQuality.Good);
            Assert.IsFalse(ot1.Equals(ot2));

            ot2 = new OpcTag("ot1", "value2", OpcTag.OpcTagQuality.Good);
            Assert.IsFalse(ot1.Equals(ot2));

            ot2 = new OpcTag("ot1", "value1", OpcTag.OpcTagQuality.Bad);
            Assert.IsFalse(ot1.Equals(ot2));

            ot2 = new OpcTag("ot1", "value2", OpcTag.OpcTagQuality.Bad);
            Assert.IsFalse(ot1.Equals(ot2));

            ot2 = new OpcTag("ot2", "value2", OpcTag.OpcTagQuality.Bad);
            Assert.IsFalse(ot1.Equals(ot2));
        }

        [TestMethod]
        public void Equality_Operator_OK_For_Equal_OpcTags()
        {
            OpcTag ot1 = new OpcTag("ot1", "value1");
            OpcTag ot1Compare = new OpcTag("ot1", "value1");

            Assert.IsTrue(ot1 == ot1Compare);
        }

        [TestMethod]
        public void NotEqual_Operator_OK_For_Unequal_OpcTags()
        {
            OpcTag ot1 = new OpcTag("ot1", "value1");
            OpcTag ot2 = new OpcTag("ot2", "value1");

            Assert.IsTrue(ot1 != ot2);
        }
    }
}