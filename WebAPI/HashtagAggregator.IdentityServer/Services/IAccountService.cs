using System.Threading.Tasks;
using HashtagAggregator.IdentityServer.Models;
using HashtagAggregator.IdentityServer.ViewModels;

namespace HashtagAggregator.IdentityServer.Services
{
    public interface IAccountService
    {
        Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl);

        Task<LoginViewModel> BuildLoginViewModelAsync(LoginInputModel model);

        Task<string> BuildLogoutViewModelAsync(string logoutId);
    }
}
