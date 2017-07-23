using Autofac;
using HashtagAggregator.Infrastructure;
using HashtagAggregator.Infrastructure.Services;
using HashtagAggregator.Infrastructure.Services.Interface;

namespace HashtagAggregator.DependencyInjection
{
    public class StartableModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TwitterConsumerService>().As<IServiceStartable>().InstancePerLifetimeScope();
            builder.RegisterType<VkService>().As<IServiceStartable>().InstancePerLifetimeScope();
            builder.RegisterType<TwitterService>().As<IServiceStartable>().InstancePerLifetimeScope();
            builder.RegisterType<ServiceNotifier>().As<IServiceNotifier>().InstancePerLifetimeScope();
        }
    }
}
