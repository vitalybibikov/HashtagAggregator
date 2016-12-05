using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;

namespace MyStudyProject.Core.Contracts.Abstract
{
    public abstract class CommandHandler<TParameter> : ICompositeCommandHandler<TParameter> 
        where TParameter : ICommand
    {
        public virtual void Validate(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }
        }

        public virtual void Validates(List<ICommand> commands)
        {
            foreach (var command in commands)
            {
                Validate(command);
            }
        }

        public abstract Task<ICommandResult> ExecuteAsync(TParameter command);
        public abstract Task<ICommandResult> ExecuteAsync(List<TParameter> command);


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
