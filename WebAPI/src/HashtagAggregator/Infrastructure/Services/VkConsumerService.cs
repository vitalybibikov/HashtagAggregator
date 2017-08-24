using System;
using System.Net.Http;
using System.Threading.Tasks;
using HashtagAggregator.Infrastructure.Services.Interface;
using HashtagAggregator.Settings;
using Microsoft.Extensions.Options;

namespace HashtagAggregator.Infrastructure.Services
{
    public class VkConsumerService : IServiceStartable
    {
        private readonly IServiceNotifier notifier;
        private readonly IOptions<EndpointSettings> settings;
        private readonly IOptions<VkConsumeSettings> consumeSettings;

        public VkConsumerService(IServiceNotifier notifier, 
            IOptions<EndpointSettings> settings,
            IOptions<VkConsumeSettings> consumeSettings)
        {
            this.notifier = notifier;
            this.settings = settings;
            this.consumeSettings = consumeSettings;
        }

        public async Task Start()
        {
            var message = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri =
                    new Uri(
                        $"{settings.Value.ConsumerEndpoint}/api/heartbeat/start/" +
                        $"{consumeSettings.Value.QueueName}/{consumeSettings.Value.Interval}")
            };
            await notifier.Send(message);
        }

        public Task Stop()
        {
            throw new NotImplementedException();
        }
    }
}