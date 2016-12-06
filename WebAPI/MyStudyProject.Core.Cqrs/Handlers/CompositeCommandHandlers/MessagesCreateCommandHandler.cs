using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;
using MyStudyProject.Core.Cqrs.Abstract;
using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Core.Models.Results.Command;
using MyStudyProject.Shared.Common;

namespace MyStudyProject.Core.Cqrs.Handlers.CompositeCommandHandlers
{
    public class  MessagesCreateCommandHandler : CompositeCommandHandler<MessagesCreateCommand>
    {
        public override async  Task<ICommandResult> ExecuteAsync(MessagesCreateCommand command)
        {
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
