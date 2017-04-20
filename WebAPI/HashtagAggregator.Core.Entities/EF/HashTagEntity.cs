using System.Collections.Generic;

using HashtagAggregator.Core.Entities.EF.Abstract;

namespace HashtagAggregator.Core.Entities.EF
{
    public class HashTagEntity : Entity
    {
        public string HashTag { get; set; }

        public long? ParentId { get; set; }

        public HashTagEntity Parent { get; set; }

        public ICollection<HashTagEntity> Children { get; set; }

        public bool IsEnabled { get; set; }

        public virtual ICollection<MessageHashTagRelationsEntity> MessageHashTagRelations { get; set; }
    }
}
