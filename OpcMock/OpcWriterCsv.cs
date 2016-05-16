using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace OpcMock
{
    public class OpcWriterCsv : OpcCsvFileHandler, OpcWriter
    {
        public OpcWriterCsv(string dataFilePath)
            : base(dataFilePath)
        {
            //void
        }

        public void WriteAllTags(List<OpcTag> opcTags)
        {
            FileStream dataFileStream = File.Open(DataFilePath, FileMode.Create);
                try
                {
                    WaitForAndAcquireFileLock();

                    ///FIXME streamWriter is not closed in finally
                    /// use "using(...) instead of try
                    StreamWriter streamWriter = new StreamWriter(dataFileStream);

                    /// PROPOSAL reverse expression and remove if
                    if (opcTags.Count > 0)
                    {
                        /// PROPOSAL extract method to get the same level of abstraction
                        foreach (OpcTag o in opcTags)
                        {
                            streamWriter.WriteLine(o.Path + ';'
                                                   + o.Value + ';'
                                                   + o.Quality.ToString() + ';'
                                                   + ((int)o.Quality).ToString()
                                );
                        }
                    }

                    streamWriter.Flush();
                }
                catch (LockFileAcquisitionException)
                {
                ///PROPOSAL either use a default or (better in this case) re-throw
                ///up to the top layer and display something to the user.
                ///Keep the stack/exception trace
                    System.Console.WriteLine("Locking failed");
                }
                catch (Exception)
                {
                    ///FIXME put logging or re-throw
                }
                finally
                {
                    dataFileStream.Close();
                    ReleaseFileLock();
                }
        }

        public void WriteSingleTag(OpcTag opcTag)
        {
            try
            {
                WaitForAndAcquireFileLock();

                bool tagUpdated = false;
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
                System.Console.WriteLine("Locking failed");
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
