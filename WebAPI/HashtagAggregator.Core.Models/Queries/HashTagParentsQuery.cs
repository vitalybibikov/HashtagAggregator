using HashtagAggregator.Core.Contracts.Interface.Cqrs.Query;

namespace HashtagAggregator.Core.Models.Queries
{
    public class HashTagParentsQuery : IQuery
    {
        public bool IsParent { get; set; }
    }
}
