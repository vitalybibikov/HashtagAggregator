using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;
using MyStudyProject.Core.Cqrs.Abstract;
using MyStudyProject.Data.Contracts.ServiceFacades;

namespace MyStudyProject.Domain.Cqrs.Twitter.Abstract
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
