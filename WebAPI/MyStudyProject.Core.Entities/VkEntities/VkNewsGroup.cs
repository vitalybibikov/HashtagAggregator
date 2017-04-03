using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MyStudyProject.Core.Entities.VkEntities
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
