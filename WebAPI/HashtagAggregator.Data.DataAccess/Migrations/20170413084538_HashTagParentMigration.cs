using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HashtagAggregator.Data.DataAccess.Migrations
{
    public partial class HashTagParentMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HashTag",
                table: "Hashtags",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParentHashtag",
                table: "Hashtags",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "Hashtags",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hashtags_HashTag",
                table: "Hashtags",
                column: "HashTag",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Hashtags_HashTag",
                table: "Hashtags");

            migrationBuilder.DropColumn(
                name: "ParentHashtag",
                table: "Hashtags");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Hashtags");

            migrationBuilder.AlterColumn<string>(
                name: "HashTag",
                table: "Hashtags",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
