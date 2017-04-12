using HashtagAggregator.Data.Contracts.Interface;
using HashtagAggregator.Shared.Common.Settings;
using Microsoft.Extensions.Options;
using Tweetinvi;
using Tweetinvi.Models;

namespace HashtagAggregator.Data.Internet.DataSources.Twitter
{
    public class TwitterAuth : ITwitterAuth
    {
        private IOptions<TwitterAuthSettings> settings;

        public TwitterAuth(IOptions<TwitterAuthSettings> settings)
        {
            this.settings = settings;
        }

        public IAuthenticationContext Authenticate()
        {
            //todo: test settings
            var appCredentials = new TwitterCredentials(settings.Value.ConsumerKey, settings.Value.ConsumerSecret);
            Auth.SetUserCredentials(
                settings.Value.ConsumerKey,
                settings.Value.ConsumerSecret,
                settings.Value.AccessToken,
                settings.Value.TokenSecret);
            
            return AuthFlow.InitAuthentication(appCredentials);
        }
    }
}
