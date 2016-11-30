using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

using MyStudyProject.Core.Contracts.Interface.ServiceFacades;
using MyStudyProject.Core.Cqrs.Results;
using MyStudyProject.Domain.Services.Assemblers;
using MyStudyProject.Shared.Common.Settings;

using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace MyStudyProject.Domain.Services.Services
{
    public class TwitterMessageServiceFacade : IMessageServiceFacade<MessageQueryResult>
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

        public async Task<IEnumerable<MessageQueryResult>> GetAll(string hashtag)
        {
            IEnumerable<ITweet> tweets = await SearchAsync.SearchTweets(hashtag);
            MessageQueryResultMapper mapper = new MessageQueryResultMapper();
            return mapper.MapBunch(tweets, hashtag);
        }

        public async Task<IEnumerable<MessageQueryResult>> GetNumber(int number, string hashtag)
        {
            var searchParameter = new SearchTweetsParameters(hashtag)
            {
                MaximumNumberOfResults = number
            };

            IEnumerable<ITweet> tweets = await SearchAsync.SearchTweets(searchParameter);
            MessageQueryResultMapper mapper = new MessageQueryResultMapper();
            return mapper.MapBunch(tweets, hashtag);
        }

        public async Task<IEnumerable<MessageQueryResult>> GetSinceLastId(long id, string hashtag)
        {
            var searchParameter = new SearchTweetsParameters(hashtag)
            {
                SinceId = id,
            };

            IEnumerable<ITweet> tweets = await SearchAsync.SearchTweets(searchParameter);
            MessageQueryResultMapper mapper = new MessageQueryResultMapper();
            return mapper.MapBunch(tweets, hashtag);
        }
    }
}
