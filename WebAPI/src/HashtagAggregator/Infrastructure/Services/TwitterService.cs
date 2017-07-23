using System;
using System.Net.Http;
using System.Threading.Tasks;
using HashtagAggregator.Core.Models.Queries;
using HashtagAggregator.Infrastructure.Services.Interface;
using HashtagAggregator.Settings;
using MediatR;
using Microsoft.Extensions.Options;

namespace HashtagAggregator.Infrastructure.Services
{
    public class TwitterService : IServiceStartable
    {
        private readonly IMediator mediator;
        private readonly IServiceNotifier notifier;
        private readonly IOptions<EndpointSettings> settings;

        public TwitterService(IMediator mediator, IServiceNotifier notifier, IOptions<EndpointSettings> settings)
        {
            this.mediator = mediator;
            this.notifier = notifier;
            this.settings = settings;
        }

        public async Task Start()
        {
            var query = new HashTagParentsQuery {IsParent = true};

            var tags = await mediator.Send(query);
            foreach (var tag in tags.HashTags)
            {
                var message = new HttpRequestMessage();
                message.Method = HttpMethod.Get;
                message.RequestUri =
                    new Uri($"{settings.Value.TwitterEndpoint}/api/heartbeat/start/{tag.HashTag.NoHashTag}");
                await notifier.Send(message);
            }
        }

        public Task Stop()
        {
            throw new NotImplementedException();
        }
    }
}