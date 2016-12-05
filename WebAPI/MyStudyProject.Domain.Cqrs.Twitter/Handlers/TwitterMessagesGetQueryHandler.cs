using System;
using System.Threading.Tasks;

using MyStudyProject.Core.Contracts.Abstract;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;
using MyStudyProject.Core.Contracts.Interface.ServiceFacades;
using MyStudyProject.Core.Models.Queries;
using MyStudyProject.Core.Models.Results.Query;

namespace MyStudyProject.Domain.Cqrs.Twitter.Handlers
{
    public class TwitterMessagesGetQueryHandler : QueryHandler<MessagesGetQuery, MessagesQueryResult>, IQueryHandler<MessagesGetQuery, MessagesQueryResult>
    {
        private readonly ITwitterMessageFacade<MessagesQueryResult> facade;

        public TwitterMessagesGetQueryHandler(ITwitterMessageFacade<MessagesQueryResult> facade)
        {
            this.facade = facade;
        }

        public override Task<MessagesQueryResult> GetAsync(MessagesGetQuery query)
        {
            return facade.GetAllAsync(query.HashTag);
        }
    }
}
