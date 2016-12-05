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
                MessageQueryResult message = new MessageQueryResult()
                {
                    Body = tweet.Text,
                    HashTag = hashtag,
                    PostDate = tweet.TweetLocalCreationDate,
                    Media =  SocialMediaType.Twitter,
                    NetworkId = tweet.IdStr,
                    UserId = tweet.CreatedBy.IdStr
                };
                results.Messages.Add(message);
            }
            return results;
        }
    }
}
