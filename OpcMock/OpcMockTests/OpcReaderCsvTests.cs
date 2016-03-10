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
    public class OpcReaderCsvTests : OpcMockTestsBase
    {
        private OpcReaderCsv opcReaderCsv;

        [TestInitialize]
        public void TestInitialize()
        {
            dataFilePath = TestContext.TestDir + "\\testdatafile" + FileExtensionContants.FileExtensionData;
        }

        [TestMethod()]
        public void Read_All_Tags_Gets_All_Lines_From_File()
        {
            CreateDataFileIfDoesNotExist();

            string verbatimFileContent = "opcTagPath3;opcTagValue3;Bad;0" + Environment.NewLine
                                            + Environment.NewLine
                                            + "opcTagPath2;opcTagValue2;Good;192" + Environment.NewLine
                                            + " \t" + Environment.NewLine
                                            + "opcTagPath1;opcTagValue1;Unknown;8" + Environment.NewLine;

            File.WriteAllText(dataFilePath, verbatimFileContent);

            List<OpcTag> expectedResult = new List<OpcTag>();
            expectedResult.Add(new OpcTag("opcTagPath3", "opcTagValue3", OpcTag.OpcTagQuality.Bad));
            expectedResult.Add(new OpcTag("opcTagPath2", "opcTagValue2", OpcTag.OpcTagQuality.Good));
            expectedResult.Add(new OpcTag("opcTagPath1", "opcTagValue1", OpcTag.OpcTagQuality.Unknown));

            opcReaderCsv = new OpcReaderCsv(dataFilePath);

            List<OpcTag> actualResult = opcReaderCsv.ReadAllTags();

            CollectionAssert.AreEqual(expectedResult, actualResult);

            DeleteDataFileIfExists();
        }

        [TestMethod()]
        public void Read_All_Tags_Skips_Empty_Lines()
        {
            CreateDataFileIfDoesNotExist();

            List<OpcTag> expectedResult = new List<OpcTag>();
            expectedResult.Add(new OpcTag("opcTagPath3", "opcTagValue3", OpcTag.OpcTagQuality.Bad));
            expectedResult.Add(new OpcTag("opcTagPath2", "opcTagValue2", OpcTag.OpcTagQuality.Good));
            expectedResult.Add(new OpcTag("opcTagPath1", "opcTagValue1", OpcTag.OpcTagQuality.Unknown));

            OpcWriterCsv opcWriterCsv = new OpcWriterCsv(dataFilePath);
            opcWriterCsv.WriteAllTags(expectedResult);

            opcReaderCsv = new OpcReaderCsv(dataFilePath);

            List<OpcTag> actualResult = opcReaderCsv.ReadAllTags();

            CollectionAssert.AreEqual(expectedResult, actualResult);

            DeleteDataFileIfExists();
        }
    }
}