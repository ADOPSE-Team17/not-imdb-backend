using Microsoft.EntityFrameworkCore.Migrations;

namespace src.Migrations
{
    public partial class make_email_unique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Accounts_email",
                table: "Accounts",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accounts_email",
                table: "Accounts");
        }
    }
}
