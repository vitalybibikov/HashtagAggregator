using System;
using System.Collections.Generic;

using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Data.Entities.Entities;
using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.Domain.Cqrs.EF.Assemblers
{
    public class EntityToMessagesResultMapper
    {
        public MessagesQueryResult MapBunch(IEnumerable<MessageEntity> messages, string hashtag)
        {
            var results = new MessagesQueryResult();
            foreach (var entity in messages)
            {
                EntityToUserResultMapper mapper = new EntityToUserResultMapper();
                MessageQueryResult message = new MessageQueryResult(
                    entity.Id,
                    entity.MessageText,
                    hashtag,
                    SocialMediaType.Twitter,
                    entity.PostDate,
                    entity.NetworkId,
                    mapper.MapSingle(entity.User));

                results.Messages.Add(message);
            }
            return results;
        }
    }
}
