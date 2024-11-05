using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Addedidentificationnumberlength10digitstouser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("1cf56382-11a2-4e5d-a50e-a94988c8328a"),
                column: "BalanceCreatedDate",
                value: new DateTime(2024, 11, 5, 15, 17, 5, 48, DateTimeKind.Local).AddTicks(5468));

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("eb38c548-1a2a-46b3-864b-461b3083b16b"),
                column: "BalanceCreatedDate",
                value: new DateTime(2024, 11, 5, 15, 17, 5, 48, DateTimeKind.Local).AddTicks(5482));

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("f4bbe33c-ae5d-4132-b1dd-251be13f994e"),
                column: "BalanceCreatedDate",
                value: new DateTime(2024, 11, 5, 15, 17, 5, 48, DateTimeKind.Local).AddTicks(5485));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("1cf56382-11a2-4e5d-a50e-a94988c8328a"),
                column: "BalanceCreatedDate",
                value: new DateTime(2024, 11, 5, 15, 10, 53, 903, DateTimeKind.Local).AddTicks(6186));

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("eb38c548-1a2a-46b3-864b-461b3083b16b"),
                column: "BalanceCreatedDate",
                value: new DateTime(2024, 11, 5, 15, 10, 53, 903, DateTimeKind.Local).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("f4bbe33c-ae5d-4132-b1dd-251be13f994e"),
                column: "BalanceCreatedDate",
                value: new DateTime(2024, 11, 5, 15, 10, 53, 903, DateTimeKind.Local).AddTicks(6203));
        }
    }
}
