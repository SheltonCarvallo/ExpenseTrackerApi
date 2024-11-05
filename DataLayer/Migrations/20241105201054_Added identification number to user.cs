using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Addedidentificationnumbertouser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentificationID",
                table: "Users",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0d1e1c4-df87-4f4a-a4e4-d4747dbc1b44"),
                column: "IdentificationID",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e1a1e1c4-bf89-4b8f-b9e1-c4747dbd2a64"),
                column: "IdentificationID",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentificationID",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("1cf56382-11a2-4e5d-a50e-a94988c8328a"),
                column: "BalanceCreatedDate",
                value: new DateTime(2024, 11, 3, 22, 10, 50, 128, DateTimeKind.Local).AddTicks(8100));

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("eb38c548-1a2a-46b3-864b-461b3083b16b"),
                column: "BalanceCreatedDate",
                value: new DateTime(2024, 11, 3, 22, 10, 50, 128, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: new Guid("f4bbe33c-ae5d-4132-b1dd-251be13f994e"),
                column: "BalanceCreatedDate",
                value: new DateTime(2024, 11, 3, 22, 10, 50, 128, DateTimeKind.Local).AddTicks(8113));
        }
    }
}
