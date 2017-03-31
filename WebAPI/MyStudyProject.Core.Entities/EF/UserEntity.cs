using System.Collections.Generic;

using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.Core.Entities.EF
{
    public class UserEntity : Entity
    {
        public string NetworkId { get; set; }

        public string UserName { get; set; }

        public string ProfileId { get; set; }

        public string Url { get; set; }

        public SocialMediaType  MediaType { get; set; }

        public virtual List<MessageEntity> Messages { get; set; }
    }
}
