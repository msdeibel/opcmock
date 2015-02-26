using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace OpcMock
{
    class OpcReaderCsv : OpcReader
    {
        private int LOCK_ACQUISITION_RETRY_INTERVALL_IN_MS = 500;

        private string dataFilePath;
        private string lockFilePath;
        private List<OpcTag> tagList;

        /// <summary>
        /// Creates a new reader related to the given filePath
        /// </summary>
        /// <param name="dataFilePath">Full path to the .csv file</param>
        /// <exception cref="FileNotFoundException"></exception>
        public OpcReaderCsv(string dataFilePath, string lockFilePath)
        {
            if (!File.Exists(dataFilePath))
            {
                throw new FileNotFoundException("File does not exist.", dataFilePath);
            }

            if (string.IsNullOrWhiteSpace(lockFilePath))
            {
                throw new System.ArgumentException("Parameter does not contain a valid file system path.", lockFilePath);
            }
                        
            this.dataFilePath = dataFilePath;
            this.lockFilePath = lockFilePath;
            this.tagList = new List<OpcTag>();
        }

        public OpcTag ReadTag(string tagPath)
        {
            SetTagListFromCsvData();

            foreach (OpcTag o in tagList)
            {
                if (o.TagPath.Equals(tagPath))
                {
                    return o;
                }
            }

            return new OpcTag(tagPath, string.Empty);
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

        private void WaitForAndAcquireFileLock()
        {
            bool lockAcquired = false;

            while (!lockAcquired)
            {
                try
                {
                    File.Create(lockFilePath).Close();

                    lockAcquired = true;
                }
                catch (Exception)
                {
                    Thread.Sleep(LOCK_ACQUISITION_RETRY_INTERVALL_IN_MS);
                }
            }
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

        private void ReleaseFileLock()
        {
            File.Delete(lockFilePath);
        }
    }
}
