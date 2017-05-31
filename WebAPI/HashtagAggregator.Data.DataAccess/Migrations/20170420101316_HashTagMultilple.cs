using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HashtagAggregator.Data.DataAccess.Migrations
{
    public partial class HashTagMultilple : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashTag",
                table: "Messages");

            migrationBuilder.CreateTable(
                name: "TaggedMessages",
                columns: table => new
                {
                    HashTagEntityId = table.Column<long>(nullable: false),
                    MessageEntityId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaggedMessages", x => new { x.HashTagEntityId, x.MessageEntityId });
                    table.UniqueConstraint("AK_TaggedMessages_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaggedMessages_Hashtags_HashTagEntityId",
                        column: x => x.HashTagEntityId,
                        principalTable: "Hashtags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaggedMessages_Messages_MessageEntityId",
                        column: x => x.MessageEntityId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaggedMessages_MessageEntityId",
                table: "TaggedMessages",
                column: "MessageEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaggedMessages");

            migrationBuilder.AddColumn<string>(
                name: "HashTag",
                table: "Messages",
                nullable: true);
        }
    }
}
