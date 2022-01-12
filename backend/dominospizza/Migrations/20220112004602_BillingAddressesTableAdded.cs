using Microsoft.EntityFrameworkCore.Migrations;

namespace dominospizza.Migrations
{
    public partial class BillingAddressesTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "FullOrders");

            migrationBuilder.DropColumn(
                name: "OrderDescription",
                table: "FullOrders");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "FullOrders");

            migrationBuilder.AddColumn<int>(
                name: "BillingAddressId",
                table: "FullOrders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BillingAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDescription = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingAddresses_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FullOrders_BillingAddressId",
                table: "FullOrders",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingAddresses_AppUserId",
                table: "BillingAddresses",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FullOrders_BillingAddresses_BillingAddressId",
                table: "FullOrders",
                column: "BillingAddressId",
                principalTable: "BillingAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FullOrders_BillingAddresses_BillingAddressId",
                table: "FullOrders");

            migrationBuilder.DropTable(
                name: "BillingAddresses");

            migrationBuilder.DropIndex(
                name: "IX_FullOrders_BillingAddressId",
                table: "FullOrders");

            migrationBuilder.DropColumn(
                name: "BillingAddressId",
                table: "FullOrders");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "FullOrders",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderDescription",
                table: "FullOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "FullOrders",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");
        }
    }
}
