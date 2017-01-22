using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using MyStudyProject.Data.Contracts.Interface;
using MyStudyProject.Data.Entities.Entities;
using MyStudyProject.Shared.Common.Settings;

namespace MyStudyProject.Data.DataAccess.Context
{
    public class SqlApplicationDbContext : DbContext, IApplicationContext
    {
        //public string ConnectionString { get; }
        public DbSet<MessageEntity> Messages { get; set; }

        public SqlApplicationDbContext(DbContextOptions<SqlApplicationDbContext> options)
            : base(options)
        {
        }

        //public SqlApplicationDbContext(IOptions<AppSettings> appSettings)
        //{
        //    ConnectionString = appSettings.Value.ConnectionString;
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessageEntity>().HasIndex(i => new { i.NetworkId, i.UserId }).IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(ConnectionString);
            //base.OnConfiguring(optionsBuilder);
        }
    }
}
