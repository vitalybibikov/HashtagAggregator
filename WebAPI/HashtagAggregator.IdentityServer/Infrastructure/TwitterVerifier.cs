using System.Linq;
using System.Threading.Tasks;
using HashtagAggregator.IdentityServer.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace HashtagAggregator.IdentityServer.Infrastructure
{
    public class TwitterVerifier : ITwitterVerifier
    {
        private const string AccessTokenName = "access_token";
        private const string AccessTokenSecretName = "access_token_secret";

        private readonly IOptions<TwitterAuthSettings> settings;

        public TwitterVerifier(IOptions<TwitterAuthSettings> settings)
        {
            this.settings = settings;
        }

        public async Task<string> GetEmailAsync(ExternalLoginInfo info)
        {
            var key = settings.Value.ConsumerKey;
            var secretKey = settings.Value.ConsumerSecret;

            var access = info.AuthenticationTokens.ToList().First(x => x.Name == AccessTokenName).Value;
            var secret = info.AuthenticationTokens.ToList().First(x => x.Name == AccessTokenSecretName).Value;

            var loginVerifier = new TwitterLoginVerifier();
            return await loginVerifier.TwitterLoginAsync(access, secret, key, secretKey);
        }
    }
}
