using System.Net.Http;

namespace CleanArchitecture.SharedLibrary.Http.Factories.HttpClientFactory
{
    public interface ICustomHttpClientFactory
    {
        HttpClient GetInstance();
    }
}
