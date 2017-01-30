using System.Collections.Generic;

using MyStudyProject.Core.Contracts.Interface;
using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Shared.Contracts.Enums;

using Tweetinvi.Models;

namespace MyStudyProject.Data.Internet.Assemblers.Twitter
{
    public class TwitterMessageResultMapper : IMapper<ITweet, MessagesQueryResult>
    {
        public MessagesQueryResult MapBunch(IEnumerable<ITweet> messages, string hashtag)
        {
            var results = new MessagesQueryResult();
            foreach (var tweet in messages)
            {
                MessageQueryResult message = new MessageQueryResult(0,
                    tweet.Text,
                    hashtag,
                    SocialMediaType.Twitter,
                    tweet.TweetLocalCreationDate, tweet.IdStr,
                    tweet.CreatedBy.IdStr);
                results.Messages.Add(message);
            }
            return results;
        }
    }
}
