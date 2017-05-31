using System.Collections.Generic;

using HashtagAggregator.Core.Entities.EF.Abstract;
using HashtagAggregator.Shared.Contracts.Enums;

namespace HashtagAggregator.Core.Entities.EF
{
    public class UserEntity : Entity
    {
        public string NetworkId { get; set; }

        public string UserName { get; set; }

        public string ProfileId { get; set; }

        public string Url { get; set; }

        public SocialMediaType  MediaType { get; set; }

        public string AvatarUrl50 { get; set; }

        public virtual ICollection<MessageEntity> Messages { get; set; }
    }
}
