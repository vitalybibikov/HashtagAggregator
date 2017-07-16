using System;
using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregator.Core.Contracts.Interface.DataSources;
using HashtagAggregator.Core.Cqrs.Abstract;
using HashtagAggregator.Core.Models.Commands;

namespace HashtagAggregator.Domain.Cqrs.Vk.Handlers
{
    public class VkMesssagesCreateCommandHandler : CommandHandler<MessagesCreateCommand>
    {
        private readonly IVkMessageFacade facade;

        public VkMesssagesCreateCommandHandler(IVkMessageFacade facade)
        {
            this.facade = facade;
        }

        public override Task<ICommandResult> ExecuteAsync(MessagesCreateCommand command)
        {
            throw new NotSupportedException();
            //var filtered = command.Messages.Where(x => x.MediaType != SocialMediaType.VK && x.Id <= 0);
            //return facade.Save(filtered);
        }
    }
}
