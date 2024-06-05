using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieReview.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20091cd0-5c9b-4155-a33a-d33b37edaab6", null, "GuestUser", "GuestUser" },
                    { "29e73a7f-2c5e-4cbd-b53e-19a0de04cddc", null, "RegisteredUser", "RegisteredUser" },
                    { "90366840-8a4c-41ed-acda-0db68ae6c818", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20091cd0-5c9b-4155-a33a-d33b37edaab6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29e73a7f-2c5e-4cbd-b53e-19a0de04cddc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90366840-8a4c-41ed-acda-0db68ae6c818");
        }
    }
}
