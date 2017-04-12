using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using HashtagAggregator.Core.Contracts.Interface.Cqrs.Query;
using HashtagAggregator.Core.Cqrs.Abstract;
using HashtagAggregator.Core.Models.Queries;
using HashtagAggregator.Core.Models.Results.Query;

namespace HashtagAggregator.Domain.Cqrs.Common.Handlers.CompositeQueryHandlers
{
    public class HashTagsGetQueryHandler : CompositeQueryHandler<HashTagsGetQuery, HashTagsQueryResult>
    {
        public HashTagsGetQueryHandler(ILogger logger) : base(logger)
        {
        }

        protected override async Task<HashTagsQueryResult> GetDataAsync(HashTagsGetQuery query)
        {
            var list = new HashTagsQueryResult();
            List<HashTagsQueryResult> results = await RunHandlers(RunHandler, query);
            list.HashTags.AddRange(results.SelectMany(x => x.HashTags));
            return list;
        }

        protected override async Task<HashTagsQueryResult> RunHandler(
            IQueryHandler<HashTagsGetQuery, HashTagsQueryResult> handler, HashTagsGetQuery query)
        {
            var tagsQueryResult = await handler.GetAsync(query);
            return tagsQueryResult;
        }
    }
}