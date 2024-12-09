using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ModelForSPExpenses2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentMethod",
                table: "ExpenseBetweenDatesSPs",
                newName: "PaymentMethodName");

            migrationBuilder.RenameColumn(
                name: "ExpenseDate",
                table: "ExpenseBetweenDatesSPs",
                newName: "ExpenseRegisterDate");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "ExpenseBetweenDatesSPs",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "ExpenseId",
                table: "ExpenseBetweenDatesSPs",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("1cf56382-11a2-4e5d-a50e-a94988c8328a"),
                column: "BalanceCreatedDate",
                value: new DateTime(2024, 11, 18, 16, 18, 39, 919, DateTimeKind.Local).AddTicks(282));

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("eb38c548-1a2a-46b3-864b-461b3083b16b"),
                column: "BalanceCreatedDate",
                value: new DateTime(2024, 11, 18, 16, 18, 39, 919, DateTimeKind.Local).AddTicks(299));

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("f4bbe33c-ae5d-4132-b1dd-251be13f994e"),
                column: "BalanceCreatedDate",
                value: new DateTime(2024, 11, 18, 16, 18, 39, 919, DateTimeKind.Local).AddTicks(301));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentMethodName",
                table: "ExpenseBetweenDatesSPs",
                newName: "PaymentMethod");

            migrationBuilder.RenameColumn(
                name: "ExpenseRegisterDate",
                table: "ExpenseBetweenDatesSPs",
                newName: "ExpenseDate");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "ExpenseBetweenDatesSPs",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ExpenseBetweenDatesSPs",
                newName: "ExpenseId");

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("1cf56382-11a2-4e5d-a50e-a94988c8328a"),
                column: "BalanceCreatedDate",
                value: new DateTime(2024, 11, 18, 15, 59, 54, 409, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("eb38c548-1a2a-46b3-864b-461b3083b16b"),
                column: "BalanceCreatedDate",
                value: new DateTime(2024, 11, 18, 15, 59, 54, 409, DateTimeKind.Local).AddTicks(6977));

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("f4bbe33c-ae5d-4132-b1dd-251be13f994e"),
                column: "BalanceCreatedDate",
                value: new DateTime(2024, 11, 18, 15, 59, 54, 409, DateTimeKind.Local).AddTicks(6979));
        }
    }
}
