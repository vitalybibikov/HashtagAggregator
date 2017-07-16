using System.Collections.Generic;

namespace HashtagAggregator.Core.Models.Results.Query.Message
{
    public class MessagesQueryResult
    {
        public MessagesQueryResult()
        {
            Messages = new List<MessageQueryResult>();
        }

        public List<MessageQueryResult> Messages { get; }
    }
}
