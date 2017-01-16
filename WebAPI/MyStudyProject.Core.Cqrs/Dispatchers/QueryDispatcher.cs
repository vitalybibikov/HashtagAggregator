using System.Collections.Generic;
using System.Threading.Tasks;

using Autofac;

using MyStudyProject.Core.Contracts.Interface;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;
using MyStudyProject.Core.Cqrs.Abstract;

namespace MyStudyProject.Core.Cqrs.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly ILifetimeScope container;
        private IRequestFilter requestFilter;

        public QueryDispatcher(ILifetimeScope container, IRequestFilter requestFilter)
        {
            this.container = container;
            this.requestFilter = requestFilter;
        }

        public async Task<TResult> DispatchAsync<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IQueryResult, new()
        {
            var compositeHandler = container.Resolve<CompositeQueryHandler<TParameter, TResult>>();
            var handlers = container.Resolve<IList<IQueryHandler<TParameter, TResult>>>();

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
