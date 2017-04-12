using System.Reflection;
using Autofac;

using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Query;
using HashtagAggregator.Core.Cqrs.Dispatchers;
using HashtagAggregator.Core.Models.Interface.Cqrs.Command;
using HashtagAggregator.Core.Models.Interface.Cqrs.Query;
using HashtagAggregator.Core.Models.Queries;
using HashtagAggregator.Domain.Cqrs.Common.Handlers.CompositeQueryHandlers;
using HashtagAggregator.Domain.Cqrs.EF.Handlers;
using HashtagAggregator.Domain.Cqrs.Twitter.Handlers;
using HashtagAggregator.Domain.Cqrs.Vk.Handlers;
using Module = Autofac.Module;

namespace HashtagAggregator.DependencyInjection
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
