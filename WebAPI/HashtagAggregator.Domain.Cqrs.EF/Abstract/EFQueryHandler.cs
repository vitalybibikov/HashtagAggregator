using HashtagAggregator.Core.Contracts.Interface.Cqrs.Query;
using HashtagAggregator.Core.Cqrs.Abstract;
using HashtagAggregator.Data.DataAccess.Context;

namespace HashtagAggregator.Domain.Cqrs.EF.Abstract
{
    public abstract class EfQueryHandler<TParameter, TResult> : QueryHandler<TParameter, TResult>
         where TResult : IQueryResult, new()
         where TParameter : IQuery
    {
        protected SqlApplicationDbContext Context { get; }

        protected EfQueryHandler(SqlApplicationDbContext context)
        {
            Context = context;
        }
    }
}
