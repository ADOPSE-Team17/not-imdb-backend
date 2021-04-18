using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace src.Migrations
{
    public partial class add_dates_at_question_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "datePublished",
                table: "Questions",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "endDate",
                table: "Questions",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "startDate",
                table: "Questions",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "datePublished",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "endDate",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "startDate",
                table: "Questions");
        }
    }
}
