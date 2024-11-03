using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Statusrelationshipwithotherentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_StatusId",
                table: "Users",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_StatusId",
                table: "PaymentMethods",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_StatusId",
                table: "Categories",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_StatusId",
                table: "Banks",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_StatusId",
                table: "Balances",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_Statuses_StatusId",
                table: "Balances",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Banks_Statuses_StatusId",
                table: "Banks",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Statuses_StatusId",
                table: "Categories",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethods_Statuses_StatusId",
                table: "PaymentMethods",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Statuses_StatusId",
                table: "Users",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balances_Statuses_StatusId",
                table: "Balances");

            migrationBuilder.DropForeignKey(
                name: "FK_Banks_Statuses_StatusId",
                table: "Banks");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Statuses_StatusId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_Statuses_StatusId",
                table: "PaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Statuses_StatusId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StatusId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethods_StatusId",
                table: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_Categories_StatusId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Banks_StatusId",
                table: "Banks");

            migrationBuilder.DropIndex(
                name: "IX_Balances_StatusId",
                table: "Balances");
        }
    }
}
