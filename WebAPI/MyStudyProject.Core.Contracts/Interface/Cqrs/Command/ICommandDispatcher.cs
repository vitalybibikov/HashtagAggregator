using System.Threading.Tasks;
using MyStudyProject.Core.Models.Interface.Cqrs.Command;

namespace MyStudyProject.Core.Contracts.Interface.Cqrs.Command
{
    public interface ICommandDispatcher
    {
        Task<ICommandResult> DispatchAsync<T>(T command) where T : ICommand, new();
    }
}
