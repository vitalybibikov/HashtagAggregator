using System.Threading.Tasks;
using MyStudyProject.Core.Contracts.Abstract;
using MyStudyProject.Core.Cqrs.Results;
using MyStudyProject.Core.Models.Queries;

namespace MyStudyProject.Core.Cqrs.Handlers.QueryHandlers
{
    public class MessagesQueryHandler : QueryHandler<MessagesQuery, MessageQueryResult>
    {
        public override Task<MessageQueryResult> Get(MessagesQuery query)
        {
            throw new System.NotImplementedException();
        }
    }
}
