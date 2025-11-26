using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Menu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuModuleAudits_MenuModules_MenuModuleId1",
                table: "MenuModuleAudits");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId1",
                table: "MenuModuleAudits",
                newName: "MenuModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuModuleAudits_MenuModuleId1",
                table: "MenuModuleAudits",
                newName: "IX_MenuModuleAudits_MenuModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuModuleAudits_MenuModules_MenuModuleId",
                table: "MenuModuleAudits",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuModuleAudits_MenuModules_MenuModuleId",
                table: "MenuModuleAudits");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "MenuModuleAudits",
                newName: "MenuModuleId1");

            migrationBuilder.RenameIndex(
                name: "IX_MenuModuleAudits_MenuModuleId",
                table: "MenuModuleAudits",
                newName: "IX_MenuModuleAudits_MenuModuleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuModuleAudits_MenuModules_MenuModuleId1",
                table: "MenuModuleAudits",
                column: "MenuModuleId1",
                principalTable: "MenuModules",
                principalColumn: "Id");
        }
    }
}
