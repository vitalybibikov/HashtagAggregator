using System;
using HashtagAggregator.Core.Models.Interface.Cqrs.Query;

namespace HashtagAggregator.Core.Models.Queries
{
    public class HashTagsQuery : IQuery
    {
       public long ParentId { get; set; }
    }
}
