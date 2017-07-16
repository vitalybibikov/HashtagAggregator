using AutoMapper;

using HashtagAggregator.Core.Models.Results.Query.HashTag;
using HashtagAggregator.Core.Models.Results.Query.Message;
using HashtagAggregator.Core.Models.Results.Query.User;
using HashtagAggregator.ViewModels;

namespace HashtagAggregator.Configuration
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<MessageQueryResult, MessageViewModel>();
            CreateMap<UserQueryResult, UserViewModel>();
            CreateMap<HashTagQueryResult, HashtagViewModel>();
        }
    }
}
