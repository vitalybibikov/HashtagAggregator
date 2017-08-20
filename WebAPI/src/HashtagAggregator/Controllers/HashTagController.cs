using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HashtagAggregator.Core.Models.Queries;
using HashtagAggregator.Shared.Common.Infrastructure;
using HashtagAggregator.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HashtagAggregator.Controllers
{
    [Route("api/[controller]")]
    public class HashTagController : Controller
    {
        private readonly IMediator mediator;
        private readonly ILogger<HashTagController> logger;
        private IMapper Mapper { get; }

        public HashTagController(IMapper mapper, IMediator mediator, ILogger<HashTagController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
            Mapper = mapper;
        }

        /// <summary>
        /// Returns set of allowed parent tags in the system.
        /// </summary>
        [HttpGet("parent")]
        public async Task<IEnumerable<HashtagViewModel>> Get()
        {
            var query = new HashTagParentsQuery {IsParent = true};
            var result = await mediator.Send(query);
            var results = Mapper.Map<IEnumerable<HashtagViewModel>>(result.HashTags);
            return results;
        }

        /// <summary>
        /// Returns a set of child hashtags by parent tag id
        /// </summary>
        /// <param name="id">Id of the parent</param>
        [HttpGet("children/{id:long}")]
        public async Task<IEnumerable<HashtagViewModel>> Get(long id)
        {
            var query = new HashTagsQuery {ParentId = id};
            var result = await mediator.Send(query);
            var results = Mapper.Map<IEnumerable<HashtagViewModel>>(result.HashTags);
            return results;
        }

        /// <summary>
        /// Returns set of hashtags that are realted to parent tag.
        /// </summary>
        /// <param name="parentName">Parent tag for child tags</param>
        [HttpGet("children/{parentName}")]
        public async Task<IEnumerable<HashtagViewModel>> Get(string parentName)
        {
            logger.LogInformation("Information from Get Hashtag");
            var query = new HashTagByParentNameQuery {HashTag = new HashTagWord(parentName)};
            var result = await mediator.Send(query);
            var results = Mapper.Map<IEnumerable<HashtagViewModel>>(result.HashTags);
            return results;
        }
    }
}