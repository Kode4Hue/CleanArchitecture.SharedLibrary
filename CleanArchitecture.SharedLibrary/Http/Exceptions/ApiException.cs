using System;
using System.Net;
using System.Net.Http;

namespace CleanArchitecture.SharedLibrary.Http.Exceptions
{
    [Serializable]
    public class ApiException : Exception
    {

        public ApiException(string message, HttpStatusCode statusCode, HttpContent content) : base(message)
        {
            StatusCode = statusCode;
            Content = content;
        }
        public HttpStatusCode? StatusCode { get; set; }
        public HttpContent? Content { get; set; }
    }
}
