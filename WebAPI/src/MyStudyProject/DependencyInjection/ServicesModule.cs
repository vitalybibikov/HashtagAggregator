using System.Reflection;

using Autofac;
using MyStudyProject.Core.Contracts.Interface;
using MyStudyProject.Core.Contracts.Interface.ServiceFacades;
using MyStudyProject.Core.Cqrs.RequestFilter;
using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Data.Internet.Services.Twitter;
using MyStudyProject.Data.Internet.Services.Vk;
using Module = Autofac.Module;

namespace MyStudyProject.DependencyInjection
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VkMessageServiceFacade>().As<IVkMessageFacade<MessagesQueryResult>>();
            builder.RegisterType<TwitterMessageServiceFacade>().As<ITwitterMessageFacade<MessagesQueryResult>>();
            builder.RegisterType<RequestQueryFilter>().As<IRequestFilter>();
        }
    }
}
