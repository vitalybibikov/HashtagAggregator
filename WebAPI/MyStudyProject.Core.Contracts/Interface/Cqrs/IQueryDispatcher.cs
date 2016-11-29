using System.Threading.Tasks;

namespace MyStudyProject.Core.Contracts.Interface.Cqrs
{
    public interface IQueryDispatcher
    {
        Task<TResult> Dispatch<TParameter, TResult>(TParameter query)
            where TParameter : IQuery 
            where TResult : IQueryResult;
    }
}
