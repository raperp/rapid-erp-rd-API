using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RmvTnnt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Tenants_TenantId1",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_TenantId1",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "TenantId1",
                table: "Tenants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Tenants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId1",
                table: "Tenants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_TenantId1",
                table: "Tenants",
                column: "TenantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Tenants_TenantId1",
                table: "Tenants",
                column: "TenantId1",
                principalTable: "Tenants",
                principalColumn: "Id");
        }
    }
}
