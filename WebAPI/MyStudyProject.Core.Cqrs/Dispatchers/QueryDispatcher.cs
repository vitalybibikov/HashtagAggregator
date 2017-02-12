using System.Collections.Generic;
using System.Threading.Tasks;

using Autofac;
using Microsoft.Extensions.Logging;
using MyStudyProject.Core.Contracts.Interface;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;
using MyStudyProject.Core.Cqrs.Abstract;
using MyStudyProject.Core.Models.Interface.Cqrs.Query;

namespace MyStudyProject.Core.Cqrs.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly ILifetimeScope container;
        private IRequestFilter requestFilter;
        private readonly ILogger logger;

        public QueryDispatcher(ILifetimeScope container, IRequestFilter requestFilter, ILogger<QueryDispatcher> logger)
        {
            this.container = container;
            this.requestFilter = requestFilter;
            this.logger = logger;
        }

        public async Task<TResult> DispatchAsync<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IQueryResult, new()
        {
            var typedParameter = new TypedParameter(typeof(ILogger), logger);

            var compositeHandler = container.Resolve<CompositeQueryHandler<TParameter, TResult>>(typedParameter);
            var handlers = container.Resolve<IList<IQueryHandler<TParameter, TResult>>>(typedParameter);

            foreach (IQueryHandler<TParameter, TResult> handler in handlers)
            {
                if (handler.GetType() != compositeHandler.GetType())
                {
                    var requestAllowed = await requestFilter.IsRequestAllowed(handler);
                    if (requestAllowed)
                    {
                        compositeHandler.Add(handler);
                    }
                }
            }
            return await compositeHandler.GetAsync(query);
        }
    }
}
