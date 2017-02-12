using System.Reflection;

using MyStudyProject.Core.Cqrs.Dispatchers;
using MyStudyProject.Core.Models.Queries;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;
using MyStudyProject.Domain.Cqrs.EF.Handlers;
using MyStudyProject.Domain.Cqrs.Twitter.Handlers;
using MyStudyProject.Domain.Cqrs.Vk.Handlers;

using Autofac;
using MyStudyProject.Core.Models.Interface.Cqrs.Command;
using MyStudyProject.Core.Models.Interface.Cqrs.Query;
using MyStudyProject.Domain.Cqrs.Common.Handlers.CompositeQueryHandlers;
using Module = Autofac.Module;

namespace MyStudyProject.DependencyInjection
{
    public class CqrsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var modelAssembly = typeof(MessagesGetQuery).GetTypeInfo().Assembly;
            var dataAssembly = typeof(MessagesGetQueryHandler).GetTypeInfo().Assembly;
            var vkAssembly = typeof(VkMessagesGetQueryHandler).GetTypeInfo().Assembly;
            var twitterAssembly = typeof(TwitterMessagesGetQueryHandler).GetTypeInfo().Assembly;
            var efAssembly = typeof(EfMessagesGetQueryHandler).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(modelAssembly).AssignableTo<IQuery>();
            builder.RegisterAssemblyTypes(modelAssembly).AssignableTo<ICommand>();

            builder.RegisterAssemblyTypes(dataAssembly)
                .AsClosedTypesOf(typeof(ICompositeCommandHandler<>))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(vkAssembly, twitterAssembly, efAssembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(dataAssembly)
                .AsClosedTypesOf(typeof(ICompositeQueryHandler<,>))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(vkAssembly, twitterAssembly, efAssembly)
                .AsClosedTypesOf(typeof(IQueryHandler<,>))
                .AsImplementedInterfaces();

            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>().InstancePerLifetimeScope();
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>().InstancePerLifetimeScope();
        }
    }
}
