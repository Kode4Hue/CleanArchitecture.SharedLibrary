using CleanArchitecture.SharedLibrary.Http.Exceptions;
using System.Net.Http;
using System.Threading.Tasks;

namespace CleanArchitecture.SharedLibrary.Http.Services
{
    public class BaseHttpService
    {
        protected HttpClient HttpClient;
        public BaseHttpService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public BaseHttpService(IHttpClientFactory httpClientFactory, string httpClientName)
        {
            HttpClient = httpClientFactory.CreateClient(httpClientName);
        }

        protected HttpRequestMessage GenerateHttpRequest(HttpMethod method,
          string requestUri, HttpContent? content = default(HttpContent))
        {
            return new HttpRequestMessage(method, requestUri)
            {
                Content = content
            };
        }

        protected async Task<HttpResponseMessage> MakeRequest(HttpRequestMessage request)
        {
            HttpResponseMessage responseMessage;

            responseMessage = await HttpClient.SendAsync(request);

            if (!responseMessage.IsSuccessStatusCode)
            {
                var statusCode = (int)responseMessage.StatusCode;
                throw new ApiException($"API Error occured with status code: {statusCode}",
                    statusCode, responseMessage.Content);
            }

            return responseMessage;
        }
    }
}
