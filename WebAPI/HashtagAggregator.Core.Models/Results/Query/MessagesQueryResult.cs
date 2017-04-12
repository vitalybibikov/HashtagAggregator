using System.Collections.Generic;
using HashtagAggregator.Core.Models.Interface.Cqrs.Query;

namespace HashtagAggregator.Core.Models.Results.Query
{
    public class MessagesQueryResult : IQueryResult
    {
        public MessagesQueryResult()
        {
            Messages = new List<MessageQueryResult>();
        }

        public List<MessageQueryResult> Messages { get; }
    }
}
