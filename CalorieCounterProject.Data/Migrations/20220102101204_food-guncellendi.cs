using Microsoft.EntityFrameworkCore.Migrations;

namespace CalorieCounterProject.Data.Migrations
{
    public partial class foodguncellendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Foods",
                newName: "UrlName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UrlName",
                table: "Foods",
                newName: "Note");
        }
    }
}
