using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class coutn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Tenants_TenantId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Tenants_TenantId1",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_TenantId1",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Countries_TenantId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "TenantId1",
                table: "States");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_CountryId",
                table: "Tenants",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_States_TenantId",
                table: "States",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Tenants_TenantId",
                table: "States",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Countries_CountryId",
                table: "Tenants",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_States_Tenants_TenantId",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Countries_CountryId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_CountryId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_States_TenantId",
                table: "States");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Tenants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId1",
                table: "States",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_States_TenantId1",
                table: "States",
                column: "TenantId1");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_TenantId",
                table: "Countries",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Tenants_TenantId",
                table: "Countries",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Tenants_TenantId1",
                table: "States",
                column: "TenantId1",
                principalTable: "Tenants",
                principalColumn: "Id");
        }
    }
}
