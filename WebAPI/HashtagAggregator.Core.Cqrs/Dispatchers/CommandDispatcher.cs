using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregator.Core.Cqrs.Abstract;
using Microsoft.Extensions.Logging;

namespace HashtagAggregator.Core.Cqrs.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly ILifetimeScope container;
        private readonly ILogger logger;

        public CommandDispatcher(ILifetimeScope container, ILogger<CommandDispatcher> logger)
        {
            this.container = container;
            this.logger = logger;
        }

        public async Task<ICommandResult> DispatchAsync<T>(T command)
            where T : ICommand, new()
        {
            var typedParameter = new TypedParameter(typeof(ILogger), logger);
            var compositeHandler = container.Resolve<CompositeCommandHandler<T>>(typedParameter);
            var handlers = container.Resolve<IList<ICommandHandler<T>>>(typedParameter);

            foreach (var handler in handlers)
            {
                if (handler.GetType() != compositeHandler.GetType())
                {
                    compositeHandler.Add(handler);
                }
            }
            return await compositeHandler.ExecuteAsync(command);
        }

        public async Task<List<ICommandResult>> DispatchMultipleAsync<T>(List<T> commands)
            where T : ICommand, new()
        {
            var list = new List<ICommandResult>();
            foreach (var command in commands)
            {
                ICommandResult result = await DispatchAsync(command);
                list.Add(result);
            }
            return list;
        }
    }
}