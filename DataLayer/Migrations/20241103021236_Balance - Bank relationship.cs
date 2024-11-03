using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class BalanceBankrelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Balances_BankId",
                table: "Balances",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_Banks_BankId",
                table: "Balances",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balances_Banks_BankId",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_BankId",
                table: "Balances");
        }
    }
}
