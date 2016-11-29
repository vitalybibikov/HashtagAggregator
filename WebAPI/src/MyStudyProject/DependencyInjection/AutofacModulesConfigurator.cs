using System;

using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace MyStudyProject.DependencyInjection
{
    public class AutofacModulesConfigurator
    {
        public IServiceProvider Configure(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ConfigurationModule>();
            builder.Populate(services);

            IContainer container = builder.Build();
            
            return container.Resolve<IServiceProvider>();
        }
    }
}
