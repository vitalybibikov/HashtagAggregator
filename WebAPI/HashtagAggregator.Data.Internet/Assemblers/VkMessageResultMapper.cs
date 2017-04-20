using System;
using System.Collections.Generic;
using System.Linq;

using HashtagAggregator.Core.Entities.VkEntities;
using HashtagAggregator.Core.Models.Results.Query.HashTag;
using HashtagAggregator.Core.Models.Results.Query.Message;
using HashtagAggregator.Core.Models.Results.Query.User;
using HashtagAggregator.Shared.Contracts.Enums;

namespace HashtagAggregator.Data.Internet.Assemblers
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
            // vk doesn't return list of all hashtags in message
            // todo: consider parsing message for hashtags. But it might be too memory consuming operation.

            foreach (var post in feed.Feed)
            {
                var date = DateTimeOffset.FromUnixTimeSeconds(post.UnixTimeStamp).UtcDateTime;
                var user = FillUser(post, feed);
                MessageQueryResult message =
                  new MessageQueryResult(0,
                      post.Text,
                      new List<HashTagQueryResult> { new HashTagQueryResult() { HashTag = hashtag } },  
                      SocialMediaType.VK,
                      date,
                      post.Id.ToString(),
                      user);
                results.Messages.Add(message);
            }
            return results;
        }

        private UserQueryResult FillUser(VkNewsSearchResult post, VkNewsFeed feed)
        {
            var id = post.FromId;
            var user = new UserQueryResult();
            if (id > 0)
            {
                var profile = feed.Profiles.FirstOrDefault(x => x.Id == id);
                user.NetworkId = id.ToString();
                user.UserName = $"{profile.FirstName} {profile.LastName}";
                user.ProfileId = profile.UserName;
                user.AvatarUrl50 = profile.PhotoLink50;
            }
            else
            {
                var vkGroup = feed.Groups.FirstOrDefault(x => x.Id == Math.Abs(id));
                user.NetworkId = id.ToString();
                user.UserName = $"{vkGroup.FirstName}";
                user.ProfileId = vkGroup.UserName;
                user.AvatarUrl50 = vkGroup.PhotoLink50;
            }
            return user;
        }
    }
}
