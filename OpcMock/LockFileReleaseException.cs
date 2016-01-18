using System;

namespace OpcMock
{
    class LockFileReleaseException : Exception
    {
        public LockFileReleaseException(string message, string lockFilePath, Exception innerException)
            : base(message, innerException)
        {
            LockFilePath = lockFilePath;
        }

        public string LockFilePath { get; }
    }
}
