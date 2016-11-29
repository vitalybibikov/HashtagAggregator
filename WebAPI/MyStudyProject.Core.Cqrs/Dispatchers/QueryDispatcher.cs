using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using MyStudyProject.Core.Contracts.Interface.Cqrs;

namespace MyStudyProject.Core.Cqrs.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext container;

        public QueryDispatcher(IComponentContext container)
        {
            this.container = container;
        }

        public Task<TResult> Dispatch<TParameter, TResult>(TParameter query)
            where TParameter : IQuery where TResult : IQueryResult
        {
            var results = container.ComponentRegistry.Registrations.SelectMany(x => x.Services).Select(x => x.Description);
            var handler = container.Resolve<IQueryHandler<TParameter, TResult>>();
            return handler.Get(query);
        }
    }
}
