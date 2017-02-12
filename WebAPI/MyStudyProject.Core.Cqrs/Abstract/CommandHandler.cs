using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;
using MyStudyProject.Core.Models.Interface.Cqrs.Command;

namespace MyStudyProject.Core.Cqrs.Abstract
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
