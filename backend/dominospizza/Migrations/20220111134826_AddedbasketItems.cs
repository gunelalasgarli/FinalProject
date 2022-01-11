using Microsoft.EntityFrameworkCore.Migrations;

namespace dominospizza.Migrations
{
    public partial class AddedbasketItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "FullOrders");

            migrationBuilder.AddColumn<int>(
                name: "FullOrderId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderDescription",
                table: "FullOrders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FullOrderId",
                table: "Orders",
                column: "FullOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_AppUserId",
                table: "BasketItems",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_FullOrders_FullOrderId",
                table: "Orders",
                column: "FullOrderId",
                principalTable: "FullOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_FullOrders_FullOrderId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FullOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FullOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderDescription",
                table: "FullOrders");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "FullOrders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
