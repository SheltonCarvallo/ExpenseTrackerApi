using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class UserBalancerelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Balances_UserId",
                table: "Balances",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_Users_UserId",
                table: "Balances",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balances_Users_UserId",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_UserId",
                table: "Balances");
        }
    }
}
