using Microsoft.EntityFrameworkCore.Migrations;

namespace dominospizza.Migrations
{
    public partial class AddedDrinksSizeandProductSize1Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrinkSize_Drinks_DrinksId",
                table: "DrinkSize");

            migrationBuilder.DropForeignKey(
                name: "FK_DrinkSize_Sizes_SizesId",
                table: "DrinkSize");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_Products_ProductId",
                table: "ProductSize");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_Sizes_SizesId",
                table: "ProductSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSize",
                table: "ProductSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DrinkSize",
                table: "DrinkSize");

            migrationBuilder.RenameTable(
                name: "ProductSize",
                newName: "ProductSizes");

            migrationBuilder.RenameTable(
                name: "DrinkSize",
                newName: "DrinkSizes");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSize_SizesId",
                table: "ProductSizes",
                newName: "IX_ProductSizes_SizesId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSize_ProductId",
                table: "ProductSizes",
                newName: "IX_ProductSizes_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_DrinkSize_SizesId",
                table: "DrinkSizes",
                newName: "IX_DrinkSizes_SizesId");

            migrationBuilder.RenameIndex(
                name: "IX_DrinkSize_DrinksId",
                table: "DrinkSizes",
                newName: "IX_DrinkSizes_DrinksId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSizes",
                table: "ProductSizes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DrinkSizes",
                table: "DrinkSizes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkSizes_Drinks_DrinksId",
                table: "DrinkSizes",
                column: "DrinksId",
                principalTable: "Drinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkSizes_Sizes_SizesId",
                table: "DrinkSizes",
                column: "SizesId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_Products_ProductId",
                table: "ProductSizes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_Sizes_SizesId",
                table: "ProductSizes",
                column: "SizesId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrinkSizes_Drinks_DrinksId",
                table: "DrinkSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_DrinkSizes_Sizes_SizesId",
                table: "DrinkSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Products_ProductId",
                table: "ProductSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Sizes_SizesId",
                table: "ProductSizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSizes",
                table: "ProductSizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DrinkSizes",
                table: "DrinkSizes");

            migrationBuilder.RenameTable(
                name: "ProductSizes",
                newName: "ProductSize");

            migrationBuilder.RenameTable(
                name: "DrinkSizes",
                newName: "DrinkSize");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSizes_SizesId",
                table: "ProductSize",
                newName: "IX_ProductSize_SizesId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSizes_ProductId",
                table: "ProductSize",
                newName: "IX_ProductSize_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_DrinkSizes_SizesId",
                table: "DrinkSize",
                newName: "IX_DrinkSize_SizesId");

            migrationBuilder.RenameIndex(
                name: "IX_DrinkSizes_DrinksId",
                table: "DrinkSize",
                newName: "IX_DrinkSize_DrinksId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSize",
                table: "ProductSize",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DrinkSize",
                table: "DrinkSize",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkSize_Drinks_DrinksId",
                table: "DrinkSize",
                column: "DrinksId",
                principalTable: "Drinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkSize_Sizes_SizesId",
                table: "DrinkSize",
                column: "SizesId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_Products_ProductId",
                table: "ProductSize",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_Sizes_SizesId",
                table: "ProductSize",
                column: "SizesId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
