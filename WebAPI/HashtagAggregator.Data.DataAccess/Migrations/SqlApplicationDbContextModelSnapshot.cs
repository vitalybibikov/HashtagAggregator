using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HashtagAggregator.Data.DataAccess.Context;
using HashtagAggregator.Shared.Contracts.Enums;

namespace HashtagAggregator.Data.DataAccess.Migrations
{
    [DbContext(typeof(SqlApplicationDbContext))]
    partial class SqlApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HashtagAggregator.Core.Entities.EF.HashTagEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HashTag");

                    b.Property<bool>("IsEnabled");

                    b.Property<long?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("HashTag")
                        .IsUnique();

                    b.HasIndex("ParentId");

                    b.ToTable("Hashtags");
                });

            modelBuilder.Entity("HashtagAggregator.Core.Entities.EF.MessageEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MediaType");

                    b.Property<string>("MessageText");

                    b.Property<string>("NetworkId");

                    b.Property<DateTime?>("PostDate");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("NetworkId", "UserId")
                        .IsUnique();

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("HashtagAggregator.Core.Entities.EF.MessageHashTagRelationsEntity", b =>
                {
                    b.Property<long>("HashTagEntityId");

                    b.Property<long>("MessageEntityId");

                    b.HasKey("HashTagEntityId", "MessageEntityId");

                    b.HasIndex("MessageEntityId");

                    b.ToTable("TaggedMessages");
                });

            modelBuilder.Entity("HashtagAggregator.Core.Entities.EF.UserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AvatarUrl50");

                    b.Property<int>("MediaType");

                    b.Property<string>("NetworkId");

                    b.Property<string>("ProfileId");

                    b.Property<string>("Url");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("NetworkId", "MediaType")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HashtagAggregator.Core.Entities.EF.HashTagEntity", b =>
                {
                    b.HasOne("HashtagAggregator.Core.Entities.EF.HashTagEntity", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("HashtagAggregator.Core.Entities.EF.MessageEntity", b =>
                {
                    b.HasOne("HashtagAggregator.Core.Entities.EF.UserEntity", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HashtagAggregator.Core.Entities.EF.MessageHashTagRelationsEntity", b =>
                {
                    b.HasOne("HashtagAggregator.Core.Entities.EF.HashTagEntity", "HashTagEntity")
                        .WithMany("MessageHashTagRelations")
                        .HasForeignKey("HashTagEntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HashtagAggregator.Core.Entities.EF.MessageEntity", "MessageEntity")
                        .WithMany("MessageHashTagRelations")
                        .HasForeignKey("MessageEntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
