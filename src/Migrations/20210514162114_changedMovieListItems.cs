using Microsoft.EntityFrameworkCore.Migrations;

namespace src.Migrations
{
    public partial class changedMovieListItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieListItem");

            migrationBuilder.AddColumn<int>(
                name: "MovieListId",
                table: "Movies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieListId",
                table: "Movies",
                column: "MovieListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieLists_MovieListId",
                table: "Movies",
                column: "MovieListId",
                principalTable: "MovieLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieLists_MovieListId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_MovieListId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieListId",
                table: "Movies");

            migrationBuilder.CreateTable(
                name: "MovieListItem",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieListId = table.Column<int>(type: "INTEGER", nullable: true),
                    movieId = table.Column<int>(type: "INTEGER", nullable: false),
                    order = table.Column<int>(type: "INTEGER", nullable: false),
                    parentListId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieListItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_MovieListItem_MovieLists_MovieListId",
                        column: x => x.MovieListId,
                        principalTable: "MovieLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieListItem_Movies_movieId",
                        column: x => x.movieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieListItem_movieId",
                table: "MovieListItem",
                column: "movieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieListItem_MovieListId",
                table: "MovieListItem",
                column: "MovieListId");
        }
    }
}
