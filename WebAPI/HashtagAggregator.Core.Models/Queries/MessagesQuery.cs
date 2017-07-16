using HashtagAggregator.Core.Models.Results.Query.Message;
using HashtagAggregator.Shared.Common.Infrastructure;
using MediatR;

namespace HashtagAggregator.Core.Models.Queries
{
    public class MessagesQuery : IRequest<MessagesQueryResult>
    {
        public HashTagWord HashTag { get; set; }
    }
}