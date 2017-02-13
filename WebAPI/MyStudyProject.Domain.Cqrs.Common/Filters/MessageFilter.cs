using System;
using System.Linq;
using MyStudyProject.Core.Contracts.Interface;
using MyStudyProject.Core.Models.Results.Query;

namespace MyStudyProject.Domain.Cqrs.Common.Filters
{
    public class MessageFilter : IMessageFilter<MessagesQueryResult>
    {
        private MessagesQueryResult messages;

        public MessagesQueryResult Filter(MessagesQueryResult data)
        {
            this.messages = data;
            return  FilterDuplicates(messages)
                   .FilterOwnMessages(messages)
                   .Build();
        }

        private MessageFilter FilterDuplicates(MessagesQueryResult messages)
        {
            return this;
        }

        private MessageFilter FilterOwnMessages(MessagesQueryResult messages)
        {

            return this;
        }

        private MessagesQueryResult Build()
        {
            return messages;
        }
    }
}
