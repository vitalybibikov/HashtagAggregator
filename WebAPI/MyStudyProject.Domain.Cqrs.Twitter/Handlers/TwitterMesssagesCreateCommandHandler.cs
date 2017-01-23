using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;
using MyStudyProject.Core.Cqrs.Abstract;
using MyStudyProject.Core.Models.Commands;

namespace MyStudyProject.Domain.Cqrs.Twitter.Handlers
{
    public class TwitterMesssagesCreateCommandHandler : CommandHandler<MessagesCreateCommand>
    {
        public override Task<ICommandResult> ExecuteAsync(MessagesCreateCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
