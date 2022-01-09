using Microsoft.EntityFrameworkCore.Migrations;

namespace CalorieCounterProject.Data.Migrations
{
    public partial class intaketypeeklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IntakeType",
                table: "DailyFoodIntakes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntakeType",
                table: "DailyFoodIntakes");
        }
    }
}
