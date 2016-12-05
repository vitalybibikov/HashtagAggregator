using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using MyStudyProject.Core.Contracts.Abstract;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;
using MyStudyProject.Core.Models.Queries;
using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Data.DataAccess.Context;
using MyStudyProject.Domain.Cqrs.EF.Assemblers;

namespace MyStudyProject.Domain.Cqrs.EF.Handlers
{
    public class EfMessagesGetQueryHandler : QueryHandler<MessagesGetQuery, MessagesQueryResult>, IQueryHandler<MessagesGetQuery, MessagesQueryResult>
    {
        private readonly SqlApplicationDbContext context;

        public EfMessagesGetQueryHandler(SqlApplicationDbContext context)
        {
            this.context = context;
        }

        public override async Task<MessagesQueryResult> GetAsync(MessagesGetQuery query)
        {
            EntityToMessagesResultMapper mapper = new EntityToMessagesResultMapper();
            var result = await context.Messages.Where(x => x.HashTag == query.HashTag).ToListAsync();
            return mapper.MapBunch(result, query.HashTag);
        }
    }
}
