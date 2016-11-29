using System.Threading.Tasks;

namespace MyStudyProject.Core.Contracts.Interface.Cqrs
{
    public interface ICommandDispatcher
    {
        Task<ICommandResult> Dispatch<T>(T command) where T : ICommand;
    }
}
