using HashtagAggregator.Core.Contracts.Interface.Cqrs.Query;

namespace HashtagAggregator.Core.Models.Queries
{
    public class HashTagByParentNameQuery : IQuery
    {
        public string HashTag { get; set; }
    }
}
