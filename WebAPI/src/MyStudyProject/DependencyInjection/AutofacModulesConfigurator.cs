using System;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;

namespace MyStudyProject.DependencyInjection
{
    public class AutofacModulesConfigurator
    {
        public IContainer Configure(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<CqrsModule>();
            builder.RegisterModule<ServicesModule>();
            builder.Populate(services);

            return builder.Build();
        }
    }
}
