using Microsoft.EntityFrameworkCore.Migrations;

namespace src.Migrations
{
    public partial class add_correct_answer_at_questions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "correctAnswer",
                table: "Questions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "correctAnswer",
                table: "Questions");
        }
    }
}
