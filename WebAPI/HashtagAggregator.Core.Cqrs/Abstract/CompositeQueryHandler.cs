using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Query;
using HashtagAggregator.Shared.Logging;
using Microsoft.Extensions.Logging;

namespace HashtagAggregator.Core.Cqrs.Abstract
{
    public abstract class CompositeQueryHandler<TParameter, TResult> : QueryHandler<TParameter, TResult>
        where TResult : IQueryResult, new()
        where TParameter : IQuery
    {
        private readonly ILogger logger;
        private readonly List<IQueryHandler<TParameter, TResult>> handlers;

        public List<IQueryHandler<TParameter, TResult>> Handlers => handlers;

        protected CompositeQueryHandler(ILogger logger)
        {
            this.logger = logger;
            handlers = new List<IQueryHandler<TParameter, TResult>>();
        }

        protected async Task<List<TResult>> RunHandlers(
            Func<IQueryHandler<TParameter, TResult>, TParameter, Task<TResult>> func, TParameter query)
        {
            List<TResult> list = new List<TResult>();
            foreach (var handler in Handlers)
            {
                if (func != null)
                {
                    try
                    {
                        var result = await func(handler, query);
                        list.Add(result);
                    }
                    catch (Exception ex)
                    {
                        logger.LogCritical(
                            LoggingEvents.EXCEPTION_EXECUTE_QUERY,
                            ex,
                            "Failed to execute {@query} with {@handler} ",
                            query,
                            handler);
                    }
                }
            }
            return list;
        }

        protected abstract Task<TResult> RunHandler(IQueryHandler<TParameter, TResult> handler, TParameter query);

        public override void Add(IQueryHandler<TParameter, TResult> queryHandler)
        {
            handlers.Add(queryHandler);
        }

        public override bool Remove(IQueryHandler<TParameter, TResult> queryHandler)
        {
            return handlers.Remove(queryHandler);
        }
    }
}
