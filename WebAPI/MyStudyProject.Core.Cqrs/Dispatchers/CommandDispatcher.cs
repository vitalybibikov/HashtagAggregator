using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;

using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;
using MyStudyProject.Core.Cqrs.Abstract;

namespace MyStudyProject.Core.Cqrs.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly ILifetimeScope container;

        public CommandDispatcher(ILifetimeScope container)
        {
            this.container = container;
        }

        public async Task<ICommandResult> DispatchAsync<T>(T command)
            where T : ICommand, new()
        {
            var compositeHandler = container.Resolve<CompositeCommandHandler<T>>();
            var handlers = container.Resolve<IList<ICommandHandler<T>>>();

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