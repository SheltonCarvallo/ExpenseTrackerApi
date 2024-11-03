using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Seededuserandbalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "StatusId", "UserRegisterDate", "UserUpdateDate", "Username" },
                values: new object[,]
                {
                    { new Guid("b0d1e1c4-df87-4f4a-a4e4-d4747dbc1b44"), "", "Ivonne", "Rubira", 1, new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "" },
                    { new Guid("e1a1e1c4-bf89-4b8f-b9e1-c4747dbd2a64"), "", "Shelton", "Carvallo", 1, new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "" }
                });

            migrationBuilder.InsertData(
                table: "Balances",
                columns: new[] { "Id", "AccountNumber", "Amount", "BalanceCreatedDate", "BalanceUpdateDate", "BankId", "StatusId", "UserId" },
                values: new object[,]
                {
                    { new Guid("1cf56382-11a2-4e5d-a50e-a94988c8328a"), "BcoBoSXCJ1", 3000m, new DateTime(2024, 11, 3, 16, 33, 9, 517, DateTimeKind.Local).AddTicks(5737), null, 3, 1, new Guid("e1a1e1c4-bf89-4b8f-b9e1-c4747dbd2a64") },
                    { new Guid("eb38c548-1a2a-46b3-864b-461b3083b16b"), "BcoPiIBRE1", 3000m, new DateTime(2024, 11, 3, 16, 33, 9, 517, DateTimeKind.Local).AddTicks(5749), null, 2, 1, new Guid("b0d1e1c4-df87-4f4a-a4e4-d4747dbc1b44") },
                    { new Guid("f4bbe33c-ae5d-4132-b1dd-251be13f994e"), "OwnSXCJ1", 700m, new DateTime(2024, 11, 3, 16, 33, 9, 517, DateTimeKind.Local).AddTicks(5751), null, 4, 1, new Guid("e1a1e1c4-bf89-4b8f-b9e1-c4747dbd2a64") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("1cf56382-11a2-4e5d-a50e-a94988c8328a"));

            migrationBuilder.DeleteData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("eb38c548-1a2a-46b3-864b-461b3083b16b"));

            migrationBuilder.DeleteData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("f4bbe33c-ae5d-4132-b1dd-251be13f994e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0d1e1c4-df87-4f4a-a4e4-d4747dbc1b44"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e1a1e1c4-bf89-4b8f-b9e1-c4747dbd2a64"));
        }
    }
}
