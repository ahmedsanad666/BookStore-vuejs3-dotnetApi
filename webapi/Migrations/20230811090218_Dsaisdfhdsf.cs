using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class Dsaisdfhdsf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { "5f022af1-dd2d-45b7-b85b-5a76a802e2da", null, "User", "USER" },
                    { "61060c9e-6640-4ae1-b28a-8c77ac25530b", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f022af1-dd2d-45b7-b85b-5a76a802e2da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61060c9e-6640-4ae1-b28a-8c77ac25530b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "269a5a2c-f075-4e31-b7df-0a87d68c9b85", null, "User", "USER" },
                    { "9c27065e-afbb-4f4d-be55-92ede5d98353", null, "Admin", "ADMIN" }
                });
        }
    }
}
