using System;
using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;

namespace HashtagAggregator.Core.Cqrs.Abstract
{
    public abstract class CommandHandler<TParameter> : ICompositeCommandHandler<TParameter>
        where TParameter : ICommand, new()
    {
        public abstract Task<ICommandResult> ExecuteAsync(TParameter command);

        public virtual void Add(ICommandHandler<TParameter> queryHandler)
        {
            throw new InvalidOperationException();
        }

        public virtual bool Remove(ICommandHandler<TParameter> queryHandler)
        {
            throw new InvalidOperationException();
        }
    }
}
