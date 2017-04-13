using Newtonsoft.Json;

namespace HashtagAggregator.ViewModels
{
    public class HashtagViewModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("parentId")]
        public long? ParentId { get; set; }

        [JsonProperty("isEnabled")]
        public string IsEnabled { get; set; }

        [JsonProperty("hashTag")]
        public string HashTag { get; set; }
    }
}
