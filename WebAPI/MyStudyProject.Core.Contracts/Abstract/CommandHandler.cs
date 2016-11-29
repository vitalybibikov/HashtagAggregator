using System;
using System.Threading.Tasks;
using MyStudyProject.Core.Contracts.Interface;
using MyStudyProject.Core.Contracts.Interface.Cqrs;

namespace MyStudyProject.Core.Contracts.Abstract
{
    public abstract class CommandHandler<TParameter> : ICommandHandler<TParameter> 
        where TParameter : ICommand
    {
        public virtual void Validate(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            if (command.Id == 0)
            {
                throw new ArgumentException("Argument id should not be zero", nameof(command));
            }
        }

        public abstract Task<ICommandResult> Execute(TParameter command);

    }
}
