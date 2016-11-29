using System.Reflection;

using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Core.Cqrs.Dispatchers;
using MyStudyProject.Core.Models.Queries;

using Autofac;
using Module = Autofac.Module;

namespace MyStudyProject.DependencyInjection
{
    public class ConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var modelAssembly = typeof(MessagesQuery).GetTypeInfo().Assembly;
            var dataAssembly = typeof(CommandDispatcher).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(modelAssembly).AssignableTo<IQuery>();
            builder.RegisterAssemblyTypes(modelAssembly).AssignableTo<ICommand>();

            builder.RegisterAssemblyTypes(dataAssembly)
                .AssignableTo(typeof(ICommandHandler<ICommand>))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(dataAssembly).AsClosedTypesOf(typeof(IQueryHandler<,>));

            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
        }
    }
}
