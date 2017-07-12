using HashtagAggregator.Core.Models.Queries;
using HashtagAggregator.Core.Models.Results.Query.Message;
using MediatR;

namespace HashtagAggregator.Core.Cqrs.Interface.Queries
{
    public interface IEfMessagesGetQueryHandler : IAsyncRequestHandler<MessagesQuery, MessagesQueryResult>
    {
      
    }
}
