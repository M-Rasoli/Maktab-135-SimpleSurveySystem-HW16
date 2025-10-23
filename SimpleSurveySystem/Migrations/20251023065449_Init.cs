using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleSurveySystem.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionTitle = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    SurveyId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSurveyrs",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SurveyId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSurveyrs", x => new { x.SurveyId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserSurveyrs_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSurveyrs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionNumber = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    SurveyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votes_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votes_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Votes_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Votes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "Id", "CreatedAt", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "Using Technology" },
                    { 2, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "Favorite book" },
                    { 3, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "Favorite Movie" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "123", "Admin", "mmd" },
                    { 2, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "123", "NormalUSer", "ali" },
                    { 3, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "123", "NormalUSer", "mahdi" },
                    { 4, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "123", "NormalUSer", "porya" },
                    { 5, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "123", "NormalUSer", "hasan" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CreatedAt", "QuestionTitle", "SurveyId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "How many hours do you use your phone per day?", 1 },
                    { 2, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "How many hours do you use your PC per day? ", 1 },
                    { 3, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "What genre is your favorite book usually from?", 2 },
                    { 4, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "Which of the following books have you read?", 2 },
                    { 5, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "How often do you recommend others to read books?", 2 },
                    { 6, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "What genre is your favorite movie usually from?", 3 },
                    { 7, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "How many hours a day do you usually spend watching movies?", 3 },
                    { 8, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), "Which of the following directors' works have you seen?", 3 }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "CreatedAt", "OptionNumber", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 1, 1, "Less than 2 hours." },
                    { 2, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 2, 1, "Less than 4 hours." },
                    { 3, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 3, 1, "More than 4 hours." },
                    { 4, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 4, 1, "More than 8 hours." },
                    { 5, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 1, 2, "Less than 2 hours." },
                    { 6, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 2, 2, "Less than 4 hours." },
                    { 7, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 3, 2, "More than 4 hours." },
                    { 8, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 4, 2, "More than 8 hours." },
                    { 9, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 1, 3, "Mystery" },
                    { 10, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 2, 3, "Historical" },
                    { 11, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 3, 3, "Poetry" },
                    { 12, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 4, 3, "Fantasy" },
                    { 13, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 1, 4, "The Silent Patient by Alex Michaelides" },
                    { 14, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 2, 4, "A Game of Thrones by George R. R. Martin" },
                    { 15, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 3, 4, "Odyssey by Homer" },
                    { 16, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 4, 4, "None" },
                    { 17, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 1, 5, "Never" },
                    { 18, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 2, 5, "Often" },
                    { 19, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 3, 5, "Always" },
                    { 20, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 4, 5, "Fantasy" },
                    { 21, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 1, 6, "Action" },
                    { 22, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 2, 6, "Drama" },
                    { 23, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 3, 6, "Crime fiction" },
                    { 24, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 4, 6, "Comedy " },
                    { 25, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 1, 7, "Less than 2 hours." },
                    { 26, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 2, 7, "Less than 4 hours." },
                    { 27, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 3, 7, "More than 4 hours." },
                    { 28, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 4, 7, "More than 8 hours. " },
                    { 29, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 1, 8, "Christopher Edward Nolan" },
                    { 30, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 2, 8, "Stanley Kubrick" },
                    { 31, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 3, 8, "Martin Charles Scorsese" },
                    { 32, new DateTime(2024, 12, 12, 12, 12, 12, 0, DateTimeKind.Local), 4, 8, "David Andrew Leo Fincher" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyId",
                table: "Questions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSurveyrs_UserId",
                table: "UserSurveyrs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_OptionId",
                table: "Votes",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_QuestionId",
                table: "Votes",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_SurveyId",
                table: "Votes",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_UserId",
                table: "Votes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSurveyrs");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}
