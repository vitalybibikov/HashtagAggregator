using System.Collections.Generic;

using MyStudyProject.Core.Models.Interface.Cqrs.Query;

namespace MyStudyProject.Core.Models.Results.Query
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
