using System;
using System.Threading.Tasks;

using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;
using MyStudyProject.Core.Cqrs.Abstract;
using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Data.Contracts.ServiceFacades;

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
            throw new NotImplementedException();
            //var filtered = command.Messages.Where(x => x.MediaType != SocialMediaType.VK && x.Id <= 0);
            //return facade.Save(filtered);
        }
    }
}
