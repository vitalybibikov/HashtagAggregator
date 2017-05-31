using HashtagAggregator.Core.Entities.EF;
using HashtagAggregator.Core.Models.Commands;

namespace HashtagAggregator.Domain.Cqrs.EF.Assemblers.ToEnity
{
    public class UserCommandToEntityMapper
    {
        public UserEntity MapSingle(UserCreateCommand item)
        {
            UserEntity query = null;
            if (item != null)
            {
                query = new UserEntity
                {
                    Id = item.Id,
                    NetworkId = item.NetworkId,
                    UserName = item.UserName,
                    ProfileId = item.ProfileId,
                    MediaType =  item.MediaType,
                    Url = item.Url,
                    AvatarUrl50 = item.AvatarUrl50
                };
            }
            return query;
        }
    }
}
