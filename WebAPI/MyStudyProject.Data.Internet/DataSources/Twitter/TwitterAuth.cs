using Microsoft.Extensions.Options;
using MyStudyProject.Data.Contracts.Interface;
using MyStudyProject.Shared.Common.Settings;

using Tweetinvi;
using Tweetinvi.Models;

namespace MyStudyProject.Data.Internet.DataSources.Twitter
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
