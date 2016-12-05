using System.Reflection;

using Autofac;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;
using MyStudyProject.Core.Contracts.Interface.ServiceFacades;
using MyStudyProject.Core.Cqrs.Dispatchers;
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
           // var dataInternetAssembly = typeof(VkMessageServiceFacade).GetTypeInfo().Assembly;


            builder.RegisterType<VkMessageServiceFacade>().As<IVkMessageFacade<MessagesQueryResult>>();
            builder.RegisterType<TwitterMessageServiceFacade>().As<ITwitterMessageFacade<MessagesQueryResult>>();

            //builder.RegisterAssemblyTypes(dataInternetAssembly)
            //    .AsClosedTypesOf(
            //    typeof(IVkMessageFacade<>), 
            //    typeof(ITwitterMessageFacade<>)).AsImplementedInterfaces();
        }
    }
}
