using HashtagAggregator.Core.Contracts.Interface.Cqrs.Query;
using HashtagAggregator.Core.Contracts.Interface.DataSources;
using HashtagAggregator.Core.Cqrs.Abstract;

namespace HashtagAggregator.Domain.Cqrs.Vk.Abstract
{
    public abstract class  VkQueryHandler<TParameter, TResult> : QueryHandler<TParameter, TResult>
         where TResult : IQueryResult, new()
         where TParameter : IQuery
    {
        protected IVkMessageFacade Facade { get; }

        protected VkQueryHandler(IVkMessageFacade facade)
        {
            Facade = facade;
        }
    }
}
