using Microsoft.EntityFrameworkCore.Migrations;

namespace Student.Api.Migrations
{
    public partial class ChangePhotoNameToPhotoPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoName",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "PhotoName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
