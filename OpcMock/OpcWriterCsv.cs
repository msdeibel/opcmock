using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace OpcMock
{
    public class OpcWriterCsv : OpcCsvFileHandler, OpcWriter
    {
        private OpcWriterCsv() { }

        public OpcWriterCsv(string dataFilePath, string lockFilePath)
            : base(dataFilePath, lockFilePath)
        {
            //void
        }

        public void WriteAllTags(List<OpcTag> opcTags)
        {
            WaitForAndAcquireFileLock();

            FileStream dataFileStream = File.Open(dataFilePath, FileMode.Create);

            StreamWriter streamWriter = new StreamWriter(dataFileStream);

            try
            {
                if (opcTags.Count > 0)
                {
                    foreach (OpcTag o in opcTags)
                    {
                        streamWriter.WriteLine(o.TagPath + ';'
                                                + o.Value + ';'
                                                + o.Quality.ToString() + ';'
                                                + ((int)(o.Quality)).ToString()
                                                );
                    }
                }

                streamWriter.Flush();
                streamWriter.Close();
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
    }
}
