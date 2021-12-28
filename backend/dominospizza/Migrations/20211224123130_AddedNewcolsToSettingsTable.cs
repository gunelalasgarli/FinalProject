using Microsoft.EntityFrameworkCore.Migrations;

namespace dominospizza.Migrations
{
    public partial class AddedNewcolsToSettingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkImg",
                table: "Settings");

            migrationBuilder.AddColumn<string>(
                name: "PayImg",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialImg",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreImg",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayImg",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SocialImg",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "StoreImg",
                table: "Settings");

            migrationBuilder.AddColumn<string>(
                name: "LinkImg",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
