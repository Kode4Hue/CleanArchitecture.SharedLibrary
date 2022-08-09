using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.SharedLibrary.Http.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
