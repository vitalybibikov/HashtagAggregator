using System.Net.Http;
using System.Threading.Tasks;
using HashtagAggregator.Infrastructure.Services.Interface;

namespace HashtagAggregator.Infrastructure
{
    public class ServiceNotifier : IServiceNotifier
    {
        public async Task Send(HttpRequestMessage httpRequestMessage)
        {
            using (var client = new HttpClient())
            {
                await client.SendAsync(httpRequestMessage);
            }
        }
    }
}