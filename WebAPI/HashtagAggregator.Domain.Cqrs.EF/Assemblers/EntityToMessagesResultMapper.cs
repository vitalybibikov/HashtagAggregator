using System;
using System.Collections.Generic;
using HashtagAggregator.Core.Entities.EF;
using HashtagAggregator.Core.Models.Results.Query;
using HashtagAggregator.Shared.Contracts.Enums;

namespace HashtagAggregator.Domain.Cqrs.EF.Assemblers
{
    public class EntityToMessagesResultMapper
    {
        public MessagesQueryResult MapBunch(IEnumerable<MessageEntity> messages, string hashtag)
        {
            var results = new MessagesQueryResult();
            foreach (var entity in messages)
            {
                SocialMediaType mediaType;
                Enum.TryParse(entity.MediaType.ToString(), out mediaType);
                EntityToUserResultMapper mapper = new EntityToUserResultMapper();
                MessageQueryResult message = new MessageQueryResult(
                    entity.Id,
                    entity.MessageText,
                    hashtag,
                    mediaType,
                    entity.PostDate,
                    entity.NetworkId,
                    mapper.MapSingle(entity.User));

                results.Messages.Add(message);
            }
            return results;
        }
    }
}
