﻿using System.Threading.Tasks;

using MyStudyProject.Core.Cqrs.Abstract;
using MyStudyProject.Core.Models.Queries;
using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Shared.Common.UpdateStrategies;

namespace MyStudyProject.Core.Cqrs.Handlers.CompositeQueryHandlers
{
    public class MessagesGetQueryHandler : CompositeQueryHandler<MessagesGetQuery, MessagesQueryResult>
    {
        public MessagesGetQueryHandler(IUpdateStrategy strategy) : base(strategy)
        {
        }

        protected override async Task<MessagesQueryResult> GetDataAsync(MessagesGetQuery query)
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
