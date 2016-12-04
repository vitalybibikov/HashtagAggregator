using MyStudyProject.Core.Contracts.Interface.ServiceFacades;
using MyStudyProject.Core.Models.Results.Query;

namespace MyStudyProject.Domain.Services.Services.Twitter
{
    public interface ITwitterServiceFacade : IMessageServiceFacade<MessageQueryResult>
    {
    }
}
