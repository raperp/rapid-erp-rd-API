using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSubModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submodules_Menus_MenuId",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "SubmoduleId",
                table: "Menus");

            migrationBuilder.AddForeignKey(
                name: "FK_Submodules_Menus_MenuId",
                table: "Submodules",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submodules_Menus_MenuId",
                table: "Submodules");

            migrationBuilder.AddColumn<int>(
                name: "SubmoduleId",
                table: "Menus",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Submodules_Menus_MenuId",
                table: "Submodules",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");
        }
    }
}
