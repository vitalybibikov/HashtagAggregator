using HashtagAggregator.Shared.Contracts.Enums;

namespace HashtagAggregator.Core.Models.Results.Query.User
{
    public class UserQueryResult
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
