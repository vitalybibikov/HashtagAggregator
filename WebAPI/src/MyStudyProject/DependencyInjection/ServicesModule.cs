using Autofac;
using MyStudyProject.Core.Contracts.Interface;
using MyStudyProject.Core.Cqrs.RequestFilter;
using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Data.Contracts.Interface;
using MyStudyProject.Data.Contracts.ServiceFacades;
using MyStudyProject.Data.Internet.Services.Twitter;
using MyStudyProject.Data.Internet.Services.Vk;
using Module = Autofac.Module;

namespace MyStudyProject.DependencyInjection
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VkMessageServiceFacade>().As<IVkMessageFacade>();
            builder.RegisterType<TwitterMessageServiceFacade>().As<ITwitterMessageFacade>();
            builder.RegisterType<RequestQueryFilter>().As<IRequestFilter>();
            builder.RegisterType<TwitterBackgroundJob>().As<ITwitterBackgroundJob<MessageCreateCommand>>();
            builder.RegisterType<TwitterAuth>().As<ITwitterAuth>(); 
        }
    }
}
