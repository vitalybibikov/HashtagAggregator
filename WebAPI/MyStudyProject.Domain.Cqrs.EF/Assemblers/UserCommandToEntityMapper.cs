using MyStudyProject.Core.Entities.EF;
using MyStudyProject.Core.Models.Commands;

namespace MyStudyProject.Domain.Cqrs.EF.Assemblers
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
                    Url = item.Url
                };
            }
            return query;
        }
    }
}
