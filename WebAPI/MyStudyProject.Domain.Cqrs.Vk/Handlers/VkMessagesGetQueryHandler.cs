using System;
using System.Threading.Tasks;

using MyStudyProject.Core.Contracts.Interface.ServiceFacades;
using MyStudyProject.Core.Models.Queries;
using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Domain.Cqrs.Vk.Abstract;
using MyStudyProject.Shared.Common.Attributes;
using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.Domain.Cqrs.Vk.Handlers
{
    [DataSourceType(SocialMediaType.VK)]
    public class VkMessagesGetQueryHandler : VkQueryHandler<MessagesGetQuery, MessagesQueryResult>
    {
        public VkMessagesGetQueryHandler(IVkMessageFacade<MessagesQueryResult> facade) : base(facade)
        {
        }

        protected override async Task<MessagesQueryResult> GetDataAsync(MessagesGetQuery query)
        {
            return await Facade.GetAllAsync(query.HashTag);
        }
    }
}
