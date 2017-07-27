using System.Net.Http;
using System.Threading.Tasks;
using HashtagAggregator.Infrastructure.Services.Interface;
using Microsoft.Extensions.Logging;

namespace HashtagAggregator.Infrastructure
{
    public class ServiceNotifier : IServiceNotifier
    {
        private readonly ILogger<ServiceNotifier> logger;

        public ServiceNotifier(ILogger<ServiceNotifier> logger)
        {
            this.logger = logger;
        }

        public async Task Send(HttpRequestMessage httpRequestMessage)
        {
            using (var client = new HttpClient())
            {
                logger.LogInformation("Send request to: ", httpRequestMessage);
                await client.SendAsync(httpRequestMessage);
            }
        }
    }
}