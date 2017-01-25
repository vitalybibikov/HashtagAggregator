using System;
using System.Threading.Tasks;

using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;
using MyStudyProject.Core.Cqrs.Abstract;
using MyStudyProject.Core.Models.Commands;

namespace MyStudyProject.Domain.Cqrs.Vk.Handlers
{
    public class VkMesssagesCreateCommandHandler : CommandHandler<MessagesCreateCommand>
    {
        public override Task<ICommandResult> ExecuteAsync(MessagesCreateCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
