using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateCurrencyIdInAuditTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "CurrencyAudits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyAudits_CurrencyId",
                table: "CurrencyAudits",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyAudits_Currencies_CurrencyId",
                table: "CurrencyAudits",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyAudits_Currencies_CurrencyId",
                table: "CurrencyAudits");

            migrationBuilder.DropIndex(
                name: "IX_CurrencyAudits_CurrencyId",
                table: "CurrencyAudits");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "CurrencyAudits");
        }
    }
}
