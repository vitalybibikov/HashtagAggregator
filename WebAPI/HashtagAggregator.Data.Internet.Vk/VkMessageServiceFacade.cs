using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Query;
using HashtagAggregator.Core.Contracts.Interface.DataSources;
using HashtagAggregator.Core.Entities.VkEntities;
using HashtagAggregator.Data.Internet.Vk.Assemblers;
using HashtagAggregator.Shared.Common.Helpers;
using HashtagAggregator.Shared.Common.Infrastructure;
using HashtagAggregator.Shared.Common.Settings;
using HashtagAggregator.Shared.Logging;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HashtagAggregator.Data.Internet.Vk
{
    public class VkMessageServiceFacade : IVkMessageFacade
    {
        private readonly IOptions<VkSettings> settings;
        private readonly IOptions<VkAuthSettings> authVkSettings;
        private readonly ILogger<VkMessageServiceFacade> logger;

        public VkMessageServiceFacade(IOptions<VkSettings> settings, IOptions<VkAuthSettings> authVkSettings, ILogger<VkMessageServiceFacade> logger)
        {
            this.settings = settings;
            this.authVkSettings = authVkSettings;
            this.logger = logger;
        }

        public async Task<IQueryResult> GetAllAsync(HashTagWord hashtag)
        {
            using (var request = new WebRequestWrapper())
            {
                var query =
                    new VkMessageQuery(settings.Value.MessagesApiUrl,
                    settings.Value.ApiVersion,
                    authVkSettings.Value.ServiceToken)
                    {
                        Query = hashtag.ToString()
                    };

                var json = await request.LoadJsonAsync(HttpMethod.Get, query.ToString());
                var jObject = JObject.Parse(json).SelectToken("response").ToString();

                if (String.IsNullOrEmpty(jObject))
                {
                    logger.LogError(
                        LoggingEvents.EXCEPTION_GET_TWITTER_MESSAGE,
                        "Failed to get messages by {hashtag} with {error}",
                        hashtag,
                        jObject);
                    throw new InvalidDataException(jObject);
                }

                var feed = JsonConvert.DeserializeObject<VkNewsFeed>(jObject);
                var mapper = new VkMessageResultMapper();
                return mapper.MapSingle(feed, hashtag);
            }
        }

        public async Task<ICommandResult> Save(IEnumerable<ICommand> filtered)
        {
            //todo: refactor
            throw new NotImplementedException();
            //try
            //{
            //    var seconds = 1;
            //    foreach (var command in filtered)
            //    {
            //        BackgroundJob.Schedule<IVkBackgroundJob<MessageCreateCommand>>(
            //            x => x.Publish(command),
            //            TimeSpan.FromSeconds(seconds));
            //        seconds += settings.Value.VkMessagePublishDelay;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
            //return new CommandResult { Success = true };
        }
    }
}
