using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Data.Entities.Entities;

namespace MyStudyProject.Domain.Cqrs.EF.Assemblers
{
    public class EntityToUserResultMapper
    {
        public UserQueryResult MapSingle(UserEntity item)
        {
            UserQueryResult query = new UserQueryResult();
            query.Id = item.Id;
            query.NetworkId = item.NetworkId;
            query.UserName = item.UserName;
            query.ProfileId = item.ProfileId;
            query.Url = item.ProfileUrl;
            return query;
        }
    }
}
