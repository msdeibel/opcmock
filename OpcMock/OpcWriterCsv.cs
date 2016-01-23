using System;
using System.Collections.Generic;
using System.IO;


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

                string opcTagFileContent = File.ReadAllText(DataFilePath);

                opcTagFileContent += '\n'+ opcTag.Path + ';'
                                     + opcTag.Value + ';'
                                     + opcTag.Quality.ToString() + ';'
                                     + ((int) opcTag.Quality).ToString();

                File.WriteAllText(DataFilePath, opcTagFileContent);
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
