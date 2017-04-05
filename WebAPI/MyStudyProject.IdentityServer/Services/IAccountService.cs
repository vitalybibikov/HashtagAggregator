using System.Threading.Tasks;

using MyStudyProject.IdentityServer.Models;
using MyStudyProject.IdentityServer.ViewModels;

namespace MyStudyProject.IdentityServer.Services
{
    public interface IAccountService
    {
        Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl);

        Task<LoginViewModel> BuildLoginViewModelAsync(LoginInputModel model);

        Task<string> BuildLogoutViewModelAsync(string logoutId);
    }
}
