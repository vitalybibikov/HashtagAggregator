using HashtagAggregator.Core.Contracts.Interface.DataSources;
using HashtagAggregator.Core.Cqrs.Abstract;
using HashtagAggregator.Core.Models.Interface.Cqrs.Query;

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
