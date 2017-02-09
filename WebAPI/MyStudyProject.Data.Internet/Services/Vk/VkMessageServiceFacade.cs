using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;
using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Core.Models.Results.Command;
using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Data.Contracts.Interface;
using MyStudyProject.Data.Contracts.ServiceFacades;
using MyStudyProject.Data.Internet.Assemblers.Vk;
using MyStudyProject.Data.Internet.Services.Vk.Models;
using MyStudyProject.Shared.Common.Helpers;
using MyStudyProject.Shared.Common.Settings;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyStudyProject.Data.Internet.Services.Vk
{
    public class VkMessageServiceFacade : IVkMessageFacade
    {
        private readonly IOptions<VkSettings> settings;
        private readonly ILogger<VkMessageServiceFacade> logger;

        public VkMessageServiceFacade(IOptions<VkSettings> settings, ILogger<VkMessageServiceFacade> logger)
        {
            this.settings = settings;
            this.logger = logger;
        }

        public async Task<MessagesQueryResult> GetAllAsync(string hashtag)
        {
            using (WebRequestWrapper request = new WebRequestWrapper())
            {
                VkMessageQuery query =
                    new VkMessageQuery(settings.Value.MessagesApiUrl,
                    settings.Value.ApiVersion)
                    {
                        Query = hashtag
                    };

                var json = await request.LoadJsonAsync(HttpMethod.Get, query.ToString());
                var jObject = JObject.Parse(json).SelectToken("response");
                VkNewsFeed feed = JsonConvert.DeserializeObject<VkNewsFeed>(jObject.ToString());
                VkMessageResultMapper mapper = new VkMessageResultMapper();
                return mapper.MapSingle(feed, hashtag);
            }
        }

        public async Task<ICommandResult> Save(IEnumerable<MessageCreateCommand> filtered)
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

        public async Task<MessagesQueryResult> GetNumberAsync(int number, string hashtag)
        {
            throw new NotImplementedException();
        }

        public async Task<MessagesQueryResult> GetSinceLastIdAsync(long lastId, string hashtag)
        {
            throw new NotImplementedException();
        }
    }
}
