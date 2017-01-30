using System;
using Microsoft.Extensions.Options;
using MyStudyProject.Data.Contracts.Interface;
using MyStudyProject.Shared.Common.Settings;

using Tweetinvi;
using Tweetinvi.Models;

namespace MyStudyProject.Data.Internet.Services.Twitter
{
    public class TwitterAuth : ITwitterAuth
    {
        private IOptions<TwitterAuthSettings> settings;

        public TwitterAuth(IOptions<TwitterAuthSettings> settings)
        {
            this.settings = settings;
        }

        public void Authenticate()
        {
            var appCredentials = new TwitterCredentials(settings.Value.ConsumerKey, settings.Value.ConsumerSecret);
            Auth.SetUserCredentials(
                settings.Value.ConsumerKey,
                settings.Value.ConsumerSecret,
                settings.Value.AccessToken,
                settings.Value.TokenSecret);
            AuthFlow.InitAuthentication(appCredentials);
        }
    }
}
