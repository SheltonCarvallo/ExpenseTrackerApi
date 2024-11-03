using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Renameddatesattributesallentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4d1367ad-afcb-458f-a528-92a2d9f9a64c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("72ef6fbc-5c4e-4f35-8961-cd7c3fdc02e5"));

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Users",
                newName: "UserUpdateDate");

            migrationBuilder.RenameColumn(
                name: "RegisterDate",
                table: "Users",
                newName: "UserRegisterDate");

            migrationBuilder.RenameColumn(
                name: "RegisterDate",
                table: "PaymentMethods",
                newName: "PaymentMethodRegisterDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "PaymentMethods",
                newName: "PaymentMethodModifiedDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Expenses",
                newName: "ExpenseUpdateDate");

            migrationBuilder.RenameColumn(
                name: "RegisterDate",
                table: "Expenses",
                newName: "ExpenseRegisterDate");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Categories",
                newName: "CategoryDateModified");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Categories",
                newName: "CategoryDateCreated");

            migrationBuilder.RenameColumn(
                name: "RegisterDate",
                table: "Banks",
                newName: "BankRegisterDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Banks",
                newName: "BankModifiedDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Balances",
                newName: "BalanceUpdateDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Balances",
                newName: "BalanceCreatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserUpdateDate",
                table: "Users",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "UserRegisterDate",
                table: "Users",
                newName: "RegisterDate");

            migrationBuilder.RenameColumn(
                name: "PaymentMethodRegisterDate",
                table: "PaymentMethods",
                newName: "RegisterDate");

            migrationBuilder.RenameColumn(
                name: "PaymentMethodModifiedDate",
                table: "PaymentMethods",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ExpenseUpdateDate",
                table: "Expenses",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "ExpenseRegisterDate",
                table: "Expenses",
                newName: "RegisterDate");

            migrationBuilder.RenameColumn(
                name: "CategoryDateModified",
                table: "Categories",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "CategoryDateCreated",
                table: "Categories",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "BankRegisterDate",
                table: "Banks",
                newName: "RegisterDate");

            migrationBuilder.RenameColumn(
                name: "BankModifiedDate",
                table: "Banks",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "BalanceUpdateDate",
                table: "Balances",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "BalanceCreatedDate",
                table: "Balances",
                newName: "CreatedDate");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "RegisterDate", "StatusId", "UpdateDate", "Username" },
                values: new object[,]
                {
                    { new Guid("4d1367ad-afcb-458f-a528-92a2d9f9a64c"), "", "Shelton", "Carvallo", new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "" },
                    { new Guid("72ef6fbc-5c4e-4f35-8961-cd7c3fdc02e5"), "", "Ivonne", "Rubira", new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "" }
                });
        }
    }
}
