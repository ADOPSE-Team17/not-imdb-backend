using Microsoft.EntityFrameworkCore.Migrations;

namespace src.Migrations
{
    public partial class update_questions_and_votes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoteActions_Users_agentId",
                table: "VoteActions");

            migrationBuilder.DropIndex(
                name: "IX_VoteActions_agentId",
                table: "VoteActions");

            migrationBuilder.DropColumn(
                name: "agentId",
                table: "VoteActions");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "VoteActions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VoteActions_userId",
                table: "VoteActions",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoteActions_Users_userId",
                table: "VoteActions",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoteActions_Users_userId",
                table: "VoteActions");

            migrationBuilder.DropIndex(
                name: "IX_VoteActions_userId",
                table: "VoteActions");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "VoteActions");

            migrationBuilder.AddColumn<int>(
                name: "agentId",
                table: "VoteActions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VoteActions_agentId",
                table: "VoteActions",
                column: "agentId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoteActions_Users_agentId",
                table: "VoteActions",
                column: "agentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
