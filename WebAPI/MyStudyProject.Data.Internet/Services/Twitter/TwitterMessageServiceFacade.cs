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
using MyStudyProject.Core.Cqrs.Converters;
using MyStudyProject.Data.Contracts.Interface.JobObjects;

namespace MyStudyProject.Data.Internet.Services.Twitter
{
    public class TwitterMessageServiceFacade : ITwitterMessageFacade
    {
        private readonly IOptions<TwitterApiSettings> settings;

        public TwitterMessageServiceFacade(IOptions<TwitterApiSettings> settings, ITwitterAuth auth)
        {
            auth.Authenticate();
            this.settings = settings;
        }

        public async Task<MessagesQueryResult> GetAllAsync(string hashtag)
        {
            IEnumerable<ITweet> tweets = await SearchAsync.SearchTweets(hashtag);
            TwitterMessageResultMapper mapper = new TwitterMessageResultMapper();
            return mapper.MapBunch(tweets, hashtag);
        }

        public async Task<ICommandResult> Save(IEnumerable<MessageCreateCommand> filtered)
        {
            //todo: refactor
            try
            {
                var seconds = 1;
                foreach (MessageCreateCommand command in filtered)
                {
                    var converted = command.BodyConvert(settings.Value.MaxBodyLength);
                    BackgroundJob.Schedule<ITwitterBackgroundJob<MessageCreateCommand>>(
                        x => x.Publish(converted),
                        TimeSpan.FromSeconds(seconds));
                    seconds += settings.Value.TwitterMessagePublishDelay;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //todo: logging here
                throw;
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