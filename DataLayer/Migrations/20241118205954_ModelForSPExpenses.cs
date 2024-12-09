using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ModelForSPExpenses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseBetweenDatesSPs",
                columns: table => new
                {
                    ExpenseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseBetweenDatesSPs", x => x.ExpenseId);
                });

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0d1e1c4-df87-4f4a-a4e4-d4747dbc1b44"),
                columns: new[] { "Email", "Username" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e1a1e1c4-bf89-4b8f-b9e1-c4747dbd2a64"),
                columns: new[] { "Email", "Username" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseBetweenDatesSPs");

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("1cf56382-11a2-4e5d-a50e-a94988c8328a"),
                column: "BalanceCreatedDate",
                value: new DateTime(2024, 11, 5, 15, 20, 48, 820, DateTimeKind.Local).AddTicks(9758));

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("eb38c548-1a2a-46b3-864b-461b3083b16b"),
                column: "BalanceCreatedDate",
                value: new DateTime(2024, 11, 5, 15, 20, 48, 820, DateTimeKind.Local).AddTicks(9771));

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("f4bbe33c-ae5d-4132-b1dd-251be13f994e"),
                column: "BalanceCreatedDate",
                value: new DateTime(2024, 11, 5, 15, 20, 48, 820, DateTimeKind.Local).AddTicks(9773));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0d1e1c4-df87-4f4a-a4e4-d4747dbc1b44"),
                columns: new[] { "Email", "Username" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e1a1e1c4-bf89-4b8f-b9e1-c4747dbd2a64"),
                columns: new[] { "Email", "Username" },
                values: new object[] { "", "" });
        }
    }
}
