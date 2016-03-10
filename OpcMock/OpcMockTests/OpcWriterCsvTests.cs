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
        }

        [TestMethod()]
        public void Write_All_Tags_Works_With_Empty_DataFile()
        {
            List<OpcTag> allOpcTags = new List<OpcTag>();

            allOpcTags.Add(new OpcTag("opcTagPath1", "opcTagValue1", OpcTag.OpcTagQuality.Good));
            allOpcTags.Add(new OpcTag("opcTagPath2", "opcTagValue2", OpcTag.OpcTagQuality.Bad));
            allOpcTags.Add(new OpcTag("opcTagPath3", "opcTagValue3", OpcTag.OpcTagQuality.Unknown));

            CreateDataFileIfDoesNotExist();

            opcWriterCsv = new OpcWriterCsv(dataFilePath);

            opcWriterCsv.WriteAllTags(allOpcTags);

            string expectedFileContent = "opcTagPath1;opcTagValue1;Good;192" + Environment.NewLine
                                         + "opcTagPath2;opcTagValue2;Bad;0" + Environment.NewLine
                                         + "opcTagPath3;opcTagValue3;Unknown;8"+ Environment.NewLine;

            string actualFileContent = File.ReadAllText(dataFilePath);

            Assert.AreEqual(expectedFileContent, actualFileContent);

            DeleteDataFileIfExists();
        }

        [TestMethod()]
        public void Write_All_Tags_Overwrites_DataFile_Content()
        {
            List<OpcTag> allOpcTags = new List<OpcTag>();

            allOpcTags.Add(new OpcTag("opcTagPath1", "opcTagValue1", OpcTag.OpcTagQuality.Good));
            allOpcTags.Add(new OpcTag("opcTagPath2", "opcTagValue2", OpcTag.OpcTagQuality.Bad));

            CreateDataFileIfDoesNotExist();

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

            DeleteDataFileIfExists();
        }

        [TestMethod()]
        public void Write_Single_Tag_Into_Empty_DataFile_Has_No_Leading_Newline()
        {
            CreateDataFileIfDoesNotExist();

            opcWriterCsv = new OpcWriterCsv(dataFilePath);

            opcWriterCsv.WriteSingleTag(new OpcTag("opcTagSingle", "opcValueSingle", OpcTag.OpcTagQuality.Good));

            string expectedFileContent = "opcTagSingle;opcValueSingle;Good;192";

            string actualFileContent = File.ReadAllText(dataFilePath);

            Assert.AreEqual(expectedFileContent, actualFileContent);

            DeleteDataFileIfExists();
        }

        [TestMethod]
        public void Write_Single_Tag_Into_DataFile_With_Content_Has_Leading_Newline()
        {
            CreateDataFileIfDoesNotExist();

            opcWriterCsv = new OpcWriterCsv(dataFilePath);
            opcWriterCsv.WriteSingleTag(new OpcTag("opcTagSingle", "opcValueSingle", OpcTag.OpcTagQuality.Good));
            opcWriterCsv.WriteSingleTag(new OpcTag("opcTagSingle2", "opcValueSingle2", OpcTag.OpcTagQuality.Bad));

            string expectedFileContent = "opcTagSingle;opcValueSingle;Good;192" + Environment.NewLine
                                         + "opcTagSingle2;opcValueSingle2;Bad;0";

            string actualFileContent = File.ReadAllText(dataFilePath);

            Assert.AreEqual(expectedFileContent, actualFileContent);

            DeleteDataFileIfExists();
        }

        [TestMethod]
        public void Write_Single_Tag_Overwrites_Existing_Tag_Information_In_DataFile()
        {

            CreateDataFileIfDoesNotExist();

            opcWriterCsv = new OpcWriterCsv(dataFilePath);

            opcWriterCsv.WriteSingleTag(new OpcTag("opcTagSingle", "opcValueSingle", OpcTag.OpcTagQuality.Good));
            opcWriterCsv.WriteSingleTag(new OpcTag("opcTagSingle2", "opcValueSingle2", OpcTag.OpcTagQuality.Bad));

            opcWriterCsv.WriteSingleTag(new OpcTag("opcTagSingle", "opcValue1", OpcTag.OpcTagQuality.Good));

            string expectedFileContent = "opcTagSingle;opcValue1;Good;192" + Environment.NewLine
                                         + "opcTagSingle2;opcValueSingle2;Bad;0";

            string actualFileContent = File.ReadAllText(dataFilePath);

            Assert.AreEqual(expectedFileContent, actualFileContent);

            DeleteDataFileIfExists();

        }
    }
}