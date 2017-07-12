using System.Collections.Generic;

namespace HashtagAggregator.Core.Models.Results.Query.HashTag
{
    public class HashTagsQueryResult
    {
        public HashTagsQueryResult()
        {
            HashTags = new List<HashTagQueryResult>();
        }

        public List<HashTagQueryResult> HashTags { get; }
    }
}
