using Microsoft.EntityFrameworkCore.Migrations;

namespace HashtagAggregator.Data.DataAccess.Migrations
{
    public partial class Update01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileUrl",
                table: "Users",
                newName: "Url");

            migrationBuilder.AlterColumn<string>(
                name: "NetworkId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MediaType",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_NetworkId_MediaType",
                table: "Users",
                columns: new[] { "NetworkId", "MediaType" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_NetworkId_MediaType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MediaType",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Users",
                newName: "ProfileUrl");

            migrationBuilder.AlterColumn<string>(
                name: "NetworkId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
