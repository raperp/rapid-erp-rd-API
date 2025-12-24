using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CalTenantIdNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_Tenants_TenantId",
                table: "Calendars");

            migrationBuilder.DropIndex(
                name: "IX_Calendars_TenantId",
                table: "Calendars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Calendars_TenantId",
                table: "Calendars",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_Tenants_TenantId",
                table: "Calendars",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");
        }
    }
}
