using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

using HashtagAggregator.Data.DataAccess.Context;

namespace HashtagAggregator.Data.DataAccess.Migrations
{
    [DbContext(typeof(SqlApplicationDbContext))]
    [Migration("20170413084538_HashTagParentMigration")]
    partial class HashTagParentMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("ParentHashtag");

                    b.Property<long?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("HashTag")
                        .IsUnique();

                    b.ToTable("Hashtags");
                });

            modelBuilder.Entity("HashtagAggregator.Core.Entities.EF.MessageEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HashTag");

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

            modelBuilder.Entity("HashtagAggregator.Core.Entities.EF.MessageEntity", b =>
                {
                    b.HasOne("HashtagAggregator.Core.Entities.EF.UserEntity", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
