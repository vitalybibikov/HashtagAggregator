using System;
using System.Threading.Tasks;
using HashtagAggregator.Core.Cqrs.Abstract;
using HashtagAggregator.Core.Models.Commands;
using HashtagAggregator.Core.Models.Interface.Cqrs.Command;
using HashtagAggregator.Data.DataAccess.Context;

namespace HashtagAggregator.Domain.Cqrs.EF.Handlers.Commands
{
    public class EfHashtagCreateCommandHandler : CommandHandler<MessagesCreateCommand>
    {
        private readonly SqlApplicationDbContext context;

        public EfHashtagCreateCommandHandler(SqlApplicationDbContext context)
        {
            this.context = context;
        }

        public override async Task<ICommandResult> ExecuteAsync(MessagesCreateCommand command)
        {
           throw new NotImplementedException();
        }
    }
}
