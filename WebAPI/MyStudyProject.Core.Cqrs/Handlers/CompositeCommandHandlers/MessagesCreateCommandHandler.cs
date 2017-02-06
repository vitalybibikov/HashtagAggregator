using System;
using Microsoft.Extensions.Logging;
using MyStudyProject.Core.Cqrs.Abstract;
using MyStudyProject.Core.Models.Commands;

namespace MyStudyProject.Core.Cqrs.Handlers.CompositeCommandHandlers
{
    public class MessagesCreateCommandHandler : CompositeCommandHandler<MessagesCreateCommand>
    {
        public MessagesCreateCommandHandler(ILogger logger) : base(logger)
        {
        }
    }
}
