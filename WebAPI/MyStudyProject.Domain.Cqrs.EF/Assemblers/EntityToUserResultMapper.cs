using MyStudyProject.Core.Entities.EF;
using MyStudyProject.Core.Models.Results.Query;

namespace MyStudyProject.Domain.Cqrs.EF.Assemblers
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
                query.Url = item.Url;
            }
            return query;
        }
    }
}
