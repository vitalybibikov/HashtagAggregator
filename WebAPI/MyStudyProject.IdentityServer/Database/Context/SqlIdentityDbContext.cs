using System;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyStudyProject.IdentityServer.Identity;

namespace MyStudyProject.IdentityServer.Database.Context
{
    public class SqlIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public SqlIdentityDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
