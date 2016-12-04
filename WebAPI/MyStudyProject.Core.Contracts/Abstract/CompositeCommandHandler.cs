using System;
using System.Collections.Generic;

using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;

namespace MyStudyProject.Core.Contracts.Abstract
{
    public abstract class CompositeCommandHandler<TParameter> : CommandHandler<TParameter>
        where TParameter : ICommand
    {
        private readonly List<ICommandHandler<TParameter>> handlers;

        protected CompositeCommandHandler()
        {
            handlers = new List<ICommandHandler<TParameter>>();
        }

        protected CompositeCommandHandler(List<ICommandHandler<TParameter>> handlersList)
        {
            handlers = new List<ICommandHandler<TParameter>>();
            if (handlersList != null)
            {
                handlers.AddRange(handlersList);
            }
        }

        public override void Add(ICommandHandler<TParameter> queryHandler)
        {
            handlers.Add(queryHandler);
        }

        public override bool Remove(ICommandHandler<TParameter> queryHandler)
        {
            return handlers.Remove(queryHandler);
        }
    }
}
