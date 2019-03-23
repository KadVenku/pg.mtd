using System;
using System.Runtime.Serialization;

namespace pg.mtd.exceptions
{
    public class InvalidIconNameException : Exception
    {
        public InvalidIconNameException()
        {
        }

        public InvalidIconNameException(string message) : base(message)
        {
        }

        public InvalidIconNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidIconNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}