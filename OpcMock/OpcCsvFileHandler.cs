using System;
using System.IO;
using System.Threading;
using OpcMock.Properties;

namespace OpcMock
{
    public class OpcCsvFileHandler
    {
        protected const int LockAcquisitionRetryIntervallInMs = 500;
        protected const int LockAcquisitionDefaultMaxRetries = 5;

        protected string dataFilePath;
        protected string lockFilePath;
        protected int maxLockAcquisitionRetries;

        protected OpcCsvFileHandler() { }

        public OpcCsvFileHandler(string dataFilePath, string lockFilePath)
        {
            if (!File.Exists(dataFilePath))
            {
                throw new FileNotFoundException("File does not exist.", dataFilePath);
            }

            if (string.IsNullOrWhiteSpace(lockFilePath))
            {
                throw new ArgumentException(Resources.OpcCsvFileHandler_OpcCsvFileHandler_Parameter_does_not_contain_a_valid_file_system_path_, lockFilePath);
            }

            this.dataFilePath = dataFilePath;
            this.lockFilePath = lockFilePath;
            this.maxLockAcquisitionRetries = LockAcquisitionDefaultMaxRetries;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataFilePath"></param>
        /// <param name="lockFilePath"></param>
        /// <param name="maxLockAcquisitionRetries">If &lt;= 0, LOCK_ACQUISITION_DEFAULT_MAX_RETRIES is used instead</param>
        public OpcCsvFileHandler(string dataFilePath, string lockFilePath, int maxLockAcquisitionRetries)
            :this(dataFilePath, lockFilePath)
        {
            this.maxLockAcquisitionRetries = maxLockAcquisitionRetries > 0 ? maxLockAcquisitionRetries : LockAcquisitionDefaultMaxRetries;
        }

        /// <summary>
        /// Checks to see if the lock file already exists. If not creates it.
        /// </summary>
        /// <exception cref="OpcMock.LockFileAcquisitionException"></exception>
        protected void WaitForAndAcquireFileLock()
        {
            bool lockAcquired = false;
            int retryCounter = 0;

            while (!lockAcquired
                    && retryCounter < maxLockAcquisitionRetries)
            {
                try
                {
                    File.Create(lockFilePath).Close();

                    lockAcquired = true;
                }
                catch (Exception)
                {
                    Thread.Sleep(LockAcquisitionRetryIntervallInMs);
                }
            }

            if (!lockAcquired)
            {
                throw new LockFileAcquisitionException("Lockfile acquisition retries reached the maximum of " + maxLockAcquisitionRetries, lockFilePath);
            }
        }

        /// <summary>
        /// Releases the lock by deleting the lockfile
        /// </summary>
        /// /// <exception cref="OpcMock.LockFileReleaseException"></exception>
        protected void ReleaseFileLock()
        {
            try
            {
                if (File.Exists(lockFilePath))
                {
                    File.Delete(lockFilePath);
                }
            }
            catch (Exception ex)
            {
                throw new LockFileReleaseException("An error occured while trying to remove a lock file.", lockFilePath, ex);
            }
        }
    }
}
