using System.Linq;
using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregator.Core.Contracts.Interface.DataSources;
using HashtagAggregator.Core.Cqrs.Abstract;
using HashtagAggregator.Core.Models.Commands;
using HashtagAggregator.Shared.Contracts.Enums;

namespace HashtagAggregator.Domain.Cqrs.Twitter.Handlers
{
    public class TwitterMesssagesCreateCommandHandler : CommandHandler<MessagesCreateCommand>
    {
        private readonly ITwitterMessageFacade facade;

        public TwitterMesssagesCreateCommandHandler(ITwitterMessageFacade facade)
        {
            this.facade = facade;
        }

        public override Task<ICommandResult> ExecuteAsync(MessagesCreateCommand command)
        {
            var filtered = command.Messages.Where(x => x.MediaType != SocialMediaType.Twitter && x.Id <= 0);
            return facade.Save(filtered);
        }
    }
}
