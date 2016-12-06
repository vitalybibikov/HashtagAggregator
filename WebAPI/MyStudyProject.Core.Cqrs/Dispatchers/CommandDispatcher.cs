using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Autofac;
using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;
using MyStudyProject.Core.Cqrs.Abstract;

namespace MyStudyProject.Core.Cqrs.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext container;

        public CommandDispatcher(IComponentContext container)
        {
            this.container = container;
        }

        public async Task<ICommandResult> DispatchAsync<T>(T command) where T : ICommand, new()
        {
            var results = container.ComponentRegistry.Registrations.SelectMany(x => x.Services);
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

        public async Task<ICommandResult> DispatchMultipleAsync<T>(List<T> commands) where T : ICommand, new()

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
            return await compositeHandler.ExecuteAsync(commands);
        }
    }
}