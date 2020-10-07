using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddTitleAndDescriptionPresentation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Presentations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Presentations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Presentations");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Presentations");
        }
    }
}
