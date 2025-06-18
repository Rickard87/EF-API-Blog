using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class newDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35b0b0cf-44be-4177-8435-6980a8e4f699");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d177fd75-81e9-431b-856e-dd164d2bed88");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c1e76600-997f-47cc-8c62-ffefceaeb5eb", null, "User", "USER" },
                    { "f0be4739-d0dc-4f3b-b2b4-f29cb0ffaabe", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1e76600-997f-47cc-8c62-ffefceaeb5eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0be4739-d0dc-4f3b-b2b4-f29cb0ffaabe");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35b0b0cf-44be-4177-8435-6980a8e4f699", null, "Admin", "ADMIN" },
                    { "d177fd75-81e9-431b-856e-dd164d2bed88", null, "User", "USER" }
                });
        }
    }
}
