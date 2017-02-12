using Autofac;
using MyStudyProject.Core.Contracts.Interface;
using MyStudyProject.Domain.Cqrs.Common.RequestFilter;
using Module = Autofac.Module;

namespace MyStudyProject.DependencyInjection
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RequestQueryFilter>().As<IRequestFilter>();
        }
    }
}
