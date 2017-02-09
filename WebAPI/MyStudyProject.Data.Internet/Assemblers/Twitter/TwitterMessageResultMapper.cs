using System.Collections.Generic;

using MyStudyProject.Core.Contracts.Interface;
using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Shared.Contracts.Enums;

using Tweetinvi.Models;

namespace MyStudyProject.Data.Internet.Assemblers.Twitter
{
    public class TwitterMessageResultMapper
    {
        public MessagesQueryResult MapBunch(IEnumerable<ITweet> messages, string hashtag)
        {
            var results = new MessagesQueryResult();
            if (messages != null)
            {
                foreach (var tweet in messages)
                {
                    UserQueryResult user = new UserQueryResult();
                    user.NetworkId = tweet.CreatedBy.IdStr;
                    user.Url = tweet.Url;

                    MessageQueryResult message = new MessageQueryResult(0,
                        tweet.Text,
                        hashtag,
                        SocialMediaType.Twitter,
                        tweet.TweetLocalCreationDate, tweet.IdStr,
                        user);
                    results.Messages.Add(message);
                }
            }
            return results;
        }
    }
}
