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
            UserCommandToEntityMapper mapper = new UserCommandToEntityMapper();
            foreach (var message in messages)
            {
                MessageEntity entity = new MessageEntity
                {
                    MessageText = message.Body,
                    HashTag = message.HashTag,
                    MediaType = message.MediaType,
                    User = mapper.MapSingle(message.User),
                    PostDate = message.PostDate,
                    Id = message.Id,
                    UserId = message.UserId,
                    NetworkId =  message.NetworkId
                };
                results.Add(entity);
            }
            return results;
        }
    }
}

