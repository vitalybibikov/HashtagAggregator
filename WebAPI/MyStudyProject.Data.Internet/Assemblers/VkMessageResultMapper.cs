using System;
using System.Collections.Generic;
using System.Linq;
using MyStudyProject.Core.Entities.VkEntities;
using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.Data.Internet.Assemblers
{
    public class VkMessageResultMapper
    {
        public MessagesQueryResult MapBunch(IEnumerable<VkNewsFeed> feeds, string hashtag)
        {
            MessagesQueryResult results = new MessagesQueryResult();
            foreach (VkNewsFeed feed in feeds)
            {
                var result = MapSingle(feed, hashtag);
                if (result.Messages.Count > 0)
                {
                    results.Messages.AddRange(result.Messages);
                }   
            }
            return results;
        }

        public MessagesQueryResult MapSingle(VkNewsFeed feed, string hashtag)
        {
            var results = new MessagesQueryResult();
            foreach (var post in feed.Feed)
            {
                var date = DateTimeOffset.FromUnixTimeSeconds(post.UnixTimeStamp).DateTime;
                var user = FillUser(post, feed.Profiles);
                MessageQueryResult message =
                  new MessageQueryResult(0,
                      post.Text,
                      hashtag,
                      SocialMediaType.VK,
                      date,
                      post.Id.ToString(),
                      user);
                results.Messages.Add(message);
            }
            return results;
        }

        private UserQueryResult FillUser(VkNewsSearchResult post, List<VkNewsProfile> profiles)
        {
            var id = post.FromId.ToString();
            var profile = profiles.FirstOrDefault(x => x.Id.ToString() == id);
            UserQueryResult user = new UserQueryResult
            {
                NetworkId = post.FromId.ToString(),
                UserName = $"{profile.FirstName} {profile.LastName}",
                ProfileId = profile.UserName
            };
            return user;
        }
    }
}
