using System.Threading.Tasks;

namespace MyStudyProject.Core.Contracts.Interface.Cqrs.Query
{
    public interface IQueryDispatcher
    {
        Task<TResult> DispatchAsync<TParameter, TResult>(TParameter query)
            where TParameter : IQuery 
            where TResult : IQueryResult;
    }
}
