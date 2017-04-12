using HashtagAggregator.Core.Entities.EF;

using Microsoft.EntityFrameworkCore;

namespace HashtagAggregator.Data.DataAccess.Context
{
    public class SqlApplicationDbContext : DbContext
    {
        public DbSet<MessageEntity> Messages { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<HashTagEntity> Hashtags { get; set; }

        public SqlApplicationDbContext(DbContextOptions<SqlApplicationDbContext> options)
            : base(options)
        {        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HashTagEntity>().HasIndex(i => new { i.HashTag }).IsUnique();
            modelBuilder.Entity<UserEntity>().HasIndex(i => new { i.NetworkId, i.MediaType }).IsUnique();
            modelBuilder.Entity<MessageEntity>().HasIndex(i => new { i.NetworkId, i.UserId }).IsUnique(); 
            modelBuilder.Entity<MessageEntity>()
                .HasOne(m => m.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(u => u.UserId);
        }
    }
}
