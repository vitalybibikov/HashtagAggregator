using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;

using HashtagAggregator.Core.Contracts.Interface;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Query;
using HashtagAggregator.Core.Cqrs.Abstract;
using Microsoft.Extensions.Logging;

namespace HashtagAggregator.Core.Cqrs.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly ILifetimeScope container;
        private readonly IRequestFilter requestFilter;
        private readonly ILogger logger;

        public QueryDispatcher(ILifetimeScope container, IRequestFilter requestFilter, ILogger<QueryDispatcher> logger)
        {
            this.container = container;
            this.requestFilter = requestFilter;
            this.logger = logger;
        }

        public async Task<TResult> DispatchMultipleAsync<TParameter, TResult>(TParameter query)
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

        public async Task<TResult> DispatchAsync<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IQueryResult, new()
        {
            var result = new TaskCompletionSource<TResult>();

            var typedParameter = new TypedParameter(typeof(ILogger), logger);
            var handler = container.Resolve<IQueryHandler<TParameter, TResult>>(typedParameter);
            var requestAllowed = await requestFilter.IsRequestAllowed(handler);

            if (requestAllowed)
            {
                result.SetResult(await handler.GetAsync(query));
            }
            else
            {
                result.SetResult(default(TResult));
            }
            return await result.Task;
        }
    }
}
