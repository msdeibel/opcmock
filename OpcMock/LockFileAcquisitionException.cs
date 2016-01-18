using System;

namespace OpcMock
{
    class LockFileAcquisitionException : Exception
    {
        public LockFileAcquisitionException(string message, string lockFilePath)
            : base(message)
        {
            LockFilePath = lockFilePath;
        }

        public string LockFilePath { get; }
    }
}
