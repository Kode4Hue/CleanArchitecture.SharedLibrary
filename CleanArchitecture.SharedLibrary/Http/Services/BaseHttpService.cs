using System.Net.Http;

namespace CleanArchitecture.SharedLibrary.Http.Services
{
    public abstract class BaseHttpService
    {
        protected readonly HttpClient HttpClient;
        public BaseHttpService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }
    }
}
