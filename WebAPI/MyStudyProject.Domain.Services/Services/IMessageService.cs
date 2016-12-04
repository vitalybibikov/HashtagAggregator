using MyStudyProject.Core.Contracts.Interface.ServiceFacades;
using MyStudyProject.Core.Models.Results.Query;

namespace MyStudyProject.Domain.Services.Services
{
    public interface IMessageService : IMessageServiceFacade<MessageQueryResult>
    {
    }
}
