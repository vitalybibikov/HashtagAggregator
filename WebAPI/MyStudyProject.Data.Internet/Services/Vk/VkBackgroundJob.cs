using System;

using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Data.Contracts.Interface;
using MyStudyProject.Data.Contracts.Interface.JobObjects;

namespace MyStudyProject.Data.Internet.Services.Vk
{
    public class VkBackgroundJob : IVkBackgroundJob<MessageCreateCommand>
    {
        public void Publish(MessageCreateCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
