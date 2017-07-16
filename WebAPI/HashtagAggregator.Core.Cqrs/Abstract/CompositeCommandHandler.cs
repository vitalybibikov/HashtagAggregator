using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregator.Core.Models.Results;
using HashtagAggregator.Shared.Logging;
using Microsoft.Extensions.Logging;

namespace HashtagAggregator.Core.Cqrs.Abstract
{
    public abstract class CompositeCommandHandler<TParameter> : CommandHandler<TParameter>
        where TParameter : ICommand, new()
    {
        private readonly List<ICommandHandler<TParameter>> handlers;
        private readonly ILogger logger;
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
