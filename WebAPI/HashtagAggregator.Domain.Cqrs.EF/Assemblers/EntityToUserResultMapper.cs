using HashtagAggregator.Core.Entities.EF;
using HashtagAggregator.Core.Models.Results.Query;

namespace HashtagAggregator.Domain.Cqrs.EF.Assemblers
{
    public class EntityToUserResultMapper
    {
        public UserQueryResult MapSingle(UserEntity item)
        {
            UserQueryResult query = new UserQueryResult();
            if (item != null)
            {
                query.Id = item.Id;
                query.NetworkId = item.NetworkId;
                query.UserName = item.UserName;
                query.ProfileId = item.ProfileId;
                query.MediaType = item.MediaType;
                query.Url = item.Url;
                query.AvatarUrl50 = item.AvatarUrl50;
            }
            return query;
        }
    }
}
