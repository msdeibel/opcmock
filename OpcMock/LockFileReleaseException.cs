using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpcMock
{
    class LockFileReleaseException : Exception
    {
        private string lockFilePath;

        public LockFileReleaseException(string message, string lockFilePath, Exception innerException)
            : base(message, innerException)
        {
            this.lockFilePath = lockFilePath;
        }

        public string LockFilePath
        {
            get
            {
                return this.lockFilePath;
            }
        }
    }
}
