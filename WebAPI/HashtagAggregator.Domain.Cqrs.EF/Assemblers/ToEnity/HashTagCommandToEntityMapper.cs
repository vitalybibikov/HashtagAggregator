using System.Collections.Generic;

using HashtagAggregator.Core.Entities.EF;
using HashtagAggregator.Core.Models.Commands;

namespace HashtagAggregator.Domain.Cqrs.EF.Assemblers.ToEnity
{
    public class HashTagCommandToEntityMapper
    {
        public List<HashTagEntity> MapBunch(IEnumerable<HashTagCreateCommand> tags)
        {
            var results = new List<HashTagEntity>();
            if (tags != null)
            {
                foreach (var tag in tags)
                {
                    HashTagEntity entity = new HashTagEntity()
                    {
                        HashTag = tag.HashTag,
                        IsEnabled = tag.IsEnabled
                    };
                    results.Add(entity);
                }
            }
            return results;
        }
    }
}
