using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpcMock;

namespace OpcMockTests
{
    [TestClass()]
    public class OpcTagTests
    {
        [TestMethod()]
        public void EqualsShould_Be_True_For_Equal_Tags()
        {
            OpcTag ot1 = new OpcTag("ot1", "value1");
            OpcTag ot1Compare = new OpcTag("ot1", "value1");

            Assert.IsTrue(ot1.Equals(ot1Compare));
        }

        [TestMethod]
        public void EqualsShould_Be_False_For_Tags_Differing_In_One_Or_More_Fields()
        {
            OpcTag ot1 = new OpcTag("ot1", "value1", OpcTag.OpcTagQuality.Good);

            OpcTag notEqualtToOt1 = new OpcTag("ot2", "value1", OpcTag.OpcTagQuality.Good);
            Assert.IsFalse(ot1.Equals(notEqualtToOt1));

            notEqualtToOt1 = new OpcTag("ot1", "value2", OpcTag.OpcTagQuality.Good);
            Assert.IsFalse(ot1.Equals(notEqualtToOt1));

            notEqualtToOt1 = new OpcTag("ot1", "value1", OpcTag.OpcTagQuality.Bad);
            Assert.IsFalse(ot1.Equals(notEqualtToOt1));

            notEqualtToOt1 = new OpcTag("ot1", "value2", OpcTag.OpcTagQuality.Bad);
            Assert.IsFalse(ot1.Equals(notEqualtToOt1));

            notEqualtToOt1 = new OpcTag("ot2", "value2", OpcTag.OpcTagQuality.Bad);
            Assert.IsFalse(ot1.Equals(notEqualtToOt1));
        }

        [TestMethod]
        public void EqualOperatorShould_Be_True_For_Equal_OpcTags()
        {
            OpcTag ot1 = new OpcTag("ot1", "value1");
            OpcTag equalToOt1 = new OpcTag("ot1", "value1");

            Assert.IsTrue(ot1 == equalToOt1);
        }

        [TestMethod]
        public void NotEqualOperatorShould_Be_True_For_Unequal_OpcTags()
        {
            OpcTag ot1 = new OpcTag("ot1", "value1");
            OpcTag notEqualToOt1 = new OpcTag("ot2", "value1");

            Assert.IsTrue(ot1 != notEqualToOt1);
        }
    }
}