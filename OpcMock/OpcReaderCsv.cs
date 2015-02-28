using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace OpcMock
{
    class OpcReaderCsv : OpcCsvFileHandler, OpcReader
    {
        private List<OpcTag> tagList;

        private OpcReaderCsv() { }

        /// <summary>
        /// Creates a new reader related to the given filePath
        /// </summary>
        /// <param name="dataFilePath">Full path to the .csv file</param>
        /// <exception cref="FileNotFoundException"></exception>
        public OpcReaderCsv(string dataFilePath, string lockFilePath)
            : base(dataFilePath, lockFilePath)
        {
            this.tagList = new List<OpcTag>();
        }

        public List<OpcTag> ReadAllTags()
        {
            try
            {
                WaitForAndAcquireFileLock();

                SetTagListFromCsvData();
            }
            catch (Exception ex)
            {
                tagList.Clear();

                throw new OpcReadingException("Error while reading OPC data from file " + dataFilePath, ex);
            }
            finally
            {
                ReleaseFileLock();
            }

            return tagList;
        }

        private void SetTagListFromCsvData()
        {
            string[] opcLines = File.ReadAllLines(dataFilePath);
            string[] splitLine;
            tagList.Clear();

            foreach (string s in opcLines)
            {
                splitLine = s.Split(';');

                OpcTag.OpcTagQuality qualityFromInt = (OpcTag.OpcTagQuality)(Convert.ToInt32(splitLine[3]));

                tagList.Add(new OpcTag(splitLine[0], splitLine[1], qualityFromInt));
            }
        }
    }
}
