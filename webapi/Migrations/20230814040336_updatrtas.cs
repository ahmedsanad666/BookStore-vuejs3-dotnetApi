using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class updatrtas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "483ec75a-fb6d-4ea8-8c89-ec0a03bbeb06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d7540a4-4a52-443c-98f0-1e84c203f7b2");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BookGrants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "83217412-a3b6-41e7-9d98-158f4bd5c6e5", null, "User", "USER" },
                    { "99e39f6b-0545-4930-b83c-65f8e776ca04", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83217412-a3b6-41e7-9d98-158f4bd5c6e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99e39f6b-0545-4930-b83c-65f8e776ca04");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookGrants");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "483ec75a-fb6d-4ea8-8c89-ec0a03bbeb06", null, "Admin", "ADMIN" },
                    { "5d7540a4-4a52-443c-98f0-1e84c203f7b2", null, "User", "USER" }
                });
        }
    }
}
