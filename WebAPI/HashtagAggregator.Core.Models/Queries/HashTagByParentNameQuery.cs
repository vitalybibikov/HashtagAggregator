using HashtagAggregator.Core.Models.Results.Query.HashTag;
using HashtagAggregator.Shared.Common.Infrastructure;
using MediatR;

namespace HashtagAggregator.Core.Models.Queries
{
    public class HashTagByParentNameQuery : IRequest<HashTagsQueryResult>
    {
        public HashTagWord HashTag { get; set; }
    }
}
