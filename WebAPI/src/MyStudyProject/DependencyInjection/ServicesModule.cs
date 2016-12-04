using System.Reflection;

using Autofac;

using MyStudyProject.Domain.Services.Services;
using MyStudyProject.Domain.Services.Services.Twitter;
using MyStudyProject.Domain.Services.Services.Vk;
using Module = Autofac.Module;

namespace MyStudyProject.DependencyInjection
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TwitterMessageServiceFacade>().As<ITwitterServiceFacade>();
            builder.RegisterType<VkMessageServiceFacade>().As<IVkServiceFacade>();
            builder.RegisterType<MessageService>().As<IMessageService>();
        }
    }
}
