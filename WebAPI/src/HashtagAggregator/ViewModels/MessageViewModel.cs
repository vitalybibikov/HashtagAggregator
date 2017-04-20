using System;
using System.Collections.Generic;
using HashtagAggregator.Shared.Contracts.Enums;
using Newtonsoft.Json;

namespace HashtagAggregator.ViewModels
{
    public class MessageViewModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("body")]
        public string MessageText { get; set; }

        [JsonProperty("hashTags")]
        public List<string> HashTags { get; set; }

        [JsonProperty("mediaType")]
        public SocialMediaType MediaType { get; set; }

        [JsonProperty("postDate")]
        public DateTime? PostDate { get; set; }

        [JsonProperty("user")]
        public UserViewModel User { get; set; }

        [JsonProperty("networkId")]
        public string NetworkId { get; set; }
    }
}
