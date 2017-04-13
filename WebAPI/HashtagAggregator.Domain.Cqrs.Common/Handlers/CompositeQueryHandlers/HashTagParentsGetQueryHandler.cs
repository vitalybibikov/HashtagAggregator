using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using HashtagAggregator.Core.Contracts.Interface.Cqrs.Query;
using HashtagAggregator.Core.Cqrs.Abstract;
using HashtagAggregator.Core.Models.Queries;
using HashtagAggregator.Core.Models.Results.Query.HashTag;

namespace HashtagAggregator.Domain.Cqrs.Common.Handlers.CompositeQueryHandlers
{
    public class HashTagParentsGetQueryHandler : CompositeQueryHandler<HashTagParentsGetQuery, HashTagsQueryResult>
    {
        public HashTagParentsGetQueryHandler(ILogger logger) : base(logger)
        {
        }

        protected override async Task<HashTagsQueryResult> GetDataAsync(HashTagParentsGetQuery query)
        {
            var list = new HashTagsQueryResult();
            List<HashTagsQueryResult> results = await RunHandlers(RunHandler, query);
            list.HashTags.AddRange(results.SelectMany(x => x.HashTags));
            return list;
        }

        protected override async Task<HashTagsQueryResult> RunHandler(
            IQueryHandler<HashTagParentsGetQuery, HashTagsQueryResult> handler, HashTagParentsGetQuery query)
        {
            var tagsQueryResult = await handler.GetAsync(query);
            return tagsQueryResult;
        }
    }
}