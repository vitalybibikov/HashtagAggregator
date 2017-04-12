using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.DataSources;
using HashtagAggregator.Core.Models.Queries;
using HashtagAggregator.Core.Models.Results.Query;
using HashtagAggregator.Domain.Cqrs.Vk.Abstract;
using HashtagAggregator.Shared.Common.Attributes;
using HashtagAggregator.Shared.Contracts.Enums;

namespace HashtagAggregator.Domain.Cqrs.Vk.Handlers
{
    [DataSourceType(SocialMediaType.VK)]
    public class VkMessagesGetQueryHandler : VkQueryHandler<MessagesGetQuery, MessagesQueryResult>
    {
        public VkMessagesGetQueryHandler(IVkMessageFacade facade) : base(facade)
        {
        }

        protected override async Task<MessagesQueryResult> GetDataAsync(MessagesGetQuery query)
        {
            return await Facade.GetAllAsync(query.HashTag);
        }
    }
}
