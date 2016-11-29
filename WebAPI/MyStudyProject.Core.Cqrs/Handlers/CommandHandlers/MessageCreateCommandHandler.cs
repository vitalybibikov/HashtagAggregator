using System;
using System.Threading.Tasks;

using MyStudyProject.Core.Contracts.Abstract;
using MyStudyProject.Core.Contracts.Interface;
using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Models.Commands;

namespace MyStudyProject.Core.Cqrs.Handlers.CommandHandlers
{
    public class MessageCreateCommandHandler : CommandHandler<MessageCreateCommand>
    {
        public override Task<ICommandResult> Execute(MessageCreateCommand command)
        {
            Validate(command);
            return InsertMessage(command);
        }

        private Task<ICommandResult> InsertMessage(ICommand command)
        {
            throw new NotImplementedException();
        }
    }
}
