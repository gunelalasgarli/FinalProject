using Microsoft.EntityFrameworkCore.Migrations;

namespace dominospizza.Migrations
{
    public partial class NewColsAddedToDrinksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrinkSizes_Drinks_DrinksId",
                table: "DrinkSizes");

            migrationBuilder.DropIndex(
                name: "IX_DrinkSizes_DrinksId",
                table: "DrinkSizes");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Drinks",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Drinks",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Drinks");

            migrationBuilder.CreateIndex(
                name: "IX_DrinkSizes_DrinksId",
                table: "DrinkSizes",
                column: "DrinksId");

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkSizes_Drinks_DrinksId",
                table: "DrinkSizes",
                column: "DrinksId",
                principalTable: "Drinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
