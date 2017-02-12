using System.Collections.Generic;
using System.Threading.Tasks;

using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Core.Models.Interface.Cqrs.Command;
using MyStudyProject.Core.Models.Results.Query;

namespace MyStudyProject.Core.Contracts.Interface.DataSources
{
    public interface IMessageServiceFacade 
    {
        Task<MessagesQueryResult> GetAllAsync(string hashtag);

        Task<ICommandResult> Save(IEnumerable<MessageCreateCommand> filtered);
    }
}
