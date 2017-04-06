using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

using MyStudyProject.IdentityServer.Configuration;

namespace MyStudyProject.IdentityServer.Infrastructure
{
    public class TwitterVerifier : ITwitterVerifier
    {
        private readonly IOptions<TwitterAuthSettings> settings;

        public TwitterVerifier(IOptions<TwitterAuthSettings> settings)
        {
            this.settings = settings;
        }

        public async Task<string> GetEmailAsync(ExternalLoginInfo info)
        {
            var key = settings.Value.ConsumerSecret;
            var secretKey = settings.Value.ConsumerKey;

            var access = info.AuthenticationTokens.ToList().First(x => x.Name == "access_token").Value;
            var secret = info.AuthenticationTokens.ToList().First(x => x.Name == "access_token_secret").Value;

            var loginVerifier = new TwitterLoginVerifier();
            var result = await loginVerifier.TwitterLoginAsync(access, secret, key, secretKey);
            return result;
        }
    }
}
