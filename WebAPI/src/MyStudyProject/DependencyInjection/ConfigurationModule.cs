using System.Reflection;

using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Cqrs.Dispatchers;
using MyStudyProject.Core.Models.Queries;

using Autofac;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;
using MyStudyProject.Core.Cqrs.Handlers.CompositeCommandHandlers;
using MyStudyProject.Core.Cqrs.Handlers.CompositeQueryHandlers;
using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Domain.Cqrs.Twitter.Handlers;
using MyStudyProject.Domain.Cqrs.Vk.Handlers;
using Module = Autofac.Module;

namespace MyStudyProject.DependencyInjection
{
    public class ConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var modelAssembly = typeof(MessageGetQuery).GetTypeInfo().Assembly;

            var dataAssembly = typeof(MessagesGetQueryHandler).GetTypeInfo().Assembly;
            var vkAssembly = typeof(VkMessagesGetQueryHandler).GetTypeInfo().Assembly;
            var twitterAssembly = typeof(TwitterMessagesGetQueryHandler).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(modelAssembly).AssignableTo<IQuery>();
            builder.RegisterAssemblyTypes(modelAssembly).AssignableTo<ICommand>();

            builder.RegisterAssemblyTypes(dataAssembly)
                .AssignableTo(typeof(ICompositeCommandHandler<ICommand>))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(vkAssembly, twitterAssembly)
                .AssignableTo(typeof(ICommandHandler<ICommand>))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(vkAssembly, twitterAssembly).AsClosedTypesOf(typeof(IQueryHandler<,>)).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(dataAssembly).AsClosedTypesOf(typeof(ICompositeQueryHandler<,>)).AsImplementedInterfaces();

            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
        }
    }
}
