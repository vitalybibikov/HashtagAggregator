using System.Collections.Generic;
using HashtagAggregator.Core.Models.Interface.Cqrs.Query;

namespace HashtagAggregator.Core.Models.Results.Query.HashTag
{
    public class HashTagsQueryResult : IQueryResult
    {
        public HashTagsQueryResult()
        {
            HashTags = new List<HashTagQueryResult>();
        }

        public List<HashTagQueryResult> HashTags { get; }
    }
}
