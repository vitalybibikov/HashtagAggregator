using System;
using System.Collections.Generic;

using MyStudyProject.Core.Contracts.Interface;
using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Data.Entities.Entities;
using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.Domain.Cqrs.EF.Assemblers
{
    public class EntityToMessagesResultMapper : IMapper<MessageEntity, MessagesQueryResult>
    {
        public MessagesQueryResult MapBunch(IEnumerable<MessageEntity> messages, string hashtag)
        {
            var results = new MessagesQueryResult();
            foreach (var entity in messages)
            {
                MessageQueryResult message = new MessageQueryResult(
                    entity.Id,
                    entity.Body,
                    hashtag,
                    SocialMediaType.Twitter,
                    entity.PostDate,
                    entity.NetworkId,
                    entity.UserId);
                results.Messages.Add(message);
            }
            return results;
        }
    }
}
