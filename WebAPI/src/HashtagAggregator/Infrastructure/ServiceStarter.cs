using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;

using HashtagAggregator.Infrastructure.Services.Interface;
using Microsoft.Extensions.Logging;

namespace HashtagAggregator.Infrastructure
{
    public class ServiceStarter : IServiceStarter
    {
        private readonly ILifetimeScope container;
        private readonly ILogger<ServiceStarter> logger;

        public ServiceStarter(ILifetimeScope container, ILogger<ServiceStarter> logger)
        {
            this.container = container;
            this.logger = logger;
        }

        public void Start()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var services = scope.Resolve<IEnumerable<IServiceStartable>>();
                foreach (var service in services)
                {
                    try
                    {
                        Task.Run(() => service.Start()).Wait();
                    }
                    catch (Exception ex)
                    {
                        logger.LogInformation("Failed to create service.", ex);
                    }
                }
            }
        }

        public void Stop()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var services = scope.Resolve<IEnumerable<IServiceStartable>>();
                foreach (var service in services)
                {
                    service.Stop();
                }
            }
        }
    }
}