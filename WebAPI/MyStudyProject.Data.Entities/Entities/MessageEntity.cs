using System;
using MyStudyProject.Data.Contracts.Abstract;
using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.Data.Entities.Entities
{
    public class MessageEntity : Entity
    {
        public string Body { get; set; }

        public string HashTag { get; set; }

        public DateTime? PostDate { get; set; }

        public SocialMediaType MediaType { get; set; }

        public string NetworkId { get; set; }

        public string UserId { get; set; }
    }
}
