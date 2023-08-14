using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class updatrta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f022af1-dd2d-45b7-b85b-5a76a802e2da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61060c9e-6640-4ae1-b28a-8c77ac25530b");

            migrationBuilder.AddColumn<string>(
                name: "BookTitle",
                table: "BookGrants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "BookGrants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "483ec75a-fb6d-4ea8-8c89-ec0a03bbeb06", null, "Admin", "ADMIN" },
                    { "5d7540a4-4a52-443c-98f0-1e84c203f7b2", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "483ec75a-fb6d-4ea8-8c89-ec0a03bbeb06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d7540a4-4a52-443c-98f0-1e84c203f7b2");

            migrationBuilder.DropColumn(
                name: "BookTitle",
                table: "BookGrants");

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "BookGrants");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f022af1-dd2d-45b7-b85b-5a76a802e2da", null, "User", "USER" },
                    { "61060c9e-6640-4ae1-b28a-8c77ac25530b", null, "Admin", "ADMIN" }
                });
        }
    }
}
