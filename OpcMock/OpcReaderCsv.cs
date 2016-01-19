using System;
using System.Collections.Generic;
using System.IO;

namespace OpcMock
{
    class OpcReaderCsv : OpcCsvFileHandler, OpcReader
    {
        private readonly List<OpcTag> tagList;

        /// <summary>
        /// Creates a new reader related to the given filePath
        /// </summary>
        /// <param name="dataFilePath">Full path to the .csv file</param>
        /// <param name="lockFilePath">Full path to the .lck file</param>
        /// <exception cref="FileNotFoundException"></exception>
        public OpcReaderCsv(string dataFilePath, string lockFilePath)
            : base(dataFilePath, lockFilePath)
        {
            tagList = new List<OpcTag>();
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
            try
            {
                string[] opcLines = File.ReadAllLines(dataFilePath);
                tagList.Clear();

                foreach (string s in opcLines)
                {
                    if (string.IsNullOrWhiteSpace(s)) continue;

                    string[] splitLine = s.Split(';');

                    OpcTag.OpcTagQuality qualityFromInt = (OpcTag.OpcTagQuality)Convert.ToInt32(splitLine[3]);

                    tagList.Add(new OpcTag(splitLine[0], splitLine[1], qualityFromInt));
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
            
        }
    }
}
