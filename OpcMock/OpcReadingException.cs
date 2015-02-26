using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
