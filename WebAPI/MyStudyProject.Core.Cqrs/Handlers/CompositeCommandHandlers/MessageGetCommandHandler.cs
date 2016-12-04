using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MyStudyProject.Core.Contracts.Abstract;
using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;
using MyStudyProject.Core.Models.Commands;

namespace MyStudyProject.Core.Cqrs.Handlers.CompositeCommandHandlers
{
    public class MessageGetCommandHandler : CompositeCommandHandler<MessageCreateCommand>, ICompositeCommandHandler<MessageCreateCommand>
    {
        public MessageGetCommandHandler(List<ICommandHandler<MessageCreateCommand>> handlersList) : base(handlersList)
        {

        }

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
