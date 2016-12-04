using System;
using System.Threading.Tasks;

using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;

namespace MyStudyProject.Core.Contracts.Abstract
{
    public abstract class QueryHandler<TParameter, TResult> : ICompositeQueryHandler<TParameter, TResult>
         where TResult : IQueryResult
         where TParameter : IQuery
    {
        public abstract Task<TResult> GetAsync(TParameter query);

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
