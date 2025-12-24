using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TenantFKRmv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Countries_CountryId",
                table: "Tenants");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_States_StateId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_CountryId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_StateId",
                table: "Tenants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tenants_CountryId",
                table: "Tenants",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_StateId",
                table: "Tenants",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Countries_CountryId",
                table: "Tenants",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_States_StateId",
                table: "Tenants",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");
        }
    }
}
