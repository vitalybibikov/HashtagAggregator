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
            var userCommandMapper = new UserCommandToEntityMapper();
            var hashMapper = new HashTagCommandToEntityMapper();
            foreach (var message in messages)
            {
                MessageEntity entity = new MessageEntity
                {
                    MessageText = message.MessageText,
                    HashTags = hashMapper.MapBunch(message.HashTags),
                    MediaType = message.MediaType,
                    User = userCommandMapper.MapSingle(message.User),
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

