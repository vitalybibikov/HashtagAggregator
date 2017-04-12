using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using HashtagAggregator.Core.Models.Queries;
using HashtagAggregator.Core.Models.Results.Query;
using HashtagAggregator.Data.DataAccess.Context;
using HashtagAggregator.Domain.Cqrs.EF.Abstract;
using HashtagAggregator.Domain.Cqrs.EF.Assemblers.ToResult;

namespace HashtagAggregator.Domain.Cqrs.EF.Handlers
{
    public class EfHashtagGetQueryHandler : EfQueryHandler<HashTagsGetQuery, HashTagsQueryResult>
    {
        public EfHashtagGetQueryHandler(SqlApplicationDbContext context) : base(context)
        {
        }

        protected override async Task<HashTagsQueryResult> GetDataAsync(HashTagsGetQuery query)
        {
            var mapper = new EntityToHashTagResultMapper();
            var result = await Context.Hashtags.ToListAsync();
            return mapper.MapBunch(result);
        }
    }
}
