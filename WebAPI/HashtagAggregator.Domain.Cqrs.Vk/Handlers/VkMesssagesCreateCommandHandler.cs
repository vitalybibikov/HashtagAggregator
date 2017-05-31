using System;
using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.DataSources;
using HashtagAggregator.Core.Cqrs.Abstract;
using HashtagAggregator.Core.Models.Commands;
using HashtagAggregator.Core.Models.Interface.Cqrs.Command;

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
