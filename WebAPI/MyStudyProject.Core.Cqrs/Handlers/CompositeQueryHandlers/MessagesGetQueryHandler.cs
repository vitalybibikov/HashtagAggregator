using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;
using MyStudyProject.Core.Cqrs.Abstract;
using MyStudyProject.Core.Models.Queries;
using MyStudyProject.Core.Models.Results.Query;

namespace MyStudyProject.Core.Cqrs.Handlers.CompositeQueryHandlers
{
    public class MessagesGetQueryHandler : CompositeQueryHandler<MessagesGetQuery, MessagesQueryResult>
    {
        protected override async Task<MessagesQueryResult> GetDataAsync(MessagesGetQuery query)
        {
            MessagesQueryResult list = new MessagesQueryResult();
            List<MessagesQueryResult> results = await RunHandlers(RunHandler, query);
            list.Messages.AddRange(results.SelectMany(x => x.Messages));
            return list;
        }

        protected override async Task<MessagesQueryResult> RunHandler(IQueryHandler<MessagesGetQuery, MessagesQueryResult> handler, MessagesGetQuery query)
        {
            MessagesQueryResult messages = await handler.GetAsync(query);
            return messages;
        }
    }
}
