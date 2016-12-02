using System.Reflection;

using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Cqrs.Dispatchers;
using MyStudyProject.Core.Models.Queries;

using Autofac;
using MyStudyProject.Core.Contracts.Interface;
using MyStudyProject.Core.Contracts.Interface.ServiceFacades;
using MyStudyProject.Core.Cqrs.Results;
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
            //builder.RegisterType<TwitterMessageServiceFacade>().As<IMessageServiceFacade<MessageQueryResult>>();
            builder.RegisterType<VkMessageServiceFacade>().As<IMessageServiceFacade<MessageQueryResult>>();
        }
    }
}
