using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddedexpensestableintheDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Banks_BankId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Categories_CategoryId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_PaymentMethods_PaymentMethodId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Statuses_StatusId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Users_UserId",
                table: "Expense");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expense",
                table: "Expense");

            migrationBuilder.RenameTable(
                name: "Expense",
                newName: "Expenses");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_UserId",
                table: "Expenses",
                newName: "IX_Expenses_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_StatusId",
                table: "Expenses",
                newName: "IX_Expenses_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_PaymentMethodId",
                table: "Expenses",
                newName: "IX_Expenses_PaymentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_CategoryId",
                table: "Expenses",
                newName: "IX_Expenses_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_BankId",
                table: "Expenses",
                newName: "IX_Expenses_BankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Banks_BankId",
                table: "Expenses",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Categories_CategoryId",
                table: "Expenses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_PaymentMethods_PaymentMethodId",
                table: "Expenses",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Statuses_StatusId",
                table: "Expenses",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Banks_BankId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Categories_CategoryId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_PaymentMethods_PaymentMethodId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Statuses_StatusId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "Expense");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_UserId",
                table: "Expense",
                newName: "IX_Expense_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_StatusId",
                table: "Expense",
                newName: "IX_Expense_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_PaymentMethodId",
                table: "Expense",
                newName: "IX_Expense_PaymentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expense",
                newName: "IX_Expense_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_BankId",
                table: "Expense",
                newName: "IX_Expense_BankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expense",
                table: "Expense",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Banks_BankId",
                table: "Expense",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Categories_CategoryId",
                table: "Expense",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_PaymentMethods_PaymentMethodId",
                table: "Expense",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Statuses_StatusId",
                table: "Expense",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Users_UserId",
                table: "Expense",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
