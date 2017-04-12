using HashtagAggregator.Core.Models.Interface.Cqrs.Query;

namespace HashtagAggregator.Core.Contracts.Interface
{
    public interface IMessageFilter<T>
        where T : IQueryResult, new()
    {
        T Filter(T messages);
    }
}
