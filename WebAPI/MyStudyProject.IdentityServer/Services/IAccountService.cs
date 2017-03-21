using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStudyProject.IdentityServer.Models;
using MyStudyProject.IdentityServer.ViewModels;

namespace MyStudyProject.IdentityServer.Services
{
    public interface IAccountService
    {
        Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl);

        Task<LoginViewModel> BuildLoginViewModelAsync(LoginInputModel model);
    }
}
