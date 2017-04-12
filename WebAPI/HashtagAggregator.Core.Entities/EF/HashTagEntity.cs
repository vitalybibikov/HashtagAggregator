using System;
using HashtagAggregator.Core.Entities.EF.Abstract;

namespace HashtagAggregator.Core.Entities.EF
{
    public class HashTagEntity : Entity
    {
        public string HashTag { get; set; }

        public bool IsEnabled { get; set; }
    }
}
