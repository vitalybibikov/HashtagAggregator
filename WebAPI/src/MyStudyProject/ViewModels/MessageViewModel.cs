using System;
using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.ViewModels
{
    public class MessageViewModel
    {
        public long Id { get; set; }

        public string Body { get; set; }

        public string HashTag { get; set; }

        public SocialMediaType MediaType { get; set; }

        public DateTime? PostDate { get; set; }

        public UserViewModel User { get; set; }

        public string NetworkId { get; set; }
    }
}
