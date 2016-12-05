using System.Collections.Generic;
using System.Threading.Tasks;

using MyStudyProject.Core.Contracts.Abstract;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;
using MyStudyProject.Core.Models.Queries;
using MyStudyProject.Core.Models.Results.Query;

namespace MyStudyProject.Core.Cqrs.Handlers.CompositeQueryHandlers
{
    public class MessagesGetQueryHandler : CompositeQueryHandler<MessagesGetQuery, MessagesQueryResult> , ICompositeQueryHandler<MessagesGetQuery, MessagesQueryResult>
    {
        public override async Task<MessagesQueryResult> GetAsync(MessagesGetQuery query)
        {
            MessagesQueryResult result = new MessagesQueryResult();
            foreach (var handler in Handlers)
            {
                MessagesQueryResult messages = await handler.GetAsync(query);
                result.Messages.AddRange(messages.Messages);
            }
            return result;
        }
    }
}
