using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addingNameA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "NameE");

            migrationBuilder.AddColumn<string>(
                name: "NameA",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameA",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameE",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameA",
                table: "CourseCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameE",
                table: "CourseCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameA",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameE",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameA",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NameA",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "NameE",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "NameA",
                table: "CourseCategories");

            migrationBuilder.DropColumn(
                name: "NameE",
                table: "CourseCategories");

            migrationBuilder.DropColumn(
                name: "NameA",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "NameE",
                table: "Countries");

            migrationBuilder.RenameColumn(
                name: "NameE",
                table: "Students",
                newName: "Name");
        }
    }
}
