using System;
using System.Collections.Generic;
using HashtagAggregator.Core.Models.Results.Query.HashTag;
using HashtagAggregator.Core.Models.Results.Query.User;
using HashtagAggregator.Shared.Contracts.Enums;

namespace HashtagAggregator.Core.Models.Results.Query.Message
{
    public class MessageQueryResult
    {

        public long Id { get; set; }

        public string MessageText { get; set; }

        public List<HashTagQueryResult> HashTags { get; set; }

        public SocialMediaType MediaType { get; set; }

        public DateTime? PostDate { get; set; }

        public string NetworkId { get; set; }

        public UserQueryResult User { get; set; }

    }
}
