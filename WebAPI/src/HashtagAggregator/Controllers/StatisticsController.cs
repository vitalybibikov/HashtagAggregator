using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HashtagAggregator.Core.Models.Queries;
using HashtagAggregator.Shared.Common.Infrastructure;
using HashtagAggregator.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HashtagAggregator.Controllers
{
    [Route("api/[controller]")]
    public class StatisticsController : Controller
    {
        private readonly IMediator mediator;

        private IMapper Mapper { get; }

        public StatisticsController(IMapper mapper, IMediator mediator)
        {
            this.mediator = mediator;
            Mapper = mapper;
        }

        /// <summary>
        /// Returns a set of messages by hashtag from social networks.
        /// </summary>
        /// <param name="hashtag">Hashtag you need to find</param>
        [HttpGet("{hashtag:required}")]
        [ResponseCache(CacheProfileName = "Default")]
        public async Task<IEnumerable<MessageViewModel>> Get(string hashtag)
        {
            var query = new MessagesQuery {HashTag = new HashTagWord(hashtag)};
            var result = await mediator.Send(query);
            return Mapper.Map<IEnumerable<MessageViewModel>>(result.Messages);
        }
    }
}