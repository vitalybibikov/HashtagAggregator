using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;
using MyStudyProject.Core.Models.Results.Command;
using MyStudyProject.Shared.Logging;

namespace MyStudyProject.Core.Cqrs.Abstract
{
    public abstract class CompositeCommandHandler<TParameter> : CommandHandler<TParameter>
        where TParameter : ICommand, new()
    {
        private readonly List<ICommandHandler<TParameter>> handlers;
        private ILogger logger;
        public List<ICommandHandler<TParameter>> Handlers => handlers;

        protected CompositeCommandHandler(ILogger logger)
        {
            this.logger = logger;
            handlers = new List<ICommandHandler<TParameter>>();
        }

        public override async Task<ICommandResult> ExecuteAsync(TParameter command)
        {
            foreach (var handler in Handlers)
            {
                try
                {
                    await handler.ExecuteAsync(command);
                }
                catch (Exception ex)
                {
                    todo: //catch DbUpdateException
                    logger.LogCritical(
                        LoggingEvents.EXCEPTION_EXECUTE_COMMAND, 
                        ex, 
                        "Failed to execute {@command} with {@handler}", 
                        command, 
                        handler);
                }
            }
            return new CommandResult { Success = true };
        }

        public override void Add(ICommandHandler<TParameter> queryHandler)
        {
            handlers.Add(queryHandler);
        }

        public override bool Remove(ICommandHandler<TParameter> queryHandler)
        {
            return handlers.Remove(queryHandler);
        }
    }
}
