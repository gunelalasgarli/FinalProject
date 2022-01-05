using Microsoft.EntityFrameworkCore.Migrations;

namespace dominospizza.Migrations
{
    public partial class UpdatedOrderItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "OrderItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_AppUserId",
                table: "OrderItems",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_AspNetUsers_AppUserId",
                table: "OrderItems",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_AspNetUsers_AppUserId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_AppUserId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "OrderItems");

            migrationBuilder.AlterColumn<int>(
                name: "Total",
                table: "OrderItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
