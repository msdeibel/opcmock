using System;

namespace OpcMock
{
    class OpcReadingException : Exception
    {
        public OpcReadingException(string message)
            : base(message)
        {
            //void
        }

        public OpcReadingException(string message, Exception innerException)
            : base(message, innerException)
        { 
            //void
        }
    }
}
