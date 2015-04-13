using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpcMock
{
    class LockFileAcquisitionException : Exception
    {
        private string lockFilePath;

        public LockFileAcquisitionException(string message, string lockFilePath)
            : base(message)
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
