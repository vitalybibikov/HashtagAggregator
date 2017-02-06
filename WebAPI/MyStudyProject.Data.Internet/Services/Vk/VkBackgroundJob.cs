using System;

using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;
using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Data.Contracts.Interface.JobObjects;

namespace MyStudyProject.Data.Internet.Services.Vk
{
    public class VkBackgroundJob : IVkBackgroundJob<MessageCreateCommand>
    {
        public ICommandResult Publish(MessageCreateCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
