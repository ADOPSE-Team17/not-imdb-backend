using Microsoft.EntityFrameworkCore.Migrations;

namespace src.Migrations
{
    public partial class avgRatingToMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "capacity",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "rating",
                table: "Movies",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "capacity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "Movies");
        }
    }
}
