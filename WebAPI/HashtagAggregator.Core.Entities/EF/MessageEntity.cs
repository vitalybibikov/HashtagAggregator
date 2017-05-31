using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using HashtagAggregator.Core.Entities.EF.Abstract;
using HashtagAggregator.Shared.Contracts.Enums;

namespace HashtagAggregator.Core.Entities.EF
{
    public class MessageEntity : Entity
    {
        public MessageEntity()
        {
            HashTags = new List<HashTagEntity>();
            MessageHashTagRelations = new List<MessageHashTagRelationsEntity>();
        }

        public string NetworkId { get; set; }

        public string MessageText { get; set; }

        public DateTime? PostDate { get; set; }

        public SocialMediaType MediaType { get; set; }

        public long UserId { get; set; }

        [NotMapped]
        public virtual List<HashTagEntity> HashTags { get; set; }

        public virtual ICollection<MessageHashTagRelationsEntity> MessageHashTagRelations { get; set; }

        public virtual UserEntity User { get; set; }
    }
}
