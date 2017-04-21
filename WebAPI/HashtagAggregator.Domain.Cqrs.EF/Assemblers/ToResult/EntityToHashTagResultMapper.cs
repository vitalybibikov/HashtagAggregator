using System.Collections.Generic;

using HashtagAggregator.Core.Entities.EF;
using HashtagAggregator.Core.Models.Results.Query.HashTag;
using HashtagAggregator.Shared.Common.Infrastructure;

namespace HashtagAggregator.Domain.Cqrs.EF.Assemblers.ToResult
{
    public class EntityToHashTagResultMapper
    {
        public HashTagsQueryResult MapBunch(IEnumerable<HashTagEntity> tags)
        {
            var results = new HashTagsQueryResult();
            foreach (var entity in tags)
            {
                var result = new HashTagQueryResult
                {
                    Id = entity.Id,
                    HashTag = new HashTagWord(entity.HashTag),
                    IsEnabled = entity.IsEnabled,
                    ParentId =  entity.ParentId
                };

                results.HashTags.Add(result);
            }
            return results;
        }
    }
}
