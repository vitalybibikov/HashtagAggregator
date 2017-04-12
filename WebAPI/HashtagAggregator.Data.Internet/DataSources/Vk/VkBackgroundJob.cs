using System;
using HashtagAggregator.Core.Models.Commands;
using HashtagAggregator.Core.Models.Interface.Cqrs.Command;
using HashtagAggregator.Data.Contracts.Interface.JobObjects;

namespace HashtagAggregator.Data.Internet.DataSources.Vk
{
    public class VkBackgroundJob : IVkBackgroundJob<MessageCreateCommand>
    {
        public ICommandResult Publish(MessageCreateCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
