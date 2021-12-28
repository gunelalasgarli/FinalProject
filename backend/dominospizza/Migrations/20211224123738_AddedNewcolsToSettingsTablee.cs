using Microsoft.EntityFrameworkCore.Migrations;

namespace dominospizza.Migrations
{
    public partial class AddedNewcolsToSettingsTablee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Settings");

            migrationBuilder.AddColumn<string>(
                name: "SocialLink",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreLink",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SocialLink",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "StoreLink",
                table: "Settings");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
