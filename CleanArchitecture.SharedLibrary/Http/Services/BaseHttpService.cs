using CleanArchitecture.SharedLibrary.Http.Exceptions;
using CleanArchitecture.SharedLibrary.Http.Factories.HttpClientFactory;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CleanArchitecture.SharedLibrary.Http.Services
{
    public class BaseHttpService
    {
        protected HttpClient HttpClient;
        public BaseHttpService(ICustomHttpClientFactory httpClientFactory)
        {
            HttpClient = httpClientFactory.GetInstance();
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

        protected async Task<HttpResponseMessage> MakeRequest(HttpRequestMessage request)
        {
            HttpResponseMessage responseMessage;
            responseMessage = await HttpClient.SendAsync(request);
            return responseMessage;
        }
    }
}
