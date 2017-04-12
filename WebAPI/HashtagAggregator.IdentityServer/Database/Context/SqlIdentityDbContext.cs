using HashtagAggregator.IdentityServer.Database.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HashtagAggregator.IdentityServer.Database.Context
{
    public class SqlIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public SqlIdentityDbContext(DbContextOptions<SqlIdentityDbContext> options) : base(options)
        {
        }
    }
}
