using Microsoft.EntityFrameworkCore.Migrations;

namespace dominospizza.Migrations
{
    public partial class AddedPriceToBasketItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "BasketItems",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "BasketItems");
        }
    }
}
