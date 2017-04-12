using System;

using HashtagAggregator.Core.Entities.EF.Abstract;
using HashtagAggregator.Shared.Contracts.Enums;

namespace HashtagAggregator.Core.Entities.EF
{
    public class MessageEntity : Entity
    {
        public string NetworkId { get; set; }

        public string MessageText { get; set; }

        public string HashTag { get; set; }

        public DateTime? PostDate { get; set; }

        public SocialMediaType MediaType { get; set; }

        public virtual UserEntity User { get; set; }

        public long UserId { get; set; }
    }
}
