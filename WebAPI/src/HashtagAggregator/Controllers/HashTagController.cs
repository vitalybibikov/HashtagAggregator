using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using HashtagAggregator.Core.Contracts.Interface.Cqrs.Query;
using HashtagAggregator.Core.Models.Queries;
using HashtagAggregator.Core.Models.Results.Query.HashTag;
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
            Mapper = mapper;
        }

        // GET: api/hashtag/parent
        [HttpGet("parent")]
        public async Task<IEnumerable<HashtagViewModel>> Get()
        {
            var query = new HashTagParentsQuery { IsParent = true };
            var result = await queryDispatcher.DispatchAsync<HashTagParentsQuery, HashTagsQueryResult>(query);
            var results = Mapper.Map<IEnumerable<HashtagViewModel>>(result.HashTags);
            return results;
        }

        [HttpGet("children/{id:long}")]
        public async Task<IEnumerable<HashtagViewModel>> Get(long id)
        {
            var query = new HashTagsQuery { ParentId = id };
            var result = await queryDispatcher.DispatchAsync<HashTagsQuery, HashTagsQueryResult>(query);
            var results = Mapper.Map<IEnumerable<HashtagViewModel>>(result.HashTags);
            return results;
        }

        [HttpGet("children/{parentName}")]
        public async Task<IEnumerable<HashtagViewModel>> Get(string parentName)
        {
            var query = new HashTagByParentNameQuery { HashTag = parentName };
            var result = await queryDispatcher.DispatchAsync<HashTagByParentNameQuery, HashTagsQueryResult>(query);
            var results = Mapper.Map<IEnumerable<HashtagViewModel>>(result.HashTags);
            return results;
        }
    }
}
