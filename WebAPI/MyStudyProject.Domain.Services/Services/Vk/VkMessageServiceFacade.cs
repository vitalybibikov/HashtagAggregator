using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using MyStudyProject.Core.Cqrs.Results;
using MyStudyProject.Domain.Services.Assemblers.Vk;
using MyStudyProject.Domain.Services.Services.Vk.Models;
using MyStudyProject.Shared.Common.Helpers;
using MyStudyProject.Shared.Common.Settings;

namespace MyStudyProject.Domain.Services.Services.Vk
{
    public class VkMessageServiceFacade : IVkServiceFacade
    {
        private readonly IOptions<VkSettings> settings;

        public VkMessageServiceFacade(IOptions<VkSettings> settings)
        {
            this.settings = settings;
        }

        public async Task<IEnumerable<MessageQueryResult>> GetAllAsync(string hashtag)
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
                var feed = JsonConvert.DeserializeObject<VkNewsFeed>(jObject.ToString());
                VkMessageResultMapper mapper = new VkMessageResultMapper();
                return mapper.MapBunch(feed.Feed, hashtag);
            }
        }

        public async Task<IEnumerable<MessageQueryResult>> GetNumberAsync(int number, string hashtag)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MessageQueryResult>> GetSinceLastIdAsync(long lastId, string hashtag)
        {
            throw new NotImplementedException();
        }
    }
}
