using System.Linq;
using System.Threading.Tasks;
using HashtagAggregator.Core.Cqrs.Interface.Queries;
using HashtagAggregator.Core.Models.Queries;
using HashtagAggregator.Core.Models.Results.Query.HashTag;
using HashtagAggregator.Data.DataAccess.Context;
using HashtagAggregator.Domain.Cqrs.EF.Abstract;
using HashtagAggregator.Domain.Cqrs.EF.Assemblers.ToResult;
using Microsoft.EntityFrameworkCore;

namespace HashtagAggregator.Domain.Cqrs.EF.Handlers.Queries
{
    public class EfHashtagGetQueryHandler : EfQueryHandler, IEfHashtagGetQueryHandler
    {
        public EfHashtagGetQueryHandler(SqlApplicationDbContext context) : base(context)
        {
        }

        public async Task<HashTagsQueryResult> Handle(HashTagsQuery query)
        {
            var mapper = new EntityToHashTagResultMapper();
            var result = await Context.Hashtags.Where(
                x => x.ParentId.HasValue && 
                x.ParentId.Value == query.ParentId)
                .ToListAsync();
            return mapper.MapBunch(result);
        }
    }
}
