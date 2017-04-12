using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HashtagAggregator.Shared.Common.Helpers
{
    public class WebRequestWrapper : IDisposable
    {
        private readonly int timeout;
        private readonly string contentType;
        private const int TimeOut = 30000;
        private const string ContentType = "application/json";

        public WebRequestWrapper(int timeout = TimeOut, string contentType = ContentType)
        {
            this.timeout = timeout;
            this.contentType = contentType;
        }

        public HttpClient Client => new HttpClient();

        public async Task<string> LoadJsonAsync(HttpMethod method, string url)
        {
            HttpRequestMessage message = new HttpRequestMessage();
            try
            {
                message.Method = method;
                message.RequestUri = new Uri(url);

                Client.DefaultRequestHeaders
                    .Accept
                        .Add(new MediaTypeWithQualityHeaderValue(contentType));
                Client.Timeout = TimeSpan.FromMilliseconds(timeout);
                var response = await Client.SendAsync(message);
                return await response.Content.ReadAsStringAsync();
            }
            finally
            {
                message.Dispose();
            }
        }

        public void Dispose()
        {
            Client?.Dispose();
        }
    }
}
