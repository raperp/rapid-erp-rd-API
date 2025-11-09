using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTenantIdInTenantAuditTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "TenantAudits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TenantAudits_TenantId",
                table: "TenantAudits",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantAudits_Tenants_TenantId",
                table: "TenantAudits",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenantAudits_Tenants_TenantId",
                table: "TenantAudits");

            migrationBuilder.DropIndex(
                name: "IX_TenantAudits_TenantId",
                table: "TenantAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "TenantAudits");
        }
    }
}
