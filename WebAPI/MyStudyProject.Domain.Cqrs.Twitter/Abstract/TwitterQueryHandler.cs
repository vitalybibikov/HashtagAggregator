using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;
using MyStudyProject.Core.Contracts.Interface.ServiceFacades;
using MyStudyProject.Core.Cqrs.Abstract;
using MyStudyProject.Core.Models.Results.Query;

namespace MyStudyProject.Domain.Cqrs.Twitter.Abstract
{
    public abstract class TwitterQueryHandler<TParameter, TResult> : QueryHandler<TParameter, TResult>
         where TResult : IQueryResult, new()
         where TParameter : IQuery
    {
        protected ITwitterMessageFacade<MessagesQueryResult> Facade { get; }

        protected TwitterQueryHandler(ITwitterMessageFacade<MessagesQueryResult> facade)
        {
            this.Facade = facade;
        }

    }
}
