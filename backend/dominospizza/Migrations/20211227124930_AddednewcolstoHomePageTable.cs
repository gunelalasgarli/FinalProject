using Microsoft.EntityFrameworkCore.Migrations;

namespace dominospizza.Migrations
{
    public partial class AddednewcolstoHomePageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "SectionImg",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "Subtitle",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "TextImg",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "HomePages");

            migrationBuilder.AddColumn<string>(
                name: "Description1",
                table: "HomePages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description2",
                table: "HomePages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description3",
                table: "HomePages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SectionImg1",
                table: "HomePages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SectionImg2",
                table: "HomePages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SectionImg3",
                table: "HomePages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subtitle1",
                table: "HomePages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subtitle2",
                table: "HomePages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subtitle3",
                table: "HomePages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title1",
                table: "HomePages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title2",
                table: "HomePages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title3",
                table: "HomePages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description1",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "Description2",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "Description3",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "SectionImg1",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "SectionImg2",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "SectionImg3",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "Subtitle1",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "Subtitle2",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "Subtitle3",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "Title1",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "Title2",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "Title3",
                table: "HomePages");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SectionImg",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subtitle",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextImg",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
