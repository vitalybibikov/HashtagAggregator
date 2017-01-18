using System;

using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;
using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.Core.Models.Commands
{
    public class MessageCreateCommand : ICommand
    {
        public long Id { get; set; }

        public string Body { get; set; }

        public string HashTag { get; set; }

        public SocialMediaType MediaType { get; set; }

        public DateTime? PostDate { get; set; }

        public string NetworkId { get; set; }

        public string UserId { get; set; }
    }
}
