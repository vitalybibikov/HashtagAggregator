using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregator.Shared.Contracts.Enums;

namespace HashtagAggregator.Core.Models.Commands
{
    public class UserCreateCommand : ICommand
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
