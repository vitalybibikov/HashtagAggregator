using System;
using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregator.Core.Cqrs.Abstract;
using HashtagAggregator.Core.Models.Commands;
using HashtagAggregator.Data.DataAccess.Context;

namespace HashtagAggregator.Domain.Cqrs.EF.Handlers.Commands
{
    public class EfHashtagCreateCommandHandler : CommandHandler<HashTagCreateCommand>
    {
        private readonly SqlApplicationDbContext context;

        public EfHashtagCreateCommandHandler(SqlApplicationDbContext context)
        {
            this.context = context;
        }

        public override async Task<ICommandResult> ExecuteAsync(HashTagCreateCommand command)
        {
           throw new NotImplementedException();
        }
    }
}
