using System;

using HashtagAggregator.Core.Models.Interface.Cqrs.Query;

namespace HashtagAggregator.Core.Models.Queries
{
    public class HashTagByParentNameQuery : IQuery
    {
        public string HashTag { get; set; }
    }
}
