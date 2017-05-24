using System.Collections.Generic;
using System.Linq;

using HashtagAggregator.Core.Models.Results.Query.HashTag;
using HashtagAggregator.Core.Models.Results.Query.Message;
using HashtagAggregator.Core.Models.Results.Query.User;
using HashtagAggregator.Shared.Common.Infrastructure;
using HashtagAggregator.Shared.Contracts.Enums;

using Tweetinvi.Models;

namespace HashtagAggregator.Data.Internet.Assemblers
{
    public class TwitterMessageResultMapper
    {
        public MessagesQueryResult MapBunch(IEnumerable<ITweet> messages)
        {
            var results = new MessagesQueryResult();
            if (messages != null)
            {
                foreach (var tweet in messages)
                {
                    var message = MapSingle(tweet);
                    results.Messages.Add(message);
                }
            }
            return results;
        }

        public MessageQueryResult MapSingle(ITweet tweet)
        {
            UserQueryResult user = new UserQueryResult
            {
                NetworkId = tweet.CreatedBy.IdStr,
                Url = tweet.Url,
                UserName = tweet.CreatedBy.Name,
                AvatarUrl50 = tweet.CreatedBy.ProfileImageUrl,
                MediaType = SocialMediaType.Twitter
            };

            List<HashTagQueryResult> tags = tweet.Hashtags.Select(x => new HashTagQueryResult()
            {
                HashTag = new HashTagWord(x.Text),
                IsEnabled = false
            }).ToList();


            MessageQueryResult message = new MessageQueryResult(0,
                tweet.Text,
                tags,
                SocialMediaType.Twitter,
                tweet.TweetLocalCreationDate.ToUniversalTime(),
                tweet.IdStr,
                user);
            return message;
        }
    }
}