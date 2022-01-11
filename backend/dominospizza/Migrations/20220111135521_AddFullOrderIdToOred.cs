using Microsoft.EntityFrameworkCore.Migrations;

namespace dominospizza.Migrations
{
    public partial class AddFullOrderIdToOred : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_FullOrders_FullOrderId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "FullOrderId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_FullOrders_FullOrderId",
                table: "Orders",
                column: "FullOrderId",
                principalTable: "FullOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_FullOrders_FullOrderId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "FullOrderId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_FullOrders_FullOrderId",
                table: "Orders",
                column: "FullOrderId",
                principalTable: "FullOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
