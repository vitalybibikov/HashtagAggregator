using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using HashtagAggregator.Core.Models.Queries;
using HashtagAggregator.Core.Models.Results.Query;
using HashtagAggregator.Data.DataAccess.Context;
using HashtagAggregator.Domain.Cqrs.EF.Abstract;
using HashtagAggregator.Domain.Cqrs.EF.Assemblers;
using HashtagAggregator.Domain.Cqrs.EF.Assemblers.ToResult;

namespace HashtagAggregator.Domain.Cqrs.EF.Handlers
{
    public class EfMessagesGetQueryHandler : EfQueryHandler<MessagesGetQuery, MessagesQueryResult>
    {
        public EfMessagesGetQueryHandler(SqlApplicationDbContext context) : base(context)
        {
        }

        protected override async Task<MessagesQueryResult> GetDataAsync(MessagesGetQuery query)
        {
            var mapper = new EntityToMessagesResultMapper();
            var result = await Context.Messages.Where(x => x.HashTag == query.HashTag).Include(x => x.User).ToListAsync();
            return mapper.MapBunch(result, query.HashTag);
        }
    }
}
