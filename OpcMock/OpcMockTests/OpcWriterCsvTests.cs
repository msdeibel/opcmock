using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpcMock;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcMockTests
{
    [TestClass()]
    public class OpcWriterCsvTests : OpcMockTestsBase
    {
        private OpcWriterCsv opcWriterCsv;

        [TestInitialize]
        public void TestInitialize()
        {
            dataFilePath = TestContext.TestDir + "\\testdatafile" + FileExtensionContants.FileExtensionData;
            DeleteDataFileIfExists();
            CreateDataFileIfDoesNotExist(dataFilePath);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DeleteDataFileIfExists();
        }

        [TestMethod()]
        public void WriteAllTagsShould_Work_With_Empty_DataFile()
        {
            List<OpcTag> allOpcTags = new List<OpcTag>();

            allOpcTags.Add(new OpcTag("opcTagPath1", "opcTagValue1", OpcTag.OpcTagQuality.Good));
            allOpcTags.Add(new OpcTag("opcTagPath2", "opcTagValue2", OpcTag.OpcTagQuality.Bad));
            allOpcTags.Add(new OpcTag("opcTagPath3", "opcTagValue3", OpcTag.OpcTagQuality.Unknown));

            opcWriterCsv = new OpcWriterCsv(dataFilePath);

            opcWriterCsv.WriteAllTags(allOpcTags);

            string expectedFileContent = "opcTagPath1;opcTagValue1;Good;192" + Environment.NewLine
                                         + "opcTagPath2;opcTagValue2;Bad;0" + Environment.NewLine
                                         + "opcTagPath3;opcTagValue3;Unknown;8"+ Environment.NewLine;

            string actualFileContent = File.ReadAllText(dataFilePath);

            Assert.AreEqual(expectedFileContent, actualFileContent);
        }

        [TestMethod()]
        public void WriteAllTagsShould_Overwrite_DataFile_Content()
        {
            List<OpcTag> allOpcTags = new List<OpcTag>();

            allOpcTags.Add(new OpcTag("opcTagPath1", "opcTagValue1", OpcTag.OpcTagQuality.Good));
            allOpcTags.Add(new OpcTag("opcTagPath2", "opcTagValue2", OpcTag.OpcTagQuality.Bad));

            opcWriterCsv = new OpcWriterCsv(dataFilePath);

            allOpcTags.Clear();

            allOpcTags.Add(new OpcTag("opcTagPath3", "opcTagValue3", OpcTag.OpcTagQuality.Bad));
            allOpcTags.Add(new OpcTag("opcTagPath2", "opcTagValue2", OpcTag.OpcTagQuality.Good));
            allOpcTags.Add(new OpcTag("opcTagPath1", "opcTagValue1", OpcTag.OpcTagQuality.Unknown));

            opcWriterCsv.WriteAllTags(allOpcTags);

            string expectedFileContent = "opcTagPath3;opcTagValue3;Bad;0" + Environment.NewLine
                                            +"opcTagPath2;opcTagValue2;Good;192" + Environment.NewLine
                                            + "opcTagPath1;opcTagValue1;Unknown;8" + Environment.NewLine;

            string actualFileContent = File.ReadAllText(dataFilePath);

            Assert.AreEqual(expectedFileContent, actualFileContent);
        }

        [TestMethod()]
        public void WriteSingleTagShould_Not_Produce_A_Leading_NewLine_In_AnEmpty_DataFile()
        {
            opcWriterCsv = new OpcWriterCsv(dataFilePath);

            opcWriterCsv.WriteSingleTag(new OpcTag("opcTagSingle", "opcValueSingle", OpcTag.OpcTagQuality.Good));

            string expectedFileContent = "opcTagSingle;opcValueSingle;Good;192";

            string actualFileContent = File.ReadAllText(dataFilePath);

            Assert.AreEqual(expectedFileContent, actualFileContent);
        }

        [TestMethod]
        public void WriteSingleTagShould_Create_A_Leading_New_Line_If_DataFile_Has_Content()
        {
            opcWriterCsv = new OpcWriterCsv(dataFilePath);
            opcWriterCsv.WriteSingleTag(new OpcTag("opcTagSingle", "opcValueSingle", OpcTag.OpcTagQuality.Good));
            opcWriterCsv.WriteSingleTag(new OpcTag("opcTagSingle2", "opcValueSingle2", OpcTag.OpcTagQuality.Bad));

            string expectedFileContent = "opcTagSingle;opcValueSingle;Good;192" + Environment.NewLine
                                         + "opcTagSingle2;opcValueSingle2;Bad;0";

            string actualFileContent = File.ReadAllText(dataFilePath);

            Assert.AreEqual(expectedFileContent, actualFileContent);
        }

        [TestMethod]
        public void WriteSingleTagShould_Overwrite_Existing_Tag_Information_In_DataFile()
        {
            opcWriterCsv = new OpcWriterCsv(dataFilePath);

            opcWriterCsv.WriteSingleTag(new OpcTag("opcTagSingle", "opcValueSingle", OpcTag.OpcTagQuality.Good));
            opcWriterCsv.WriteSingleTag(new OpcTag("opcTagSingle2", "opcValueSingle2", OpcTag.OpcTagQuality.Bad));

            opcWriterCsv.WriteSingleTag(new OpcTag("opcTagSingle", "opcValue1", OpcTag.OpcTagQuality.Good));

            string expectedFileContent = "opcTagSingle;opcValue1;Good;192" + Environment.NewLine
                                         + "opcTagSingle2;opcValueSingle2;Bad;0";

            string actualFileContent = File.ReadAllText(dataFilePath);

            Assert.AreEqual(expectedFileContent, actualFileContent);
        }
    }
}