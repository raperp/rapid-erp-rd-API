using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateMenuIdInAuditTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "MenuAudits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MenuAudits_MenuId",
                table: "MenuAudits",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuAudits_Menus_MenuId",
                table: "MenuAudits",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuAudits_Menus_MenuId",
                table: "MenuAudits");

            migrationBuilder.DropIndex(
                name: "IX_MenuAudits_MenuId",
                table: "MenuAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "MenuAudits");
        }
    }
}
