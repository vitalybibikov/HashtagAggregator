using System;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;
using MyStudyProject.Core.Models.Results.Query;
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

        public VkMessageServiceFacade(IOptions<VkSettings> settings)
        {
            this.settings = settings;
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
                var feed = JsonConvert.DeserializeObject<VkNewsFeed>(jObject.ToString());
                VkMessageResultMapper mapper = new VkMessageResultMapper();
                return mapper.MapBunch(feed.Feed, hashtag);
            }
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
