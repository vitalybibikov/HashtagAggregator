using System.ComponentModel.DataAnnotations;

namespace HashtagAggregator.Core.Entities.EF
{
    public class MessageHashTagRelationsEntity 
    {
        [Key]
        public long HashTagEntityId { get; set; }

        public HashTagEntity HashTagEntity { get; set; }

        [Key]
        public long MessageEntityId { get; set; }

        public MessageEntity MessageEntity { get; set; }
    }
}
