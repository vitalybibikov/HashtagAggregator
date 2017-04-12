using HashtagAggregator.Core.Contracts.Interface.DataSources;
using HashtagAggregator.Core.Cqrs.Abstract;
using HashtagAggregator.Core.Models.Interface.Cqrs.Query;

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
