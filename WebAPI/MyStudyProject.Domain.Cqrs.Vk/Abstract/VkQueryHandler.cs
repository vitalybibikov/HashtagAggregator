using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;
using MyStudyProject.Core.Contracts.Interface.ServiceFacades;
using MyStudyProject.Core.Cqrs.Abstract;
using MyStudyProject.Core.Models.Results.Query;

namespace MyStudyProject.Domain.Cqrs.Vk.Abstract
{
    public abstract class VkQueryHandler<TParameter, TResult> : QueryHandler<TParameter, TResult>
         where TResult : IQueryResult, new()
         where TParameter : IQuery
    {
        protected  IVkMessageFacade<MessagesQueryResult> Facade { get; }

        protected VkQueryHandler(IVkMessageFacade<MessagesQueryResult> facade)
        {
            Facade = facade;
        }

    }
}
