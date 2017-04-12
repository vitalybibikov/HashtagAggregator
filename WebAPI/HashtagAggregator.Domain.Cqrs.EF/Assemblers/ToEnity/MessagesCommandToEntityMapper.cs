using System.Collections.Generic;
using HashtagAggregator.Core.Entities.EF;
using HashtagAggregator.Core.Models.Commands;

namespace HashtagAggregator.Domain.Cqrs.EF.Assemblers.ToEnity
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
                    MessageText = message.MessageText,
                    HashTag = message.HashTag,
                    MediaType = message.MediaType,
                    User = mapper.MapSingle(message.User),
                    PostDate = message.PostDate,
                    Id = message.Id,
                    NetworkId =  message.NetworkId
                };
                results.Add(entity);
            }
            return results;
        }
    }
}

