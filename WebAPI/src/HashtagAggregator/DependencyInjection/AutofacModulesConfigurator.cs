using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutofacSerilogIntegration;
using HashTagAggregatorConsumer.Service.Configuration.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace HashtagAggregator.DependencyInjection
{
    public class AutofacModulesConfigurator
    {
        public IContainer Configure(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.RegisterLogger();
            builder.RegisterModule<MediatrModule>();
            builder.Populate(services);
            
            return builder.Build();
        }
    }
}
