using HashtagAggregator.Core.Contracts.Interface.Cqrs.Query;
using HashtagAggregator.Core.Contracts.Interface.DataSources;
using HashtagAggregator.Core.Cqrs.Abstract;

namespace HashtagAggregator.Domain.Cqrs.Twitter.Abstract
{
    public abstract class TwitterQueryHandler<TParameter, TResult> : QueryHandler<TParameter, TResult>
         where TResult : IQueryResult, new()
         where TParameter : IQuery
    {
        protected ITwitterMessageFacade Facade { get; }

        protected TwitterQueryHandler(ITwitterMessageFacade facade)
        {
            Facade = facade;
        }
    }
}
