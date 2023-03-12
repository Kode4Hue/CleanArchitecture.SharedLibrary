using CleanArchitecture.SharedLibrary.Common.Constants;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.SharedLibrary.Http.Helpers.Network
{
    public static class HttpClientContentHelper
    {

        public static StringContent CreateRequestPayloadAsStringContent<T>(T type) where T:class
        {
            string payload = SerializeFromObject(type);
            return new StringContent(payload, Encoding.UTF8, MimeTypes.Application.Json);
        }

        public async static Task<T> DeserializeObjectFromHttpContent<T>(HttpContent content) where T:class
        {
            using (var stream = await content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            {
                string textContent = GetStringContentFromStreamReader(reader);
                return DeserializeObjectFromString<T>(textContent);
            }
        }

        public async static Task<string> ReadStringFromHttpContent(HttpContent content)
        {
            using (var stream = await content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            {
                return GetStringContentFromStreamReader(reader);
            }
        }
        private static T DeserializeObjectFromString<T>(string textContent) where T:class
        {
            if (string.IsNullOrEmpty(textContent))
            {
                throw new ArgumentNullException(nameof(textContent));
            }

            var deserializedContent = JsonConvert.DeserializeObject<T>(textContent);

            if (deserializedContent is null)
            {
                throw new Exception("Error: Could not deserialize content");
            }

            return deserializedContent;
        }

        private static string GetStringContentFromStreamReader(StreamReader reader)
        {
            return reader.ReadToEnd();
        }

        private static string SerializeFromObject<T>(T type) where T: class
        {
            return JsonConvert.SerializeObject(type);
        }
    }
}
