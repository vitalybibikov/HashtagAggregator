using System.Threading.Tasks;
using System.Linq;
using MyStudyProject.Core.Models.Queries;
using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Data.DataAccess.Context;
using MyStudyProject.Domain.Cqrs.EF.Abstract;
using MyStudyProject.Domain.Cqrs.EF.Assemblers;
using Microsoft.EntityFrameworkCore;

namespace MyStudyProject.Domain.Cqrs.EF.Handlers
{
    public class EfMessagesGetQueryHandler : EfQueryHandler<MessagesGetQuery, MessagesQueryResult>
    {
        public EfMessagesGetQueryHandler(SqlApplicationDbContext context) : base(context)
        {
        }

        protected override async Task<MessagesQueryResult> GetDataAsync(MessagesGetQuery query)
        {
            EntityToMessagesResultMapper mapper = new EntityToMessagesResultMapper();
            var result = await Context.Messages.Where(x => x.HashTag == query.HashTag).Include(x => x.User).ToListAsync();
            return mapper.MapBunch(result, query.HashTag);
        }
    }
}
