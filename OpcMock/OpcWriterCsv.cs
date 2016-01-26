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

                StreamWriter streamWriter = new StreamWriter(dataFileStream);

                if (opcTags.Count > 0)
                {
                    foreach (OpcTag o in opcTags)
                    {
                        streamWriter.WriteLine(o.Path + ';'
                                               + o.Value + ';'
                                               + o.Quality.ToString() + ';'
                                               + ((int) o.Quality).ToString()
                            );
                    }
                }

                streamWriter.Flush();
            }
            catch (LockFileAcquisitionException exLock)
            {
                System.Console.WriteLine("Locking failed");
            }
            catch (Exception)
            {
                //void
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

                if (opcTagFileContent.Count == 0)
                {
                    opcTagFileContent.Add(opcTagLine);
                }
                else
                {
                    for (int i = 0; i < opcTagFileContent.Count; i++)
                    {
                        if (opcTagFileContent[i].StartsWith(opcTag.Path))
                        {
                            opcTagFileContent[i] = opcTagLine;
                            tagUpdated = true;
                            break;
                        }
                    }

                    if (!tagUpdated)
                    {
                        opcTagFileContent.Add(opcTagLine);
                    }
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
    }
}
