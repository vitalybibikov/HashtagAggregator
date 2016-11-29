using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.Data.Entities.Entities
{
    public class UserEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public SocialMediaType Media { get; set; }

    }
}
