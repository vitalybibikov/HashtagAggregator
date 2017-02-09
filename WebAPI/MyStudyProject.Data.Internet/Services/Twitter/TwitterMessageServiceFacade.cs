using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

using MyStudyProject.Core.Contracts.Interface.Cqrs.Command;
using MyStudyProject.Core.Models.Commands;
using MyStudyProject.Core.Models.Results.Command;
using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Data.Contracts.ServiceFacades;
using MyStudyProject.Data.Internet.Assemblers.Twitter;
using MyStudyProject.Shared.Common.Settings;
using MyStudyProject.Data.Contracts.Interface;

using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

using Hangfire;
using Microsoft.Extensions.Logging;
using MyStudyProject.Core.Cqrs.Converters;
using MyStudyProject.Data.Contracts.Interface.JobObjects;
using MyStudyProject.Shared.Logging;

namespace MyStudyProject.Data.Internet.Services.Twitter
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
            IEnumerable<ITweet> tweets = await SearchAsync.SearchTweets(hashtag);
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