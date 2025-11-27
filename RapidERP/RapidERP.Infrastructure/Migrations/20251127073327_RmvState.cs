using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RmvState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_States_Tenants_TenantId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_TenantId",
                table: "States");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Tenants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_StateId",
                table: "Tenants",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_States_StateId",
                table: "Tenants",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_States_StateId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_StateId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Tenants");

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
        }
    }
}
