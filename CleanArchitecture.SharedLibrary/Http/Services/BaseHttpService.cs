using CleanArchitecture.SharedLibrary.Http.Factories.HttpClientFactory;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.SharedLibrary.Http.Services
{
    public abstract class BaseHttpService
    {
        protected readonly HttpClient HttpClient;
        public BaseHttpService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        protected HttpRequestMessage GenerateHttpRequest(HttpMethod method,
            string requestUri, HttpContent? content = null)
        {

            var httpRequestMessage = new HttpRequestMessage(method, requestUri);

            if (content is not null)
            {
                httpRequestMessage.Content = content;
            }

            return httpRequestMessage;
        }

        protected async Task<HttpResponseMessage> MakeRequest(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage;
            responseMessage = await HttpClient.SendAsync(request, cancellationToken: cancellationToken);
            return responseMessage;
        }
    }
}
