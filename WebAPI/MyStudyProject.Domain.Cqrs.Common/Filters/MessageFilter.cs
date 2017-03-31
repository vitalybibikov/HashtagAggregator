﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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

            return this;
        }

        private MessagesQueryResult Build()
        {
            return messages;
        }
    }
}
