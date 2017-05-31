using System.Linq;

using HashtagAggregator.Core.Contracts.Interface;
using HashtagAggregator.Core.Models.Results.Query;
using HashtagAggregator.Core.Models.Results.Query.Message;

namespace HashtagAggregator.Domain.Cqrs.Common.Filters
{
    public class MessageFilter : IMessageFilter<MessagesQueryResult>
    {
        private MessagesQueryResult messages;

        public MessagesQueryResult Filter(MessagesQueryResult data)
        {
            messages = data;
            return  FilterDuplicates(messages)
                   .FilterOwnMessages(messages)
                   .Build();
        }

        private MessageFilter FilterDuplicates(MessagesQueryResult messages)
        {
           var range = 
                messages.Messages.GroupBy(d => 
                new
                {
                    d.NetworkId,
                    d.MediaType,
                    UserNetworkId = d.User.NetworkId
                }).SelectMany(grouping => grouping.Skip(1));

            foreach (var item in range)
            {
                messages.Messages.Remove(item);
            }
            return this;
        }

        private MessageFilter FilterOwnMessages(MessagesQueryResult messages)
        {
            //todo: add filtration of reposts after feature is implemented
            return this;
        }

        private MessagesQueryResult Build()
        {
            return messages;
        }
    }
}
