using HashtagAggregator.Core.Models.Interface.Cqrs.Query;

namespace HashtagAggregator.Core.Models.Queries
{
    public class HashTagParentsGetQuery : IQuery
    {
        public bool IsParent { get; set; }
    }
}
