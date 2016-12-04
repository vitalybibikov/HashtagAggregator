using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

using MyStudyProject.Core.Models.Results.Query;
using MyStudyProject.Domain.Services.Assemblers.Twitter;
using MyStudyProject.Shared.Common.Settings;

using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace MyStudyProject.Domain.Services.Services.Twitter
{
    public class TwitterMessageServiceFacade : ITwitterServiceFacade
    {
        private readonly IOptions<TwitterSettings> settings;

        public TwitterMessageServiceFacade(IOptions<TwitterSettings> settings)
        {
            Auth.SetUserCredentials(
                settings.Value.ConsumerKey,
                settings.Value.ConsumerSecret,
                settings.Value.AccessToken,
                settings.Value.TokenSecret);

            this.settings = settings;
        }

        public async Task<IEnumerable<MessageQueryResult>> GetAllAsync(string hashtag)
        {
            IEnumerable<ITweet> tweets = await SearchAsync.SearchTweets(hashtag);
            TwitterMessageResultMapper mapper = new TwitterMessageResultMapper();
            return mapper.MapBunch(tweets, hashtag);
        }

        public async Task<IEnumerable<MessageQueryResult>> GetNumberAsync(int number, string hashtag)
        {
            var searchParameter = new SearchTweetsParameters(hashtag)
            {
                MaximumNumberOfResults = number
            };

            IEnumerable<ITweet> tweets = await SearchAsync.SearchTweets(searchParameter);
            TwitterMessageResultMapper mapper = new TwitterMessageResultMapper();
            return mapper.MapBunch(tweets, hashtag);
        }

        public async Task<IEnumerable<MessageQueryResult>> GetSinceLastIdAsync(long id, string hashtag)
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