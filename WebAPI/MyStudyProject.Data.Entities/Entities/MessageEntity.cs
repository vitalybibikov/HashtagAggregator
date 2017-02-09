using System;
using MyStudyProject.Data.Contracts.Abstract;
using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.Data.Entities.Entities
{
    public class MessageEntity : Entity
    {
        public string NetworkId { get; set; }

        public string MessageText { get; set; }

        public string HashTag { get; set; }

        public DateTime? PostDate { get; set; }

        public SocialMediaType MediaType { get; set; }

        public UserEntity User { get; set; }

        public long UserId { get; set; }
    }
}
