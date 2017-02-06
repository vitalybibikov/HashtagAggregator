using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace MyStudyProject.Data.Contracts.Interface
{
    public interface ITwitterAuth
    {
        IAuthenticationContext Authenticate();
    }
}
