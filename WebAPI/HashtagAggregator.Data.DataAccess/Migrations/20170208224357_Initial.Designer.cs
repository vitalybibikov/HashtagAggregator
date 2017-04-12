using System;
using HashtagAggregator.Data.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HashtagAggregator.Data.DataAccess.Migrations
{
    [DbContext(typeof(SqlApplicationDbContext))]
    [Migration("20170208224357_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HashtagAggregator.Data.Entities.Entities.MessageEntity", b =>
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

            modelBuilder.Entity("HashtagAggregator.Data.Entities.Entities.UserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NetworkId");

                    b.Property<string>("ProfileId");

                    b.Property<string>("ProfileUrl");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HashtagAggregator.Data.Entities.Entities.MessageEntity", b =>
                {
                    b.HasOne("HashtagAggregator.Data.Entities.Entities.UserEntity", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
