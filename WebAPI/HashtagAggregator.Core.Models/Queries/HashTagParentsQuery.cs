using HashtagAggregator.Core.Models.Results.Query.HashTag;
using MediatR;

namespace HashtagAggregator.Core.Models.Queries
{
    public class HashTagParentsQuery : IRequest<HashTagsQueryResult>
    {
        public bool IsParent { get; set; }
    }
}
