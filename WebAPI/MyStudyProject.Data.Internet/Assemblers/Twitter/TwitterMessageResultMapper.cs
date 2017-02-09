﻿using System.Collections.Generic;

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
                    var message = MapSingle(tweet, hashtag);
                    results.Messages.Add(message);
                }
            }
            return results;
        }

        public MessageQueryResult MapSingle(ITweet tweet, string hashtag)
        {
            UserQueryResult user = new UserQueryResult
            {
                NetworkId = tweet.CreatedBy.IdStr,
                Url = tweet.Url
            };

            MessageQueryResult message = new MessageQueryResult(0,
                tweet.Text,
                hashtag,
                SocialMediaType.Twitter,
                tweet.TweetLocalCreationDate, tweet.IdStr,
                user);
            return message;
        }
    }
}
