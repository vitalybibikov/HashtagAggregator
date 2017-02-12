using System.Collections.Generic;

namespace MyStudyProject.Core.Entities.EF
{
    public class UserEntity : Entity
    {
        public string NetworkId { get; set; }

        public string UserName { get; set; }

        public string ProfileId { get; set; }

        public string Url { get; set; }

        public List<MessageEntity> Messages { get; set; }
    }
}
