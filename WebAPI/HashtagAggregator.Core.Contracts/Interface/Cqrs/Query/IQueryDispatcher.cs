using System.Threading.Tasks;

using HashtagAggregator.Core.Models.Interface.Cqrs.Query;

namespace HashtagAggregator.Core.Contracts.Interface.Cqrs.Query
{
    public interface IQueryDispatcher
    {
        Task<TResult> DispatchMultipleAsync<TParameter, TResult>(TParameter query)
            where TParameter : IQuery 
            where TResult : IQueryResult, new();

        Task<TResult> DispatchAsync<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IQueryResult, new();
    }
}
