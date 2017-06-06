using System;
using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Query;

namespace HashtagAggregator.Core.Cqrs.Abstract
{
    public abstract class QueryHandler<TParameter, TResult> : ICompositeQueryHandler<TParameter, TResult>
         where TResult : IQueryResult, new()
         where TParameter : IQuery
    {
        public async Task<TResult> GetAsync(TParameter query)
        {
            TResult data = await GetDataAsync(query);
            return await FilterQuery(data);
        }

        protected abstract Task<TResult> GetDataAsync(TParameter query);

        protected virtual Task<TResult> FilterQuery(TResult query)
        {
            var src = new TaskCompletionSource<TResult>();
            src.SetResult(query);
            return src.Task;
        }

        public virtual void Add(IQueryHandler<TParameter, TResult> queryHandler)
        {
            throw new InvalidOperationException();
        }

        public virtual bool Remove(IQueryHandler<TParameter, TResult> queryHandler)
        {
            throw new InvalidOperationException();
        }
    }
}
