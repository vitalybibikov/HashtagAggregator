using System;
using System.Collections.Generic;

using HashtagAggregator.Core.Entities.EF;
using HashtagAggregator.Core.Models.Results.Query.HashTag;
using HashtagAggregator.Core.Models.Results.Query.Message;
using HashtagAggregator.Shared.Common.Infrastructure;
using HashtagAggregator.Shared.Contracts.Enums;

namespace HashtagAggregator.Domain.Cqrs.EF.Assemblers.ToResult
{
    public class EntityToMessagesResultMapper
    {
        public MessagesQueryResult MapBunch(IEnumerable<MessageEntity> messages, HashTagWord hashtag)
        {
            var results = new MessagesQueryResult();
            foreach (var entity in messages)
            {
                SocialMediaType mediaType;
                Enum.TryParse(entity.MediaType.ToString(), out mediaType);
                var mapper = new EntityToUserResultMapper();

                var message = new MessageQueryResult
                {
                    Id = entity.Id,
                    MessageText = entity.MessageText,
                    HashTags = new List<HashTagQueryResult>
                    {
                        new HashTagQueryResult
                        {
                            HashTag = hashtag
                        }
                    },
                    MediaType = mediaType,
                    PostDate = entity.PostDate,
                    NetworkId = entity.NetworkId,
                    User = mapper.MapSingle(entity.User)
                };
                results.Messages.Add(message);
            }
            return results;
        }
    }
}