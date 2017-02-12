using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;
using MyStudyProject.Core.Contracts.Interface.DataSources;
using MyStudyProject.Core.Cqrs.Abstract;
using MyStudyProject.Core.Models.Interface.Cqrs.Query;

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
