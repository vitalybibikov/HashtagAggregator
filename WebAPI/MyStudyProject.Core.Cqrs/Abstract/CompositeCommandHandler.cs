using System.Collections.Generic;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;

namespace MyStudyProject.Core.Cqrs.Abstract
{
    public abstract class CompositeCommandHandler<TParameter> : CommandHandler<TParameter>
        where TParameter : ICommand, new()
    {
        private readonly List<ICommandHandler<TParameter>> handlers;
        public List<ICommandHandler<TParameter>> Handlers => handlers;

        protected CompositeCommandHandler()
        {
            handlers = new List<ICommandHandler<TParameter>>();
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
