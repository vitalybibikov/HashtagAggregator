using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;
using MyStudyProject.Core.Cqrs.Abstract;
using MyStudyProject.Data.Contracts.ServiceFacades;

namespace MyStudyProject.Domain.Cqrs.Vk.Abstract
{
    public abstract class  VkQueryHandler<TParameter, TResult> : QueryHandler<TParameter, TResult>
         where TResult : IQueryResult, new()
         where TParameter : IQuery
    {
        protected IVkMessageFacade Facade { get; }

        protected VkQueryHandler(IVkMessageFacade facade)
        {
            Facade = facade;
        }
    }
}
