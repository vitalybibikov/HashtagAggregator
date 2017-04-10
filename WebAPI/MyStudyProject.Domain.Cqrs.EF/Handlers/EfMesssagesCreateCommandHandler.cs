using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyStudyProject.Core.Cqrs.Abstract;
using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Core.Models.Interface.Cqrs.Command;
using MyStudyProject.Core.Models.Queries;
using MyStudyProject.Data.DataAccess.Context;
using MyStudyProject.Domain.Cqrs.EF.Assemblers;

namespace MyStudyProject.Domain.Cqrs.EF.Handlers
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
            MessagesCommandToEntityMapper mapper = new MessagesCommandToEntityMapper();
            var items = mapper.MapBunch(command.Messages);

            //todo: refactor. this should be slow.
            var newMessages = items
                .Where(x => !context.Messages.Any(z => z.NetworkId == x.NetworkId && z.User != null && x.User != null && z.User.NetworkId == x.User.NetworkId)).ToList();
            var users = newMessages.Select(x => x.User)
                .GroupBy(x => x.NetworkId)
                .Select(g => g.First());

            var newUsers = users
                .Where(user => !context.Users.Any(x => x.NetworkId == user.NetworkId)).ToList();

            await context.Users.AddRangeAsync(newUsers);
            context.SaveChanges();

            foreach (var message in newMessages)
            {
                message.User = context.Users.FirstOrDefault(x => x.NetworkId == message.User.NetworkId);
                message.PostDate = message.PostDate?.ToUniversalTime();
            }
            await context.Messages.AddRangeAsync(newMessages);
            context.SaveChanges();

            return new CommandResult { Success = true };
        }
    }
}
