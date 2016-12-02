using System;

using MyStudyProject.Core.Contracts.Interface.Cqrs;
using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.Core.Cqrs.Results
{
    public class MessageQueryResult : IQueryResult
    {
        public long Id { get; set; }

        public string Body { get; set; }

        public string HashTag { get; set; }

        public SocialMediaType Media { get; set; }

        public DateTime? PostDate { get; set; }
    }
}
