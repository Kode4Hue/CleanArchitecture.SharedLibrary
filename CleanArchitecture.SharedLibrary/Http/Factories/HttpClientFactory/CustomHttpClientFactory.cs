using CleanArchitecture.SharedLibrary.Common.Constants;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CleanArchitecture.SharedLibrary.Http.Factories.HttpClientFactory
{
    public class CustomHttpClientFactory : ICustomHttpClientFactory
    {
        private HttpClient? _httpClient;

        public HttpClient GetInstance()
        {
            if (_httpClient is null)
            {
                _httpClient = GenerateHttpClient();
            }

            return _httpClient;
        }

        private WebProxy GenerateWebProxy(string httpProxyAddess, int httpPort)
        {
            return new WebProxy(httpProxyAddess, httpPort)
            {
                BypassProxyOnLocal = true
            };
        }

        private HttpClient GenerateHttpClient(bool useWebProxy = false, string? httpProxyAddress = default, int? proxyPort = default)
        {
            HttpClient client;

            if (useWebProxy)
            {

                if (string.IsNullOrEmpty(httpProxyAddress))
                {
                    throw new ArgumentNullException(nameof(httpProxyAddress));
                }

                if (!proxyPort.HasValue)
                {
                    throw new ArgumentNullException(nameof(proxyPort));
                }

                client = GenerateWebProxyClient(httpProxyAddress, proxyPort.Value);
            }
            else
            {
                client = new HttpClient();
            }

            ConfigureHttpClient(client);

            return client;
        }

        private void ConfigureHttpClient(HttpClient client)
        {
            string contentType = MimeTypes.Application.Json;
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue(contentType));
        }

        private HttpClient GenerateWebProxyClient(string httpProxyAddress, int proxyPort)
        {
            var webProxy = GenerateWebProxy(httpProxyAddress, proxyPort);
            var httpClientHandler = new HttpClientHandler()
            {
                Proxy = webProxy,
                UseProxy = true
            };

            return new HttpClient(httpClientHandler);
        }
    }
}
