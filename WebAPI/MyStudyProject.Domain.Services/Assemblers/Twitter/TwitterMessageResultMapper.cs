using System.Collections.Generic;
using MyStudyProject.Core.Contracts.Interface;

using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Shared.Contracts.Enums;
using Tweetinvi.Models;

namespace MyStudyProject.Domain.Services.Assemblers.Twitter
{
    public class TwitterMessageResultMapper : IMapper<MessageQueryResult, ITweet>
    {
        public MessageQueryResult Map(ITweet tweet, string hashtag)
        {
            MessageQueryResult message = new MessageQueryResult
            {
                Body = tweet.Text,
                HashTag = hashtag,
                Id = tweet.Id,
                PostDate = tweet.TweetLocalCreationDate,
                Media = SocialMediaType.Twitter
            };
            return message;
        }

        public IEnumerable<MessageQueryResult> MapBunch(IEnumerable<ITweet> messages, string hashtag)
        {
            var results = new List<MessageQueryResult>();
            foreach (var tweet in messages)
            {
                MessageQueryResult message = new MessageQueryResult()
                {
                    Body = tweet.Text,
                    HashTag = hashtag,
                    Id = tweet.Id,
                    PostDate = tweet.TweetLocalCreationDate,
                    Media =  SocialMediaType.Twitter
                };
                results.Add(message);
            }
            return results;
        }
    }
}
