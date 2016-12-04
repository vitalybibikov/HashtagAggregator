using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;

namespace MyStudyProject.Core.Models.Results.Query
{
    public class MessagesQueryResult : IQueryResult
    {
        public List<MessageQueryResult> Messages { get; set; }
    }
}
