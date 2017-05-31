using Autofac;

using HashtagAggregator.Core.Contracts.Interface.DataSources;
using HashtagAggregator.Core.Models.Commands;
using HashtagAggregator.Data.Contracts.Interface;
using HashtagAggregator.Data.Contracts.Interface.JobObjects;
using HashtagAggregator.Data.Internet.DataSources.Twitter;

namespace HashtagAggregator.DependencyInjection
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
