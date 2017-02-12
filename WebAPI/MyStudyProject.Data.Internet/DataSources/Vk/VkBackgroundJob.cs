using System;
using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Core.Models.Interface.Cqrs.Command;
using MyStudyProject.Data.Contracts.Interface.JobObjects;

namespace MyStudyProject.Data.Internet.DataSources.Vk
{
    public class VkBackgroundJob : IVkBackgroundJob<MessageCreateCommand>
    {
        public ICommandResult Publish(MessageCreateCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
