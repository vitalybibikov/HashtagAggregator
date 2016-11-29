using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.Data.Entities.Entities
{
    public class MessageEntity
    {
        public long Id { get; set; }

        public string Body { get; set; }

        public string HashTag { get; set; }

        public string PosedDate { get; set; }

        public SocialMediaType MediaType { get; set; }

        public UserEntity User { get; set; }
    }
}
