using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalorieCounterProject.Data.Migrations
{
    public partial class activitiesguncellendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "METValue",
                table: "Activities",
                newName: "MetValue");

            migrationBuilder.RenameColumn(
                name: "ActivityName",
                table: "Activities",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MetValue",
                table: "Activities",
                newName: "METValue");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Activities",
                newName: "ActivityName");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Activities",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Activities",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDate",
                table: "Activities",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
