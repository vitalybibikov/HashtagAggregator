using System.Collections.Generic;

using HashtagAggregator.Core.Entities.EF;
using HashtagAggregator.Core.Models.Results.Query;

namespace HashtagAggregator.Domain.Cqrs.EF.Assemblers.ToResult
{
    public class EntityToHashTagResultMapper
    {
        public HashTagsQueryResult MapBunch(IEnumerable<HashTagEntity> tags)
        {
            var results = new HashTagsQueryResult();
            foreach (var entity in tags)
            {
                var result = new HashTagQueryResult()
                {
                    Id = entity.Id,
                    HashTag = entity.HashTag,
                    IsEnabled = entity.IsEnabled
                };

                results.HashTags.Add(result);
            }
            return results;
        }
    }
}
