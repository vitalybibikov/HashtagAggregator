using Autofac;
using Module = Autofac.Module;

using MyStudyProject.Core.Contracts.Interface;
using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Domain.Cqrs.Common.Filters;

namespace MyStudyProject.DependencyInjection
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RequestQueryFilter>().As<IRequestFilter>();
            builder.RegisterType<MessageFilter>().As<IMessageFilter<MessagesQueryResult>>();
        }
    }
}