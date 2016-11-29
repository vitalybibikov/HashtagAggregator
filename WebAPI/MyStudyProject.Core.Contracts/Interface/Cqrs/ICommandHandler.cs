using System.Threading.Tasks;

namespace MyStudyProject.Core.Contracts.Interface.Cqrs
{
    public interface ICommandHandler<in TParameter> 
        where TParameter : ICommand
    {
        Task<ICommandResult> Execute(TParameter command);
    }
}
