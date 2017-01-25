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

namespace MyStudyProject.Data.Internet.Services.Twitter
{
    public class TwitterMessageServiceFacade : ITwitterMessageFacade
    {
        private readonly IOptions<TwitterSettings> settings;

        public TwitterMessageServiceFacade(IOptions<TwitterSettings> settings)
        {
            var appCredentials = new TwitterCredentials(settings.Value.ConsumerKey, settings.Value.ConsumerSecret);
            Auth.SetUserCredentials(
                settings.Value.ConsumerKey,
                settings.Value.ConsumerSecret,
                settings.Value.AccessToken,
                settings.Value.TokenSecret);
            AuthFlow.InitAuthentication(appCredentials);
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
            foreach (var command in filtered)
            {   //timeout: 10 000ms
                ITweet tweet = await TweetAsync.PublishTweet(command.Body);
                var fail = ExceptionHandler.GetLastException().TwitterDescription;
               
                if (fail != null)
                {
                    //todo: logging
                }
            }
            ICommandResult result = new CommandResult()
            {
                Success = true
            };
            return result;
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