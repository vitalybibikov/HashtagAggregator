using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using HashtagAggregator.Infrastructure.Services.Interface;

namespace HashtagAggregator.Infrastructure
{
    public class ServiceStarter
    {
        private readonly IContainer container;

        public ServiceStarter(IContainer container)
        {
            this.container = container;
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
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
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