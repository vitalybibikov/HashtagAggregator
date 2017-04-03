using System;
using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.Core.Models.Commands
{
    public class UserCreateCommand
    {
        public long Id { get; set; }

        public string NetworkId { get; set; }

        public string UserName { get; set; }

        public SocialMediaType MediaType { get; set; }

        public string ProfileId { get; set; }

        public string AvatarUrl50 { get; set; }

        public string Url { get; set; }
    }
}
