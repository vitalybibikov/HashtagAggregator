using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HashtagAggregator.Data.DataAccess.Migrations
{
    public partial class HashTagMultilple5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_TaggedMessages_HashTagEntityId_Id_MessageEntityId",
                table: "TaggedMessages");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TaggedMessages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "TaggedMessages",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_TaggedMessages_HashTagEntityId_Id_MessageEntityId",
                table: "TaggedMessages",
                columns: new[] { "HashTagEntityId", "Id", "MessageEntityId" });
        }
    }
}
