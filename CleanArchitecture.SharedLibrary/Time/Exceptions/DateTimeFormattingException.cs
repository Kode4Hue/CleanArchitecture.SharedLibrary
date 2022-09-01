using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CleanArchitecture.SharedLibrary.Time.Exceptions
{
    [Serializable]
    public class DateTimeFormattingException : Exception
    {
        public DateTimeFormattingException()
        {
        }

        public DateTimeFormattingException(string message) : base(message)
        {
        }

        public DateTimeFormattingException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DateTimeFormattingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
