using System.Collections.Generic;
using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;
using MyStudyProject.Shared.Common;
using MyStudyProject.Shared.Common.UpdateStrategies;

namespace MyStudyProject.Core.Cqrs.Abstract
{
    public abstract class CompositeQueryHandler<TParameter, TResult> : QueryHandler<TParameter, TResult>
         where TResult : IQueryResult, new()
         where TParameter : IQuery
    {
        private readonly List<IQueryHandler<TParameter, TResult>> handlers;

        public List<IQueryHandler<TParameter, TResult>> Handlers => handlers;

        protected CompositeQueryHandler(IUpdateStrategy strategy)
        {
            handlers = new List<IQueryHandler<TParameter, TResult>>();
        }

        public override void Add(IQueryHandler<TParameter, TResult> queryHandler)
        {
            handlers.Add(queryHandler);
        }

        public override bool Remove(IQueryHandler<TParameter, TResult> queryHandler)
        {
            return handlers.Remove(queryHandler);
        }
    }
}
