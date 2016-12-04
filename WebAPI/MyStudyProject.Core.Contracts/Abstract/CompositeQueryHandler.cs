using System.Collections.Generic;

using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;

namespace MyStudyProject.Core.Contracts.Abstract
{
    public abstract class CompositeQueryHandler<TParameter, TResult> : QueryHandler<TParameter, TResult>
         where TResult : IQueryResult
         where TParameter : IQuery
    {

        private readonly List<IQueryHandler<TParameter, TResult>> handlers;

        public List<IQueryHandler<TParameter, TResult>> Handlers => handlers;

        protected CompositeQueryHandler()
        {
            handlers = new List<IQueryHandler<TParameter, TResult>>();
        }

        protected CompositeQueryHandler(List<IQueryHandler<TParameter, TResult>> handlersList)
        {
            handlers = new List<IQueryHandler<TParameter, TResult>>();
            if (handlersList != null)
            {
                handlers.AddRange(handlersList);
            }
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
