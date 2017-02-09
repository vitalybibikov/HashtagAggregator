using System.Collections.Generic;

using MyStudyProject.Data.Contracts.Abstract;

namespace MyStudyProject.Data.Entities.Entities
{
    public class UserEntity : Entity
    {
        public string NetworkId { get; set; }

        public string UserName { get; set; }

        public string ProfileId { get; set; }

        public string ProfileUrl { get; set; }

        public List<MessageEntity> Messages { get; set; }
    }
}
