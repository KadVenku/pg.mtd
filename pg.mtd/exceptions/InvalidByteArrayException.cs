using System;
using System.Runtime.Serialization;

namespace pg.mtd.exceptions
{
    public class InvalidByteArrayException : Exception
    {
        public InvalidByteArrayException()
        {
        }

        public InvalidByteArrayException(string message) : base(message)
        {
        }

        public InvalidByteArrayException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidByteArrayException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}