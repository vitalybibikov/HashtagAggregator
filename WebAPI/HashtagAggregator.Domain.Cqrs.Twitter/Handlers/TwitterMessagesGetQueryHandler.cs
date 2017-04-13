using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.DataSources;
using HashtagAggregator.Core.Models.Queries;
using HashtagAggregator.Core.Models.Results.Query;
using HashtagAggregator.Core.Models.Results.Query.Message;
using HashtagAggregator.Domain.Cqrs.Twitter.Abstract;
using HashtagAggregator.Shared.Common.Attributes;
using HashtagAggregator.Shared.Contracts.Enums;

namespace HashtagAggregator.Domain.Cqrs.Twitter.Handlers
{
    [DataSourceType(SocialMediaType.Twitter)]
    public class TwitterMessagesGetQueryHandler : TwitterQueryHandler<MessagesQuery, MessagesQueryResult>
    {
        public TwitterMessagesGetQueryHandler(ITwitterMessageFacade facade) : base(facade)
        {

        }

        protected override async Task<MessagesQueryResult> GetDataAsync(MessagesQuery query)
        {
            return await Facade.GetAllAsync(query.HashTag);
        }
    }
}
