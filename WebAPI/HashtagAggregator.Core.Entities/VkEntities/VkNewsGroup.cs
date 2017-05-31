using Newtonsoft.Json;

namespace HashtagAggregator.Core.Entities.VkEntities
{
    public class VkNewsGroup
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("screen_name")]
        public string UserName { get; set; }

        [JsonProperty("name")]
        public string FirstName { get; set; }

        [JsonProperty("photo_50")]
        public string PhotoLink50 { get; set; }
    }
}
