using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutofacSerilogIntegration;

using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace MyStudyProject.DependencyInjection
{
    public class AutofacModulesConfigurator
    {
        public IContainer Configure(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.RegisterLogger();
            builder.RegisterModule<CqrsModule>();
            builder.RegisterModule<ServicesModule>();
            builder.Populate(services);
            
            return builder.Build();
        }
    }
}
