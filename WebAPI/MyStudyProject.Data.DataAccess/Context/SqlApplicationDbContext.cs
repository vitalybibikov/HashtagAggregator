using Microsoft.EntityFrameworkCore;
using MyStudyProject.Core.Entities.EF;

namespace MyStudyProject.Data.DataAccess.Context
{
    public class SqlApplicationDbContext : DbContext
    {
        public DbSet<MessageEntity> Messages { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public SqlApplicationDbContext(DbContextOptions<SqlApplicationDbContext> options)
            : base(options)
        {        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessageEntity>().HasIndex(i => new { i.NetworkId, i.UserId }).IsUnique();

            modelBuilder.Entity<UserEntity>().HasIndex(i => new { i.NetworkId, i.MediaType }).IsUnique();
            modelBuilder.Entity<MessageEntity>()
                .HasOne(m => m.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(u => u.UserId);
        }
    }
}
