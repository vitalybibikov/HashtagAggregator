using Microsoft.Extensions.Logging;

using HashtagAggregator.Core.Cqrs.Abstract;
using HashtagAggregator.Core.Models.Commands;

namespace HashtagAggregator.Domain.Cqrs.Common.Handlers.CompositeCommandHandlers
{
    public class MessagesCreateCommandHandler : CompositeCommandHandler<MessagesCreateCommand>
    {
        public MessagesCreateCommandHandler(ILogger logger) : base(logger)
        {
        }
    }
}
