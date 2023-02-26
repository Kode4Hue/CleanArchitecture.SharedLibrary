using System;

namespace CleanArchitecture.SharedLibrary.Http.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
