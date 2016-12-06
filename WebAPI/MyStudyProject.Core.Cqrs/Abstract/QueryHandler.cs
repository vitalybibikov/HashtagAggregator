using System;
using System.Threading.Tasks;

using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;
using MyStudyProject.Shared.Common;
using MyStudyProject.Shared.Common.UpdateStrategies;

namespace MyStudyProject.Core.Cqrs.Abstract
{
    public abstract class QueryHandler<TParameter, TResult> : ICompositeQueryHandler<TParameter, TResult>
         where TResult : IQueryResult, new()
         where TParameter : IQuery
    {
        protected QueryHandler()
        {
            UpdateStrategy = new DefaultUpdateStrategy();
        }

        public virtual void Add(IQueryHandler<TParameter, TResult> queryHandler)
        {
            throw new InvalidOperationException();
        }

        public async Task<TResult> GetAsync(TParameter query)
        {
            TResult result = new TResult();
            if (UpdateStrategy.IsOperationAllowed())
            {
                result = await GetDataAsync(query);
            }
            return result;
        }

        protected abstract Task<TResult> GetDataAsync(TParameter query);

        protected IUpdateStrategy UpdateStrategy { get; set; }

        public virtual bool Remove(IQueryHandler<TParameter, TResult> queryHandler)
        {
            throw new InvalidOperationException();
        }
    }
}
