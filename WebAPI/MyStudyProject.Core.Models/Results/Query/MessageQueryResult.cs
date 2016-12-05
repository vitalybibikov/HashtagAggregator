using System;

using MyStudyProject.Core.Contracts.Interface.Cqrs.Query;
using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.Core.Models.Results.Query
{
    public class MessageQueryResult : IQueryResult
    {
        public long Id { get; set; }

        public string Body { get; set; }

        public string HashTag { get; set; }

        public SocialMediaType Media { get; set; }

        public DateTime? PostDate { get; set; }

        public string NetworkId { get; set; }

        public string UserId { get; set; }
    }
}
