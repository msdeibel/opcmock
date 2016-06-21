using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpcMock
{
    public class OpcWriterCsv : OpcCsvFileHandler, OpcWriter
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        public OpcWriterCsv(string dataFilePath)
            : base(dataFilePath)
        {
            //void
        }

        /// <summary>
        /// Writes all tags to the data file
        /// </summary>
        /// <param name="opcTags"></param>
        /// <exception cref="LockFileAcquisitionException"></exception>
        /// <exception cref="Exception"></exception>
        public void WriteAllTags(List<OpcTag> opcTags)
        {
            StreamWriter streamWriter = new StreamWriter(DataFilePath, false);

            try
            {
                WaitForAndAcquireFileLock();

                WriteTagsToFile(opcTags, ref streamWriter);
            }
            catch (LockFileAcquisitionException exLock)
            {
                logger.Error("Locking of data file failed", exLock);

                throw;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message, new object[] { });

                throw;
            }
            finally
            {
                streamWriter.Close();
                ReleaseFileLock();
            }
        }

        private static void WriteTagsToFile(List<OpcTag> opcTags, ref StreamWriter streamWriter)
        {
            foreach (OpcTag o in opcTags)
            {
                streamWriter.WriteLine(o.Path + ';'
                                        + o.Value + ';'
                                        + o.Quality.ToString() + ';'
                                        + ((int)o.Quality).ToString()
                    );
            }

            streamWriter.Flush();
        }

        public void WriteSingleTag(OpcTag opcTag)
        {
            try
            {
                WaitForAndAcquireFileLock();

                //bool tagUpdated = false;
                string opcTagLine = opcTag.Path + ';'
                                     + opcTag.Value + ';'
                                     + opcTag.Quality.ToString() + ';'
                                     + ((int)opcTag.Quality).ToString();

                List<string> opcTagFileContent = File.ReadAllLines(DataFilePath).ToList();

                int tagPostionInFile = FileContentContainsTag(opcTagFileContent, opcTag.Path);

                if (IsFileEmpty(opcTagFileContent)
                    || TagNotInFile(tagPostionInFile))
                {
                    opcTagFileContent.Add(opcTagLine);
                }
                else
                {
                    opcTagFileContent[tagPostionInFile] = opcTagLine;
                }

                File.WriteAllText(DataFilePath, string.Join(Environment.NewLine, opcTagFileContent.ToArray()));
            }
            catch (LockFileAcquisitionException exLock)
            {
                logger.Error("Locking of data file failed", exLock);

                throw;
            }
            finally
            {
                ReleaseFileLock();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="opcTagFileContent"></param>
        /// <param name="tagPath"></param>
        /// <returns>Index of the line that contains the tag; -1 if tag is not found</returns>
        private int FileContentContainsTag(List<string> opcTagFileContent, string tagPath)
        {
            int positionInFile = -1;

            for (int i = 0; i < opcTagFileContent.Count; i++)
            {
                if (opcTagFileContent[i].StartsWith(tagPath))
                {
                    return i;
                }
            }

            return positionInFile;
        }

        private static bool TagNotInFile(int tagPostionInFile)
        {
            return tagPostionInFile == -1;
        }

        private static bool IsFileEmpty(List<string> opcTagFileContent)
        {
            return opcTagFileContent.Count == 0;
        }
    }
}
