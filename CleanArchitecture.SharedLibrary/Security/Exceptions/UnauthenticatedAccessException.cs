using System;

namespace CleanArchitecture.SharedLibrary.Security.Exceptions
{

    [Serializable]
    public class UnauthenticatedAccessException : Exception
    {
        public UnauthenticatedAccessException() : base() { }
    }
}
