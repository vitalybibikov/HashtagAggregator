using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutofacSerilogIntegration;

using Microsoft.Extensions.DependencyInjection;

namespace MyStudyProject.DependencyInjection
{
    public class AutofacModulesConfigurator
    {
        public IContainer Configure(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.RegisterLogger();
            builder.RegisterModule<CqrsModule>();
            builder.RegisterModule<VkModule>();
            builder.RegisterModule<TwitterModule>();
            builder.RegisterModule<EFModule>();
            builder.RegisterModule<CommonModule>();
            builder.Populate(services);
            
            return builder.Build();
        }
    }
}
