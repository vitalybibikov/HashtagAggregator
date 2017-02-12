using System;

using Autofac;

using MyStudyProject.Core.Contracts.Interface.DataSources;
using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Data.Contracts.Interface.JobObjects;
using MyStudyProject.Data.Internet.DataSources.Vk;

namespace MyStudyProject.DependencyInjection
{
    public class VkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VkMessageServiceFacade>().As<IVkMessageFacade>();
            builder.RegisterType<VkBackgroundJob>().As<IVkBackgroundJob<MessageCreateCommand>>();
        }
    }
}
