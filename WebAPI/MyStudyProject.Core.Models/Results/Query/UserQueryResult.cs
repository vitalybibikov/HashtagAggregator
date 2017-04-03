using System;

using MyStudyProject.Core.Models.Interface.Cqrs.Query;
using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.Core.Models.Results.Query
{
    public class UserQueryResult : IQueryResult
    {
        public long Id { get; set; }

        public string NetworkId { get; set; }

        public string UserName { get; set; }

        public string ProfileId { get; set; }

        public SocialMediaType MediaType { get; set; }

        public string Url { get; set; }

        public string AvatarUrl50 { get; set; }
    }
}
