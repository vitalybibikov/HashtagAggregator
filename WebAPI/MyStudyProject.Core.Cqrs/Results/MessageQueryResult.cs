using System;

using MyStudyProject.Core.Contracts.Interface.Cqrs;

namespace MyStudyProject.Core.Cqrs.Results
{
    public class MessageQueryResult : IQueryResult
    {
        public long Id { get; set; }

        public string Body { get; set; }

        public string HashTag { get; set; }
    }
}
