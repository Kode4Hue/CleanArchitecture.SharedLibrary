using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.SharedLibrary.Time.Exceptions
{
    public class DateTimeKindIsNotUtcException : Exception
    {
        public DateTimeKindIsNotUtcException(string message) : base(message)
        {
        }
    }
}
