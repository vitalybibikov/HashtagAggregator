namespace MyStudyProject.Core.Contracts.Interface.Cqrs.Query
{
    public interface ICompositeQueryHandler<TParameter, TResult> : IQueryHandler<TParameter, TResult>
        where TResult : IQueryResult, new()
        where TParameter : IQuery
    {
        void Add(IQueryHandler<TParameter, TResult> queryHandler);

        bool Remove(IQueryHandler<TParameter, TResult> queryHandler);
    }
}
