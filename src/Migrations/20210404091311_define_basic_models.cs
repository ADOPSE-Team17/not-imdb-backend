using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace src.Migrations
{
    public partial class define_basic_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropTable(
                name: "LocalUserAccount");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "personId",
                table: "Users",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "isAdmin",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDisabled",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    additionalType = table.Column<string>(type: "TEXT", nullable: true),
                    password = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ownerId = table.Column<int>(type: "INTEGER", nullable: true),
                    itemListOrder = table.Column<string>(type: "TEXT", nullable: true),
                    numberOfItems = table.Column<int>(type: "INTEGER", nullable: false),
                    alternateName = table.Column<string>(type: "TEXT", nullable: true),
                    additionalType = table.Column<string>(type: "TEXT", nullable: true),
                    headline = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieLists_Users_ownerId",
                        column: x => x.ownerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    isPartOfId = table.Column<int>(type: "INTEGER", nullable: true),
                    additionalType = table.Column<string>(type: "TEXT", nullable: true),
                    headline = table.Column<string>(type: "TEXT", nullable: true),
                    alternativeHeadline = table.Column<string>(type: "TEXT", nullable: true),
                    trailerUrl = table.Column<string>(type: "TEXT", nullable: true),
                    about = table.Column<string>(type: "TEXT", nullable: true),
                    abstractText = table.Column<string>(type: "TEXT", nullable: true),
                    musicBy = table.Column<string>(type: "TEXT", nullable: true),
                    producer = table.Column<string>(type: "TEXT", nullable: true),
                    duration = table.Column<double>(type: "REAL", nullable: false),
                    datePublished = table.Column<DateTime>(type: "Date", nullable: false),
                    locationCreated = table.Column<string>(type: "TEXT", nullable: true),
                    contentRating = table.Column<string>(type: "TEXT", nullable: true),
                    copyrightHolder = table.Column<string>(type: "TEXT", nullable: true),
                    copyrightYear = table.Column<string>(type: "TEXT", nullable: true),
                    creator = table.Column<string>(type: "TEXT", nullable: true),
                    inLanguage = table.Column<string>(type: "TEXT", nullable: true),
                    isFamilyFriendly = table.Column<bool>(type: "INTEGER", nullable: false),
                    dateCreated = table.Column<DateTime>(type: "Date", nullable: false),
                    dateModified = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Movies_isPartOfId",
                        column: x => x.isPartOfId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    alternateName = table.Column<string>(type: "TEXT", nullable: true),
                    familyName = table.Column<string>(type: "TEXT", nullable: true),
                    givenName = table.Column<string>(type: "TEXT", nullable: true),
                    additionalName = table.Column<string>(type: "TEXT", nullable: true),
                    address = table.Column<string>(type: "TEXT", nullable: true),
                    birthDate = table.Column<DateTime>(type: "Date", nullable: false),
                    gender = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    image = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    additionalType = table.Column<string>(type: "TEXT", nullable: true),
                    alternateName = table.Column<string>(type: "TEXT", nullable: true),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    optionSet = table.Column<string>(type: "TEXT", nullable: true),
                    dateCreated = table.Column<DateTime>(type: "Date", nullable: false),
                    dateModified = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    creatorId = table.Column<int>(type: "INTEGER", nullable: true),
                    commentText = table.Column<string>(type: "TEXT", nullable: true),
                    dateCreated = table.Column<DateTime>(type: "Date", nullable: false),
                    dateModified = table.Column<DateTime>(type: "Date", nullable: false),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_creatorId",
                        column: x => x.creatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    additionalType = table.Column<string>(type: "TEXT", nullable: true),
                    alternateName = table.Column<string>(type: "TEXT", nullable: true),
                    headline = table.Column<string>(type: "TEXT", nullable: true),
                    alternativeHeadline = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    image = table.Column<string>(type: "TEXT", nullable: true),
                    url = table.Column<string>(type: "TEXT", nullable: true),
                    organizer = table.Column<string>(type: "TEXT", nullable: true),
                    doorTime = table.Column<DateTime>(type: "Date", nullable: false),
                    startDate = table.Column<DateTime>(type: "Date", nullable: false),
                    endDate = table.Column<DateTime>(type: "Date", nullable: false),
                    duration = table.Column<double>(type: "REAL", nullable: false),
                    eventAttendanceMode = table.Column<string>(type: "TEXT", nullable: true),
                    eventStatus = table.Column<string>(type: "TEXT", nullable: true),
                    inLanguage = table.Column<string>(type: "TEXT", nullable: true),
                    isAccessibleForFree = table.Column<bool>(type: "INTEGER", nullable: false),
                    location = table.Column<string>(type: "TEXT", nullable: true),
                    maximumAttendeeCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieListItem",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    parentListId = table.Column<int>(type: "INTEGER", nullable: true),
                    itemId = table.Column<int>(type: "INTEGER", nullable: true),
                    order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieListItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_MovieListItem_MovieLists_parentListId",
                        column: x => x.parentListId,
                        principalTable: "MovieLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieListItem_Movies_itemId",
                        column: x => x.itemId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    headline = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    image = table.Column<string>(type: "TEXT", nullable: true),
                    url = table.Column<string>(type: "TEXT", nullable: true),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    authorId = table.Column<int>(type: "INTEGER", nullable: true),
                    ratingValue = table.Column<int>(type: "INTEGER", nullable: false),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_authorId",
                        column: x => x.authorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    personId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actors_People_personId",
                        column: x => x.personId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    personId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Directors_People_personId",
                        column: x => x.personId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VoteActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    agentId = table.Column<int>(type: "INTEGER", nullable: true),
                    answer = table.Column<int>(type: "INTEGER", nullable: false),
                    dateCreated = table.Column<DateTime>(type: "Date", nullable: false),
                    dateModified = table.Column<DateTime>(type: "Date", nullable: false),
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoteActions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VoteActions_Users_agentId",
                        column: x => x.agentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_personId",
                table: "Users",
                column: "personId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Actors_personId",
                table: "Actors",
                column: "personId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_creatorId",
                table: "Comments",
                column: "creatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MovieId",
                table: "Comments",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Directors_personId",
                table: "Directors",
                column: "personId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_MovieId",
                table: "Events",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieListItem_itemId",
                table: "MovieListItem",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieListItem_parentListId",
                table: "MovieListItem",
                column: "parentListId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLists_ownerId",
                table: "MovieLists",
                column: "ownerId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_isPartOfId",
                table: "Movies",
                column: "isPartOfId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MovieId",
                table: "Products",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_authorId",
                table: "Ratings",
                column: "authorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MovieId",
                table: "Ratings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteActions_agentId",
                table: "VoteActions",
                column: "agentId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteActions_QuestionId",
                table: "VoteActions",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_People_personId",
                table: "Users",
                column: "personId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_People_personId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "MovieListItem");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "VoteActions");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "MovieLists");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Users_personId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isDisabled",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "personId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "isAdmin",
                table: "Users",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "LocalUserAccount",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUserAccount", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    Userid = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    localAccountid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserAccount_LocalUserAccount_localAccountid",
                        column: x => x.localAccountid,
                        principalTable: "LocalUserAccount",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAccount_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_localAccountid",
                table: "UserAccount",
                column: "localAccountid");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_Userid",
                table: "UserAccount",
                column: "Userid");
        }
    }
}
