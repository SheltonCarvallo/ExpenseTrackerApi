using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Seedusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "RegisterDate", "StatusId", "UpdateDate", "Username" },
                values: new object[,]
                {
                    { new Guid("4d1367ad-afcb-458f-a528-92a2d9f9a64c"), "", "Shelton", "Carvallo", new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "" },
                    { new Guid("72ef6fbc-5c4e-4f35-8961-cd7c3fdc02e5"), "", "Ivonne", "Rubira", new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4d1367ad-afcb-458f-a528-92a2d9f9a64c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("72ef6fbc-5c4e-4f35-8961-cd7c3fdc02e5"));
        }
    }
}
