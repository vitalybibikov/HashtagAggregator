using System;
using System.Threading.Tasks;
using MyStudyProject.Core.Contracts.Interface.DataSources;
using MyStudyProject.Core.Models.Queries;
using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Domain.Cqrs.Twitter.Abstract;
using MyStudyProject.Shared.Common.Attributes;
using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.Domain.Cqrs.Twitter.Handlers
{
    [DataSourceType(SocialMediaType.Twitter)]
    public class TwitterMessagesGetQueryHandler : TwitterQueryHandler<MessagesGetQuery, MessagesQueryResult>
    {
        public TwitterMessagesGetQueryHandler(ITwitterMessageFacade facade) : base(facade)
        {

        }

        protected override async Task<MessagesQueryResult> GetDataAsync(MessagesGetQuery query)
        {
            return await Facade.GetAllAsync(query.HashTag);
        }
    }
}
