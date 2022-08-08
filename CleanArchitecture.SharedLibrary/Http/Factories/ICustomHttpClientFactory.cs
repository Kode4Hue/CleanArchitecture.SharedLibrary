using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CleanArchitecture.SharedLibrary.Http.Factories
{
    public interface ICustomHttpClientFactory
    {
        HttpClient GetInstance();
    }
}
