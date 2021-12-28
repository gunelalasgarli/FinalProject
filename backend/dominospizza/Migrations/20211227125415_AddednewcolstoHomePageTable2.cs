using Microsoft.EntityFrameworkCore.Migrations;

namespace dominospizza.Migrations
{
    public partial class AddednewcolstoHomePageTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description3",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "SectionImg3",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "Subtitle3",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "Title3",
                table: "HomePages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description3",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SectionImg3",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subtitle3",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title3",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
