using Autofac;

using HashtagAggregator.Core.Contracts.Interface.DataSources;
using HashtagAggregator.Core.Models.Commands;
using HashtagAggregator.Data.Contracts.Interface.JobObjects;
using HashtagAggregator.Data.Internet.DataSources.Vk;

namespace HashtagAggregator.DependencyInjection
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
