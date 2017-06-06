using HashtagAggregator.Core.Contracts.Interface.Cqrs.Query;
using HashtagAggregator.Shared.Common.Infrastructure;

namespace HashtagAggregator.Core.Models.Queries
{
    public class MessagesQuery : IQuery
    {
        public HashTagWord HashTag { get; set; }
    }
}
