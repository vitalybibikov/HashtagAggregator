using System.Threading.Tasks;

namespace MyStudyProject.Core.Contracts.Interface.Cqrs.Query
{
    public interface IQueryHandler<in TParameter, TResult>
        where TResult : IQueryResult
        where TParameter : IQuery
    {
        Task<TResult> GetAsync(TParameter query);
    }
}
