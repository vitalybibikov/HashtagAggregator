using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyStudyProject.Domain.Services.Services.Vk
{
    public class VkNewsFeed
    {
        [JsonProperty("items")]
        public List<VkNewsSearchResult> Feed { get; set; }
    }
}
