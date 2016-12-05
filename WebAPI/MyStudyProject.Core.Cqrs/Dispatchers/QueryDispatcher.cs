using System.Collections.Generic;
using System.Threading.Tasks;

using Autofac;

using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;

namespace MyStudyProject.Core.Cqrs.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext container;

        public QueryDispatcher(IComponentContext container)
        {
            this.container = container;
        }

        public async Task<TResult> DispatchAsync<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IQueryResult
        {
            //var results = container.ComponentRegistry.Registrations.SelectMany(x => x.Services);
            var compositeHandler = container.Resolve<ICompositeQueryHandler<TParameter, TResult>>();
            var handlers = container.Resolve<IList<IQueryHandler<TParameter, TResult>>>();

            foreach (var handler in handlers)
            {
                if (handler.GetType() != compositeHandler.GetType())
                {
                    compositeHandler.Add(handler);
                }
            }
            return await compositeHandler.GetAsync(query);
        }
    }
}
