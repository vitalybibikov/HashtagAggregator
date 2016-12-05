using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MyStudyProject.Core.Contracts.Abstract;
using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;
using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Core.Models.Results.Command;

namespace MyStudyProject.Core.Cqrs.Handlers.CompositeCommandHandlers
{
    public class MessagesCreateCommandHandler : CompositeCommandHandler<MessagesCreateCommand>, ICompositeCommandHandler<MessagesCreateCommand>
    {
        public override async Task<ICommandResult> ExecuteAsync(MessagesCreateCommand command)
        {
            Validate(command);
            foreach (var handler in Handlers)
            {
                await handler.ExecuteAsync(command);
            }
            return new CommandResult { Success = true };
        }

        public override async Task<ICommandResult> ExecuteAsync(List<MessagesCreateCommand> commands)
        {
            foreach (var handler in Handlers)
            {
                var argument = handler.GetType().GenericTypeArguments[0];
                foreach (var command in commands)
                {
                    if (command.GetType() == argument)
                    {
                        await handler.ExecuteAsync(command);
                    }
                }
            }
            return new CommandResult { Success = true };
        }
    }
}
