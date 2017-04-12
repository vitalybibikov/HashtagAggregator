using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using HashtagAggregator.Core.Contracts.Interface;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Query;
using HashtagAggregator.Core.Cqrs.Abstract;
using HashtagAggregator.Core.Models.Queries;
using HashtagAggregator.Core.Models.Results.Query;

namespace HashtagAggregator.Domain.Cqrs.Common.Handlers.CompositeQueryHandlers
{
    public class MessagesGetQueryHandler : CompositeQueryHandler<MessagesGetQuery, MessagesQueryResult>
    {
        private readonly IMessageFilter<MessagesQueryResult> filter;

        public MessagesGetQueryHandler(ILogger logger, IMessageFilter<MessagesQueryResult> filter) : base(logger)
        {
            this.filter = filter;
        }

        protected override async Task<MessagesQueryResult> GetDataAsync(MessagesGetQuery query)
        {
            MessagesQueryResult list = new MessagesQueryResult();
            List<MessagesQueryResult> results = await RunHandlers(RunHandler, query);
            list.Messages.AddRange(results.SelectMany(x => x.Messages));
            return filter.Filter(list);
        }

        protected override async Task<MessagesQueryResult> RunHandler(
            IQueryHandler<MessagesGetQuery, MessagesQueryResult> handler, MessagesGetQuery query)
        {
            MessagesQueryResult messages = await handler.GetAsync(query);
            return messages;
        }
    }
}