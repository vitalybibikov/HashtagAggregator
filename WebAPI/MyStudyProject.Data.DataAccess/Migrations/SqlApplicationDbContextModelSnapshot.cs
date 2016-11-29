using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MyStudyProject.Data.DataAccess.Context;
using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.Data.DataAccess.Migrations
{
    [DbContext(typeof(SqlApplicationDbContext))]
    partial class SqlApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyStudyProject.Data.Entities.Entities.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<string>("HashTag");

                    b.Property<int>("MediaType");

                    b.Property<string>("PosedDate");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MyStudyProject.Data.Entities.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Media");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyStudyProject.Data.Entities.Entities.Message", b =>
                {
                    b.HasOne("MyStudyProject.Data.Entities.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
