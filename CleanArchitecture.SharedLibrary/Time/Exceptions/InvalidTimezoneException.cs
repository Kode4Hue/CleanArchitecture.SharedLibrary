using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.SharedLibrary.Time.Exceptions
{
    public class InvalidTimezoneException : Exception
    {
        public InvalidTimezoneException(string timezoneId) : base($"Invalid timezone id. Could not identify time zone: {timezoneId}")
        {
        }
    }
}
