using System.Threading.Tasks;
using MyStudyProject.Core.Models.Results.Query;

namespace MyStudyProject.Data.Contracts.ServiceFacades
{
    public interface IMessageServiceFacade 
    {
        Task<MessagesQueryResult> GetAllAsync(string hashtag);
    }
}
