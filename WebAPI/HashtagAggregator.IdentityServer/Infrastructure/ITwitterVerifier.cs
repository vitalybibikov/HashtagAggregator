using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HashtagAggregator.IdentityServer.Infrastructure
{
    public interface ITwitterVerifier
    {
        Task<string> GetEmailAsync(ExternalLoginInfo info);
    }
}
