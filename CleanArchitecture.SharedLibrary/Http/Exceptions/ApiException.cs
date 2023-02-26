using System;
using System.Net.Http;

namespace CleanArchitecture.SharedLibrary.Http.Exceptions
{
    [Serializable]
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message)
        {
        }

        public ApiException(string message, int statusCode, HttpContent content) : base(message)
        {
            StatusCode = statusCode;
            Content = content;
        }
        public int? StatusCode { get; set; }
        public HttpContent? Content { get; set; }
    }
}
