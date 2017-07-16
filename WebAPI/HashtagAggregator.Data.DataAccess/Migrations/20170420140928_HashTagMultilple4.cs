using Microsoft.EntityFrameworkCore.Migrations;

namespace HashtagAggregator.Data.DataAccess.Migrations
{
    public partial class HashTagMultilple4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_TaggedMessages_Id",
                table: "TaggedMessages");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_TaggedMessages_HashTagEntityId_Id_MessageEntityId",
                table: "TaggedMessages",
                columns: new[] { "HashTagEntityId", "Id", "MessageEntityId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_TaggedMessages_HashTagEntityId_Id_MessageEntityId",
                table: "TaggedMessages");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_TaggedMessages_Id",
                table: "TaggedMessages",
                column: "Id");
        }
    }
}
