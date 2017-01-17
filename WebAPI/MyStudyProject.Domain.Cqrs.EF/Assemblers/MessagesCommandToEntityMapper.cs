using System.Collections.Generic;

using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Data.Entities.Entities;

namespace MyStudyProject.Domain.Cqrs.EF.Assemblers
{
    public class MessagesCommandToEntityMapper
    {
        public List<MessageEntity> MapBunch(IEnumerable<MessageCreateCommand> messages)
        {
            var results = new List<MessageEntity>();
            foreach (var message in messages)
            {
                MessageEntity entity = new MessageEntity
                {
                    Body = message.Body,
                    HashTag = message.HashTag,
                    MediaType = message.Media,
                    NetworkId = message.NetworkId,
                    PosedDate = message.PostDate,
                    UserId =  message.UserId
                };
                results.Add(entity);
            }
            return results;
        }
    }
}

