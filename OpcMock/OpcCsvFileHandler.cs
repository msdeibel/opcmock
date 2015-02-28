using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace OpcMock
{
    public abstract class OpcCsvFileHandler
    {
        protected const int LOCK_ACQUISITION_RETRY_INTERVALL_IN_MS = 500;

        protected string dataFilePath;
        protected string lockFilePath;

        protected OpcCsvFileHandler() { }

        public OpcCsvFileHandler(string dataFilePath, string lockFilePath)
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
        }

        protected void WaitForAndAcquireFileLock()
        {
            bool lockAcquired = false;

            ///FIXME: Infinite loop needs exit strategy
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

        protected void ReleaseFileLock()
        {
            if (File.Exists(lockFilePath))
            {
                File.Delete(lockFilePath);
            }
        }
    }
}
