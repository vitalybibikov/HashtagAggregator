using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HashtagAggregator.Data.DataAccess.Migrations
{
    public partial class HashTagParentMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentHashtag",
                table: "Hashtags");

            migrationBuilder.CreateIndex(
                name: "IX_Hashtags_ParentId",
                table: "Hashtags",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hashtags_Hashtags_ParentId",
                table: "Hashtags",
                column: "ParentId",
                principalTable: "Hashtags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hashtags_Hashtags_ParentId",
                table: "Hashtags");

            migrationBuilder.DropIndex(
                name: "IX_Hashtags_ParentId",
                table: "Hashtags");

            migrationBuilder.AddColumn<string>(
                name: "ParentHashtag",
                table: "Hashtags",
                nullable: true);
        }
    }
}
