using System;
using Autofac;
using Hangfire;

namespace HashtagAggregator.DependencyInjection
{
    public class AutofacContainerJobActivator : JobActivator
    {
        private readonly IContainer container;

        public AutofacContainerJobActivator(IContainer container)
        {
            this.container = container;
        }

        public override object ActivateJob(Type type)
        {
            return this.container.Resolve(type);
        }
    }
}
