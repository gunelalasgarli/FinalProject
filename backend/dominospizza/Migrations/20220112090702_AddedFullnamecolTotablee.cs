using Microsoft.EntityFrameworkCore.Migrations;

namespace dominospizza.Migrations
{
    public partial class AddedFullnamecolTotablee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "FullOrders");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "BillingAddresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "BillingAddresses");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "FullOrders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
