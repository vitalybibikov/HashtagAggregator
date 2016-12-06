using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStudyProject.Core.Contracts.Interface.Cqrs.Command
{
    public interface ICommandHandler<TParameter> 
        where TParameter : ICommand, new()
    {
        Task<ICommandResult> ExecuteAsync(TParameter command);

        Task<ICommandResult> ExecuteAsync(List<TParameter> command);
    }
}
