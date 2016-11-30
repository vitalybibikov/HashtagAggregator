using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using MyStudyProject.Data.Contracts.Interface;
using MyStudyProject.Data.Entities.Entities;
using MyStudyProject.Shared.Common.Settings;

namespace MyStudyProject.Data.DataAccess.Context
{
    public class SqlApplicationDbContext : DbContext, IApplicationContext
    {
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        public SqlApplicationDbContext(IOptions<AppSettings> appSettings)
        {
            ConnectionString = appSettings.Value.ConnectionString;
        }

        public string ConnectionString { get; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
