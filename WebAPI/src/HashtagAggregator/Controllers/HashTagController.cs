using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using HashtagAggregator.Core.Contracts.Interface.Cqrs.Query;
using HashtagAggregator.Core.Models.Queries;
using HashtagAggregator.Core.Models.Results.Query;
using HashtagAggregator.ViewModels;

namespace HashtagAggregator.Controllers
{
    [Route("api/[controller]")]
    public class HashTagController : Controller
    {
        private readonly IQueryDispatcher queryDispatcher;
        private IMapper Mapper { get; }

        public HashTagController(IMapper mapper, IQueryDispatcher queryDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
            this.Mapper = mapper;
        }

        // GET: api/hashtag/
        public async Task<IEnumerable<HashtagViewModel>> Get()
        {
            var query = new HashTagsGetQuery();
            var result = await queryDispatcher.DispatchAsync<HashTagsGetQuery, HashTagsQueryResult>(query);
            var results = Mapper.Map<IEnumerable<HashtagViewModel>>(result.HashTags);
            return results;
        }
    }
}
