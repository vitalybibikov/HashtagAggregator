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

using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;
using Hangfire;
using MyStudyProject.Data.Contracts.Interface;

namespace MyStudyProject.Data.Internet.Services.Twitter
{
    public class TwitterMessageServiceFacade : ITwitterMessageFacade
    {
        private readonly IOptions<TwitterSettings> settings;

        public TwitterMessageServiceFacade(IOptions<TwitterSettings> settings, ITwitterAuth auth)
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
                foreach (var command in filtered)
                {
                    BackgroundJob.Schedule<ITwitterBackgroundJob<MessageCreateCommand>>(
                        x => x.PublishTweet(command),
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
            return new CommandResult { Success = true }; ;
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