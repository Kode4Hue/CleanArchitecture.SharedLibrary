using System;

namespace CleanArchitecture.SharedLibrary.Security.Exceptions;

public class ForbiddenAccessException : Exception
{
    public ForbiddenAccessException() : base() { }
}