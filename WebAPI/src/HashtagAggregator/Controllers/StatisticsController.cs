using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Query;
using HashtagAggregator.Core.Models.Commands;
using HashtagAggregator.Core.Models.Queries;
using HashtagAggregator.Core.Models.Results.Query;
using HashtagAggregator.Core.Models.Results.Query.Message;
using HashtagAggregator.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace HashtagAggregator.Controllers
{
    [Route("api/[controller]")]
    public class StatisticsController : Controller
    {
        private readonly IQueryDispatcher queryDispatcher;
        private readonly ICommandDispatcher commandDispatcher;

        private IMapper Mapper { get; }

        public StatisticsController(IMapper mapper, IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
            this.commandDispatcher = commandDispatcher;
            this.Mapper = mapper;
        }

        // GET: api/statistics/
        [HttpGet("{hashtag:required}")]
        [ResponseCache(CacheProfileName = "Default")]
        public async Task<IEnumerable<MessageViewModel>> Get(string hashtag)
        {
            var query = new MessagesGetQuery { HashTag = hashtag };
            var result = await queryDispatcher.DispatchAsync<MessagesGetQuery, MessagesQueryResult>(query);
            await commandDispatcher.DispatchAsync(Mapper.Map<MessagesCreateCommand>(result));
            return Mapper.Map<IEnumerable<MessageViewModel>>(result.Messages);
        }
    }
}
