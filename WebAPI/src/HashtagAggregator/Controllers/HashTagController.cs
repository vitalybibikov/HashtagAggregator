using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HashtagAggregator.Core.Models.Queries;
using HashtagAggregator.Shared.Common.Infrastructure;
using HashtagAggregator.ViewModels;
using MediatR;

namespace HashtagAggregator.Controllers
{
    [Route("api/[controller]")]
    public class HashTagController : Controller
    {
        private readonly IMediator mediator;
        private IMapper Mapper { get; }

        public HashTagController(IMapper mapper, IMediator mediator)
        {
            this.mediator = mediator;
            Mapper = mapper;
        }

        // GET: api/hashtag/parent
        [HttpGet("parent")]
        public async Task<IEnumerable<HashtagViewModel>> Get()
        {
            var query = new HashTagParentsQuery {IsParent = true};
            var result = await mediator.Send(query);
            var results = Mapper.Map<IEnumerable<HashtagViewModel>>(result.HashTags);
            return results;
        }

        [HttpGet("children/{id:long}")]
        public async Task<IEnumerable<HashtagViewModel>> Get(long id)
        {
            var query = new HashTagsQuery {ParentId = id};
            var result = await mediator.Send(query);
            var results = Mapper.Map<IEnumerable<HashtagViewModel>>(result.HashTags);
            return results;
        }

        [HttpGet("children/{parentName}")]
        public async Task<IEnumerable<HashtagViewModel>> Get(string parentName)
        {
            var query = new HashTagByParentNameQuery {HashTag = new HashTagWord(parentName)};
            var result = await mediator.Send(query);
            var results = Mapper.Map<IEnumerable<HashtagViewModel>>(result.HashTags);
            return results;
        }
    }
}