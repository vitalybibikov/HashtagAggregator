using System;
using System.Threading.Tasks;

using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;
using MyStudyProject.Core.Contracts.Interface.DataSources;
using MyStudyProject.Core.Cqrs.Abstract;
using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Core.Models.Interface.Cqrs.Command;

namespace MyStudyProject.Domain.Cqrs.Vk.Handlers
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
