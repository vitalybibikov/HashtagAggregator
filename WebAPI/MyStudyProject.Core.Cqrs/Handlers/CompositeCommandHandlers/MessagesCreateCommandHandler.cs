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
    public class MessagesCreateCommandHandler : CompositeCommandHandler<MessagesCreateCommand>
    {
        public override async Task<ICommandResult> ExecuteAsync(MessagesCreateCommand command)
        {
            foreach (var handler in Handlers)
            {
                try
                {
                    await handler.ExecuteAsync(command);
                }
                catch (Exception ex)
                {
                   //Todo: implement logging
                   Console.WriteLine("Exception: " + ex);
                }
            }
            return new CommandResult { Success = true };
        }
    }
}
