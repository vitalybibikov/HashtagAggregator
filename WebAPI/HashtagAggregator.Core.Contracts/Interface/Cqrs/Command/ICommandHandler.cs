using System.Threading.Tasks;
using HashtagAggregator.Core.Models.Interface.Cqrs.Command;

namespace HashtagAggregator.Core.Contracts.Interface.Cqrs.Command
{
    public interface ICommandHandler<TParameter> 
        where TParameter : ICommand, new()
    {
        Task<ICommandResult> ExecuteAsync(TParameter command);
    }
}
