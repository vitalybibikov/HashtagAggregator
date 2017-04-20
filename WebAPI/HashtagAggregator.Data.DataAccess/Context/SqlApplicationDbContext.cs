using HashtagAggregator.Core.Entities.EF;

using Microsoft.EntityFrameworkCore;

namespace HashtagAggregator.Data.DataAccess.Context
{
    public class SqlApplicationDbContext : DbContext
    {
        public DbSet<MessageEntity> Messages { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<HashTagEntity> Hashtags { get; set; }

        public DbSet<MessageHashTagRelationsEntity> TaggedMessages { get; set; }

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

            //many to many configuration between Tags And Messages
            modelBuilder.Entity<MessageHashTagRelationsEntity>()
                .HasKey(t => new { t.HashTagEntityId, t.MessageEntityId });

            modelBuilder.Entity<MessageHashTagRelationsEntity>()
                .HasOne(pt => pt.MessageEntity)
                .WithMany(p => p.MessageHashTagRelations)
                .HasForeignKey(pt => pt.MessageEntityId);

            modelBuilder.Entity<MessageHashTagRelationsEntity>()
                .HasOne(pt => pt.HashTagEntity)
                .WithMany(t => t.MessageHashTagRelations)
                .HasForeignKey(pt => pt.HashTagEntityId);
        }
    }
}
