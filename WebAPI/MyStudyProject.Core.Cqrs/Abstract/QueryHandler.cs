using System;
using System.Threading.Tasks;

using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;

namespace MyStudyProject.Core.Cqrs.Abstract
{
    public abstract class QueryHandler<TParameter, TResult> : ICompositeQueryHandler<TParameter, TResult>
         where TResult : IQueryResult, new()
         where TParameter : IQuery
    {
        public virtual void Add(IQueryHandler<TParameter, TResult> queryHandler)
        {
            throw new InvalidOperationException();
        }

        public async Task<TResult> GetAsync(TParameter query)
        {
            return await FilterStrategy(GetDataAsync(query));
        }
        protected abstract Task<TResult> GetDataAsync(TParameter query);

        protected Task<TResult> FilterStrategy(Task<TResult> query)
        {
            return query;
        }

        public virtual bool Remove(IQueryHandler<TParameter, TResult> queryHandler)
        {
            throw new InvalidOperationException();
        }
    }
}
