using System.Threading.Tasks;

namespace MyStudyProject.Core.Contracts.Interface.Cqrs.Command
{
    public interface ICommandDispatcher
    {
        Task<ICommandResult> DispatchAsync<T>(T command) where T : ICommand, new();
    }
}
