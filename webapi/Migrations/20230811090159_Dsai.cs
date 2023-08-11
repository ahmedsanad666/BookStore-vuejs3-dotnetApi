using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class Dsai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ebaa7a1-4e44-4572-a9bc-7aca59cf4832");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f64b4f7-c708-4a68-8a86-0e5c8b28c44b");

            migrationBuilder.CreateTable(
                name: "BookGrants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RecordedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidTillDate = table.Column<int>(type: "int", nullable: false),
                    GrantDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGrants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookGrants_AspNetUsers_ApiUserId",
                        column: x => x.ApiUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookCategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    NoReads = table.Column<bool>(type: "bit", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false),
                    ApiUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImprintId = table.Column<int>(type: "int", nullable: false),
                    PDFUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaysToRead = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_AspNetUsers_ApiUserId",
                        column: x => x.ApiUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "knowledgeHubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_knowledgeHubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false),
                    ChoicesString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<int>(type: "int", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserQuestionsAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    ApiUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuestionsAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserQuestionsAnswers_AspNetUsers_ApiUserId",
                        column: x => x.ApiUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserQuestionsAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "269a5a2c-f075-4e31-b7df-0a87d68c9b85", null, "User", "USER" },
                    { "9c27065e-afbb-4f4d-be55-92ede5d98353", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookGrants_ApiUserId",
                table: "BookGrants",
                column: "ApiUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ApiUserId",
                table: "Books",
                column: "ApiUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_BookId",
                table: "Questions",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestionsAnswers_ApiUserId",
                table: "UserQuestionsAnswers",
                column: "ApiUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestionsAnswers_QuestionId",
                table: "UserQuestionsAnswers",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookGrants");

            migrationBuilder.DropTable(
                name: "knowledgeHubs");

            migrationBuilder.DropTable(
                name: "UserQuestionsAnswers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "269a5a2c-f075-4e31-b7df-0a87d68c9b85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c27065e-afbb-4f4d-be55-92ede5d98353");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ebaa7a1-4e44-4572-a9bc-7aca59cf4832", null, "Admin", "ADMIN" },
                    { "4f64b4f7-c708-4a68-8a86-0e5c8b28c44b", null, "User", "USER" }
                });
        }
    }
}
