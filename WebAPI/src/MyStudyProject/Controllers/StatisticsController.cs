using System;
using System.Collections.Generic;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Cqrs.Results;
using MyStudyProject.ViewModels;
using MyStudyProject.Core.Models.Queries;

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
        [HttpGet("{id}")]
        public IEnumerable<MessageViewModel> Get(int id = 5)
        {
            MessageViewModel model = new MessageViewModel () { Id = 5, Body = "123"};
            var view = Mapper.Map<MessageViewModel, MessagesQuery>(model);
            var result = queryDispatcher.Dispatch<MessagesQuery, MessageQueryResult>(view);
            throw new NotImplementedException();
        }

        //// GET: api/statistics/amount
        //[HttpGet("{amount}")]
        //public IEnumerable<MessageViewModel> Get(int amount)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
