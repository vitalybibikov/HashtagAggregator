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
    public class EfHashTagByNameQueryHandler : EfQueryHandler, IEfHashTagByNameQueryHandler
    {
        public EfHashTagByNameQueryHandler(SqlApplicationDbContext context) : base(context)
        {
        }

        public async Task<HashTagsQueryResult> Handle(HashTagByParentNameQuery query)
        {
            var mapper = new EntityToHashTagResultMapper();
            var result = await Context.Hashtags.Where(x => x.Parent.HashTag == query.HashTag).ToListAsync();
            return mapper.MapBunch(result);
        }
    }
}
