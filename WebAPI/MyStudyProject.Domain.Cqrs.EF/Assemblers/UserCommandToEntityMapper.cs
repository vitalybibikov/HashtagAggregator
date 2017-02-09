using System;

using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Data.Entities.Entities;

namespace MyStudyProject.Domain.Cqrs.EF.Assemblers
{
    public class UserCommandToEntityMapper
    {
        public UserEntity MapSingle(UserCreateCommand item)
        {
            UserEntity query = null;
            if (item != null)
            {
                query = new UserEntity();
                query.Id = item.Id;
                query.NetworkId = item.NetworkId;
                query.UserName = item.UserName;
                query.ProfileId = item.ProfileId;
                query.ProfileUrl = item.Url;
            }
            return query;
        }
    }
}
