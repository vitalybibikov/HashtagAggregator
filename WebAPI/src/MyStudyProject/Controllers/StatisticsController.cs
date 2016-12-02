using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using MyStudyProject.Core.Contracts.Interface.ServiceFacades;
using MyStudyProject.Core.Cqrs.Results;
using MyStudyProject.ViewModels;

namespace MyStudyProject.Controllers
{
    [Route("api/[controller]")]
    public class StatisticsController : Controller
    {
        private readonly IMessageServiceFacade<MessageQueryResult> service;
        private IMapper Mapper { get; }

        public StatisticsController(IMapper mapper, IMessageServiceFacade<MessageQueryResult> service)
        {
            this.service = service;
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

            var messages = await service.GetAllAsync(hashtag);
            var models = Mapper.Map<IEnumerable<MessageViewModel>>(messages);
            return models;
        }

        // GET: api/statistics/
        public async Task<IEnumerable<MessageViewModel>> Get(string hashtag, long id)
        {
            if (!hashtag.StartsWith("#"))
            {
                hashtag = "#" + hashtag;
            }

            var messages = await service.GetSinceLastIdAsync(id, hashtag);
            var models = Mapper.Map<IEnumerable<MessageViewModel>>(messages);
            return models;
        }
    }
}
