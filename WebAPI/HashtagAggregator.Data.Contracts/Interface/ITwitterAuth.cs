using Tweetinvi.Models;

namespace HashtagAggregator.Data.Contracts.Interface
{
    public interface ITwitterAuth
    {
        IAuthenticationContext Authenticate();
    }
}
