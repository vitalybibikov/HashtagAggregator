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
                MessageQueryResult message = new MessageQueryResult
                {
                    Body = entity.Body,
                    HashTag = hashtag,
                    Id = entity.Id,
                    PostDate = entity.PosedDate,
                    Media = SocialMediaType.Twitter,
                    NetworkId = entity.NetworkId.ToString(),
                };
                results.Messages.Add(message);
            }
            return results;
        }
    }
}
