using Autofac;
using HashtagAggregator.Core.Contracts.Interface;
using HashtagAggregator.Core.Models.Results.Query;
using HashtagAggregator.Core.Models.Results.Query.Message;
using HashtagAggregator.Domain.Cqrs.Common.Filters;
using Module = Autofac.Module;

namespace HashtagAggregator.DependencyInjection
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