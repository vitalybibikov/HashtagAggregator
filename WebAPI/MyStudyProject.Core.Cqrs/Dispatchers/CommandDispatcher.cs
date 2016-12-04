using System.Threading.Tasks;
using Autofac;

using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;

namespace MyStudyProject.Core.Cqrs.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext container;

        public CommandDispatcher(IComponentContext container)
        {
            this.container = container;
        }

        public Task<ICommandResult> Dispatch<T>(T command) where T : ICommand
        {
            var handler = container.Resolve<ICommandHandler<T>>();
            return handler.Execute(command);
        }
    }
}
