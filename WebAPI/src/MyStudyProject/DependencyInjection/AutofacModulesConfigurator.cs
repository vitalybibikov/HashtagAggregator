using System;

using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Contracts.Interface.ServiceFacades;
using MyStudyProject.Core.Cqrs.Results;
using MyStudyProject.Domain.Services.Services;

namespace MyStudyProject.DependencyInjection
{
    public class AutofacModulesConfigurator
    {
        public IServiceProvider Configure(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ConfigurationModule>();
            builder.RegisterModule<ServicesModule>();
            builder.RegisterType<TwitterMessageServiceFacade>().As<IMessageServiceFacade<MessageQueryResult>>();
            builder.Populate(services);

            IContainer container = builder.Build();
            
            return container.Resolve<IServiceProvider>();
        }
    }
}
