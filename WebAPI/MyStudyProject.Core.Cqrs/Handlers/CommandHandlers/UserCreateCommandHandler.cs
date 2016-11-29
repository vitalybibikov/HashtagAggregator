using System;
using System.Threading.Tasks;

using MyStudyProject.Core.Contracts.Abstract;
using MyStudyProject.Core.Contracts.Interface;
using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Models.Commands;

namespace MyStudyProject.Core.Cqrs.Handlers.CommandHandlers
{
    public class UserCreateCommandHandler : CommandHandler<UserCreateCommand>
    {
        public override Task<ICommandResult> Execute(UserCreateCommand command)
        {
            Validate(command);
            return InsertUser(command);
        }

        private Task<ICommandResult> InsertUser(ICommand command)
        {
            throw new NotImplementedException();
        }
    }
}
