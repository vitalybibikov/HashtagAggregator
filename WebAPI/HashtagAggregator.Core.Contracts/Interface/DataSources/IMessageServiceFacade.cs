﻿using System.Collections.Generic;
using System.Threading.Tasks;

using HashtagAggregator.Core.Models.Commands;
using HashtagAggregator.Core.Models.Interface.Cqrs.Command;
using HashtagAggregator.Core.Models.Results.Query.Message;
using HashtagAggregator.Shared.Common.Infrastructure;

namespace HashtagAggregator.Core.Contracts.Interface.DataSources
{
    public interface IMessageServiceFacade 
    {
        Task<MessagesQueryResult> GetAllAsync(HashTagWord hashtag);

        Task<ICommandResult> Save(IEnumerable<MessageCreateCommand> filtered);
    }
}
