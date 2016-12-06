using System.Threading.Tasks;
using MyStudyProject.Shared.Common;

namespace MyStudyProject.Core.Contracts.Interface.Cqrs.Query
{
    public interface IQueryHandler<in TParameter, TResult>
        where TResult : IQueryResult, new()
        where TParameter : IQuery
    {
        Task<TResult> GetAsync(TParameter query);
    }
}
