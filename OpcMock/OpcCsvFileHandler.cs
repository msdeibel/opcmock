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

        protected string LockFilePath { get; }
        protected int MaxLockAcquisitionRetries { get; }

        public string DataFilePath { get; }

        protected OpcCsvFileHandler() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataFilePath"></param>
        /// <exception cref="ArgumentException">In case dataFilePath ends with a wrong file extension</exception>
        /// <exception cref="FileNotFoundException">In case the dataFilePath does not exist</exception>
        public OpcCsvFileHandler(string dataFilePath)
        {
            CheckDataFilenameExtension(dataFilePath);

            CheckDataFileExistence(dataFilePath);

            DataFilePath = dataFilePath;
            LockFilePath = dataFilePath.Replace(FileExtensionContants.FileExtensionData, FileExtensionContants.FileExtensionLock);
            MaxLockAcquisitionRetries = LockAcquisitionDefaultMaxRetries;
        }

        private static void CheckDataFileExistence(string dataFilePath)
        {
            if (!File.Exists(dataFilePath))
            {
                throw new FileNotFoundException("File does not exist.", dataFilePath);
            }
        }

        private void CheckDataFilenameExtension(string dataFilePath)
        {
            if (!dataFilePath.EndsWith(FileExtensionContants.FileExtensionData))
            {
                throw new ArgumentException("Data filename must have extension '" + FileExtensionContants.FileExtensionData + "'", paramName: dataFilePath);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataFilePath"></param>
        /// <param name="lockFilePath"></param>
        /// <param name="maxLockAcquisitionRetries">If &lt;= 0, LOCK_ACQUISITION_DEFAULT_MAX_RETRIES is used instead</param>
        public OpcCsvFileHandler(string dataFilePath, int maxLockAcquisitionRetries)
            :this(dataFilePath)
        {
            MaxLockAcquisitionRetries = maxLockAcquisitionRetries > 0 ? maxLockAcquisitionRetries : LockAcquisitionDefaultMaxRetries;
        }

        /// <summary>
        /// Checks to see if the lock file already exists. If not creates it.
        /// </summary>
        /// <exception cref="LockFileAcquisitionException"></exception>
        protected void WaitForAndAcquireFileLock()
        {
            bool lockAcquired = false;
            int retryCounter = 0;

            while (!lockAcquired
                    && retryCounter < MaxLockAcquisitionRetries)
            {
                try
                {
                    File.Create(LockFilePath).Close();

                    lockAcquired = true;
                }
                catch (Exception)
                {
                    Thread.Sleep(LockAcquisitionRetryIntervallInMs);
                }
            }

            if (!lockAcquired)
            {
                throw new LockFileAcquisitionException("Lockfile acquisition retries reached the maximum of " + MaxLockAcquisitionRetries, LockFilePath);
            }
        }

        /// <summary>
        /// Releases the lock by deleting the lockfile
        /// </summary>
        /// /// <exception cref="LockFileReleaseException"></exception>
        protected void ReleaseFileLock()
        {
            try
            {
                if (File.Exists(LockFilePath))
                {
                    File.Delete(LockFilePath);
                }
            }
            catch (Exception ex)
            {
                throw new LockFileReleaseException("An error occured while trying to remove a lock file.", LockFilePath, ex);
            }
        }
    }
}
