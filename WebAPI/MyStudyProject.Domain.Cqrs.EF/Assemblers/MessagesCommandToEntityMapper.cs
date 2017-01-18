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
                    MediaType = message.MediaType,
                    NetworkId = message.NetworkId,
                    PostDate = message.PostDate,
                    UserId =  message.UserId,
                    Id = message.Id
                };
                results.Add(entity);
            }
            return results;
        }
    }
}

