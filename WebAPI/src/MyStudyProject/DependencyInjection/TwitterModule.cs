using Autofac;
using MyStudyProject.Core.Contracts.Interface.DataSources;
using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Data.Contracts.Interface;
using MyStudyProject.Data.Contracts.Interface.JobObjects;
using MyStudyProject.Data.Internet.DataSources.Twitter;

namespace MyStudyProject.DependencyInjection
{
    public class TwitterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TwitterMessageServiceFacade>().As<ITwitterMessageFacade>();
            builder.RegisterType<TwitterBackgroundJob>().As<ITwitterBackgroundJob<MessageCreateCommand>>();
            builder.RegisterType<TwitterAuth>().As<ITwitterAuth>();
        }
    }
}
