using Newtonsoft.Json;

namespace HashtagAggregator.Core.Entities.VkEntities
{
    public class VkNewsSearchResult
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "owner_id")]
        public long OwnerId { get; set; }

        [JsonProperty(PropertyName = "from_id")]
        public long FromId { get; set; }

        [JsonProperty(PropertyName = "date")]
        public long UnixTimeStamp { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}