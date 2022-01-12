using Microsoft.EntityFrameworkCore.Migrations;

namespace dominospizza.Migrations
{
    public partial class AddedNameImageTotable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "BasketItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BasketItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BasketItems");
        }
    }
}
