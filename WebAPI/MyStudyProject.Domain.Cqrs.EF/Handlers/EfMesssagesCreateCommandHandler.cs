using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MyStudyProject.Core.Contracts.Abstract;
using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;
using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Core.Models.Results.Command;
using MyStudyProject.Data.DataAccess.Context;
using MyStudyProject.Domain.Cqrs.EF.Assemblers;

namespace MyStudyProject.Domain.Cqrs.EF.Handlers
{
    public class EfMesssagesCreateCommandHandler : CommandHandler<MessagesCreateCommand>, ICommandHandler<MessagesCreateCommand>
    {
        private readonly SqlApplicationDbContext context;

        public EfMesssagesCreateCommandHandler(SqlApplicationDbContext context)
        {
            this.context = context;
        }

        public override async Task<ICommandResult> ExecuteAsync(MessagesCreateCommand command)
        {
            MessagesCommandToEntityMapper mapper = new MessagesCommandToEntityMapper();
            var result = mapper.MapBunch(command.Messages.Where(m => m.Id <= 0));
            await context.Messages.AddRangeAsync(result);
            context.SaveChanges();
            return new CommandResult {Success = true};
        }

        public override Task<ICommandResult> ExecuteAsync(List<MessagesCreateCommand> command)
        {
            throw new NotImplementedException();
        }
    }
}
