using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.DataSources;
using HashtagAggregator.Core.Models;
using HashtagAggregator.Core.Models.Commands;
using HashtagAggregator.Core.Models.Interface.Cqrs.Command;
using HashtagAggregator.Core.Models.Queries;
using HashtagAggregator.Core.Models.Results.Query;
using HashtagAggregator.Data.Contracts.Interface;
using HashtagAggregator.Data.Internet.Assemblers;
using HashtagAggregator.Shared.Common.Settings;
using HashtagAggregator.Shared.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace HashtagAggregator.Data.Internet.DataSources.Twitter
{
    public class TwitterMessageServiceFacade : ITwitterMessageFacade
    {
        private readonly IOptions<TwitterApiSettings> settings;
        private readonly ILogger<TwitterMessageServiceFacade> logger;

        public TwitterMessageServiceFacade(IOptions<TwitterApiSettings> settings, ITwitterAuth auth, ILogger<TwitterMessageServiceFacade> logger)
        {
            auth.Authenticate();
            this.settings = settings;
            this.logger = logger;
        }

        public async Task<MessagesQueryResult> GetAllAsync(string hashtag)
        {
            ISearchTweetsParameters tweetsParameters = new SearchTweetsParameters(hashtag);
            tweetsParameters.TweetSearchType = TweetSearchType.OriginalTweetsOnly;
            IEnumerable<ITweet> tweets = await SearchAsync.SearchTweets(tweetsParameters);

            var fail = ExceptionHandler.GetLastException()?.TwitterDescription;
            if (!String.IsNullOrEmpty(fail))
            {
                logger.LogError(
                    LoggingEvents.EXCEPTION_GET_TWITTER_MESSAGE, 
                    "Failed to get messages by {hashtag} with {error}", 
                    hashtag, 
                    fail);
            }
            var mapper = new TwitterMessageResultMapper();
            return mapper.MapBunch(tweets, hashtag);
        }

        public async Task<ICommandResult> Save(IEnumerable<MessageCreateCommand> filtered)
        {
            var publishIntervalInSec = 1;
            foreach (MessageCreateCommand command in filtered)
            {
                MessageCreateCommand converted = null;
                try
                {
                    converted = command.BodyConvert(settings.Value.MaxBodyLength);
                    //BackgroundJob.Schedule<ITwitterBackgroundJob<MessageCreateCommand>>(
                    //    x => x.Publish(converted),
                    //    TimeSpan.FromSeconds(publishIntervalInSec));
                    //publishIntervalInSec += settings.Value.TwitterMessagePublishDelay;
                }
                catch (Exception ex)
                {
                    logger.LogError(
                        LoggingEvents.EXCEPTION_SAVE_TWITTER_MESSAGE,
                        ex,
                        "Failed to save {@message} to twitter.",
                        converted);
                }
            }
            return new CommandResult { Success = true };
        }

        public async Task<MessagesQueryResult> GetNumberAsync(int number, string hashtag)
        {
            var searchParameter = new SearchTweetsParameters(hashtag)
            {
                MaximumNumberOfResults = number
            };

            IEnumerable<ITweet> tweets = await SearchAsync.SearchTweets(searchParameter);
            TwitterMessageResultMapper mapper = new TwitterMessageResultMapper();
            return mapper.MapBunch(tweets, hashtag);
        }

        public async Task<MessagesQueryResult> GetSinceLastIdAsync(long id, string hashtag)
        {
            var searchParameter = new SearchTweetsParameters(hashtag)
            {
                SinceId = id,
            };

            IEnumerable<ITweet> tweets = await SearchAsync.SearchTweets(searchParameter);
            TwitterMessageResultMapper mapper = new TwitterMessageResultMapper();
            return mapper.MapBunch(tweets, hashtag);
        }
    }
}