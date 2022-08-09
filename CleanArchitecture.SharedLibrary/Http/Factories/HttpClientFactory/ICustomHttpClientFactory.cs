using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CleanArchitecture.SharedLibrary.Http.Factories.HttpClientFactory
{
    public interface ICustomHttpClientFactory
    {
        HttpClient GetInstance();
    }
}
