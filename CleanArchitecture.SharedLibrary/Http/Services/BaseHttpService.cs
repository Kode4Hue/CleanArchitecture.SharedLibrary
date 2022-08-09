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
            try
            {
                responseMessage = await HttpClient.SendAsync(request);

                if (!responseMessage.IsSuccessStatusCode)
                {
                    var statusCode = (int)responseMessage.StatusCode;
                    throw new ApiException($"API Error occured with status code: {statusCode}",
                        statusCode, responseMessage.Content);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured before sending API request", ex);
            }

            return responseMessage;
        }
    }
}
