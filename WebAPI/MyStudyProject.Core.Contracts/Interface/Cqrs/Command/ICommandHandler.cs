using System.Collections.Generic;
using System.Threading.Tasks;
using MyStudyProject.Core.Models.Interface.Cqrs.Command;

namespace MyStudyProject.Core.Contracts.Interface.Cqrs.Command
{
    public interface ICommandHandler<TParameter> 
        where TParameter : ICommand, new()
    {
        Task<ICommandResult> ExecuteAsync(TParameter command);
    }
}
