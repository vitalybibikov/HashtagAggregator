using System.Linq;
using System.Threading.Tasks;

using HashtagAggregator.Core.Cqrs.Abstract;
using HashtagAggregator.Core.Entities.EF;
using HashtagAggregator.Core.Models.Commands;
using HashtagAggregator.Core.Models.Interface.Cqrs.Command;
using HashtagAggregator.Core.Models.Results;
using HashtagAggregator.Data.DataAccess.Context;
using HashtagAggregator.Domain.Cqrs.EF.Assemblers.ToEnity;

namespace HashtagAggregator.Domain.Cqrs.EF.Handlers.Commands
{
    public class EfMesssagesCreateCommandHandler : CommandHandler<MessagesCreateCommand>
    {
        private readonly SqlApplicationDbContext context;

        public EfMesssagesCreateCommandHandler(SqlApplicationDbContext context)
        {
            this.context = context;
        }

        public override async Task<ICommandResult> ExecuteAsync(MessagesCreateCommand command)
        {
            //todo: consider refactoring to speed up the insert. 

            var mapper = new MessagesCommandToEntityMapper();

            var incomingMessages = mapper.MapBunch(command.Messages);
            var newMessages = incomingMessages
                .Where(x => !context.Messages.Any(z => z.NetworkId == x.NetworkId && z.User != null && x.User != null && z.User.NetworkId == x.User.NetworkId)).ToList();

            var incomingUsers = newMessages.Select(x => x.User)
                .GroupBy(x => x.NetworkId)
                .Select(g => g.First());

            var newUsers = incomingUsers
                .Where(user => !context.Users.Any(x => x.NetworkId == user.NetworkId)).ToList();

            await context.Users.AddRangeAsync(newUsers);
            context.SaveChanges();

            foreach (var message in newMessages)
            {
                message.User = context.Users.FirstOrDefault(x => x.NetworkId == message.User.NetworkId);
                message.PostDate = message.PostDate?.ToUniversalTime();
                context.Messages.Add(message);
                foreach (var tag in message.HashTags)
                {
                    var tagToLink = context.Hashtags.FirstOrDefault(x => x.HashTag == tag.HashTag) ?? tag;

                    var tag2Message = new MessageHashTagRelationsEntity
                    {
                        HashTagEntity = tagToLink,
                        MessageEntity = message
                    };
                    context.TaggedMessages.Add(tag2Message);

                    if (tagToLink.IsNew)
                    {
                        context.Hashtags.Add(tagToLink);
                    }
                }

            }
            context.SaveChanges();
            return new CommandResult { Success = true };
        }
    }
}
