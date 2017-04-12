using Newtonsoft.Json;

namespace HashtagAggregator.Core.Entities.VkEntities
{
    public class VkNewsProfile
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("screen_name")]
        public string UserName { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("photo_50")]
        public string PhotoLink50 { get; set; }
    }
}
