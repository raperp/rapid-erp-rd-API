using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SolTenantIdNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solutions_Tenants_TenantId",
                table: "Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Solutions_TenantId",
                table: "Solutions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Solutions_TenantId",
                table: "Solutions",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solutions_Tenants_TenantId",
                table: "Solutions",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");
        }
    }
}
