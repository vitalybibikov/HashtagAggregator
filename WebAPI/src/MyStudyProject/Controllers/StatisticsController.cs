using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;
using MyStudyProject.Core.Models.Queries;
using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.ViewModels;

namespace MyStudyProject.Controllers
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
        [HttpGet("{hashtag}")]
        public async Task<IEnumerable<MessageViewModel>> Get(string hashtag)
        {
            if (!hashtag.StartsWith("#"))
            {
                hashtag = "#" + hashtag;
            }
            MessageGetQuery query  = new MessageGetQuery();
            var result = queryDispatcher.Dispatch<MessageGetQuery, MessagesQueryResult>(query);
            var models = Mapper.Map<IEnumerable<MessageViewModel>>(result);
            return models;
        }

        // GET: api/statistics/
        public async Task<IEnumerable<MessageViewModel>> Get(string hashtag, long id)
        {
            if (!hashtag.StartsWith("#"))
            {
                hashtag = "#" + hashtag;
            }
            MessageGetQuery query = new MessageGetQuery();
            var result = queryDispatcher.Dispatch<MessageGetQuery, MessagesQueryResult>(query);
            var models = Mapper.Map<IEnumerable<MessageViewModel>>(result);
            return models;
        }
    }
}
