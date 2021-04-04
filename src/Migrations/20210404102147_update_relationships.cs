using Microsoft.EntityFrameworkCore.Migrations;

namespace src.Migrations
{
    public partial class update_relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Movies_MovieId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieListItem_MovieLists_parentListId",
                table: "MovieListItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieListItem_Movies_itemId",
                table: "MovieListItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieLists_Users_ownerId",
                table: "MovieLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Movies_isPartOfId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Movies_MovieId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MovieId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_MovieListItem_parentListId",
                table: "MovieListItem");

            migrationBuilder.DropIndex(
                name: "IX_Events_MovieId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "isPartOfId",
                table: "Movies",
                newName: "parentMovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_isPartOfId",
                table: "Movies",
                newName: "IX_Movies_parentMovieId");

            migrationBuilder.RenameColumn(
                name: "itemId",
                table: "MovieListItem",
                newName: "MovieListId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieListItem_itemId",
                table: "MovieListItem",
                newName: "IX_MovieListItem_MovieListId");

            migrationBuilder.AddColumn<int>(
                name: "reviewAspect",
                table: "Ratings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isPartOf",
                table: "Movies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ownerId",
                table: "MovieLists",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "parentListId",
                table: "MovieListItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "movieId",
                table: "MovieListItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "about",
                table: "Comments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EventMovie",
                columns: table => new
                {
                    eventsId = table.Column<int>(type: "INTEGER", nullable: false),
                    moviesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventMovie", x => new { x.eventsId, x.moviesId });
                    table.ForeignKey(
                        name: "FK_EventMovie_Events_eventsId",
                        column: x => x.eventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventMovie_Movies_moviesId",
                        column: x => x.moviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieProduct",
                columns: table => new
                {
                    moviesId = table.Column<int>(type: "INTEGER", nullable: false),
                    productsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieProduct", x => new { x.moviesId, x.productsId });
                    table.ForeignKey(
                        name: "FK_MovieProduct_Movies_moviesId",
                        column: x => x.moviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieProduct_Products_productsId",
                        column: x => x.productsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieListItem_movieId",
                table: "MovieListItem",
                column: "movieId");

            migrationBuilder.CreateIndex(
                name: "IX_EventMovie_moviesId",
                table: "EventMovie",
                column: "moviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieProduct_productsId",
                table: "MovieProduct",
                column: "productsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieListItem_MovieLists_MovieListId",
                table: "MovieListItem",
                column: "MovieListId",
                principalTable: "MovieLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieListItem_Movies_movieId",
                table: "MovieListItem",
                column: "movieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieLists_Users_ownerId",
                table: "MovieLists",
                column: "ownerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Movies_parentMovieId",
                table: "Movies",
                column: "parentMovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieListItem_MovieLists_MovieListId",
                table: "MovieListItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieListItem_Movies_movieId",
                table: "MovieListItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieLists_Users_ownerId",
                table: "MovieLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Movies_parentMovieId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "EventMovie");

            migrationBuilder.DropTable(
                name: "MovieProduct");

            migrationBuilder.DropIndex(
                name: "IX_MovieListItem_movieId",
                table: "MovieListItem");

            migrationBuilder.DropColumn(
                name: "reviewAspect",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "isPartOf",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "movieId",
                table: "MovieListItem");

            migrationBuilder.DropColumn(
                name: "about",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "parentMovieId",
                table: "Movies",
                newName: "isPartOfId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_parentMovieId",
                table: "Movies",
                newName: "IX_Movies_isPartOfId");

            migrationBuilder.RenameColumn(
                name: "MovieListId",
                table: "MovieListItem",
                newName: "itemId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieListItem_MovieListId",
                table: "MovieListItem",
                newName: "IX_MovieListItem_itemId");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ownerId",
                table: "MovieLists",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "parentListId",
                table: "MovieListItem",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Events",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MovieId",
                table: "Products",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieListItem_parentListId",
                table: "MovieListItem",
                column: "parentListId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_MovieId",
                table: "Events",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Movies_MovieId",
                table: "Events",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieListItem_MovieLists_parentListId",
                table: "MovieListItem",
                column: "parentListId",
                principalTable: "MovieLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieListItem_Movies_itemId",
                table: "MovieListItem",
                column: "itemId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieLists_Users_ownerId",
                table: "MovieLists",
                column: "ownerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Movies_isPartOfId",
                table: "Movies",
                column: "isPartOfId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Movies_MovieId",
                table: "Products",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
