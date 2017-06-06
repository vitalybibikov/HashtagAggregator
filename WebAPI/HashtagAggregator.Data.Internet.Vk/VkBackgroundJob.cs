using System;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregator.Core.Models.Commands;
using HashtagAggregator.Data.Contracts.Interface.JobObjects;

namespace HashtagAggregator.Data.Internet.Vk
{
    public class VkBackgroundJob : IVkBackgroundJob<MessageCreateCommand>
    {
        public ICommandResult Publish(MessageCreateCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
