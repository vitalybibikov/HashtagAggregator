using System;
using System.Threading.Tasks;
using MyStudyProject.Core.Contracts.Interface.Cqrs;

namespace MyStudyProject.Core.Contracts.Abstract
{
    public abstract class QueryHandler<TParameter, TResult> : IQueryHandler<TParameter, TResult>
         where TResult : IQueryResult
         where TParameter : IQuery
    {
        public virtual Task<TResult> Get(TParameter query)
        {
            throw new NotImplementedException();
        }
    }
}
