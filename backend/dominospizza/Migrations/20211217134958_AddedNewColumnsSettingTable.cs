using Microsoft.EntityFrameworkCore.Migrations;

namespace dominospizza.Migrations
{
    public partial class AddedNewColumnsSettingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Settings");

            migrationBuilder.AddColumn<string>(
                name: "LinkImg",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneImg",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNum",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SectionImg",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SignImg",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextImg",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkImg",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "PhoneImg",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "PhoneNum",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SectionImg",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SignImg",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "TextImg",
                table: "Settings");

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Settings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
