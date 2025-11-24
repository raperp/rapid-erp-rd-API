using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submodules_Menus_MenuId1",
                table: "Submodules");

            migrationBuilder.DropIndex(
                name: "IX_Submodules_MenuId1",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "MenuId1",
                table: "Submodules");

            migrationBuilder.RenameColumn(
                name: "SubModuleId",
                table: "Menus",
                newName: "SubmoduleId");

            migrationBuilder.AlterColumn<int>(
                name: "SubmoduleId",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubmoduleId1",
                table: "Menus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Submodules_MenuId",
                table: "Submodules",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_SubmoduleId1",
                table: "Menus",
                column: "SubmoduleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Submodules_SubmoduleId1",
                table: "Menus",
                column: "SubmoduleId1",
                principalTable: "Submodules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Submodules_Menus_MenuId",
                table: "Submodules",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Submodules_SubmoduleId1",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Submodules_Menus_MenuId",
                table: "Submodules");

            migrationBuilder.DropIndex(
                name: "IX_Submodules_MenuId",
                table: "Submodules");

            migrationBuilder.DropIndex(
                name: "IX_Menus_SubmoduleId1",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "SubmoduleId1",
                table: "Menus");

            migrationBuilder.RenameColumn(
                name: "SubmoduleId",
                table: "Menus",
                newName: "SubModuleId");

            migrationBuilder.AddColumn<int>(
                name: "MenuId1",
                table: "Submodules",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubModuleId",
                table: "Menus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Submodules_MenuId1",
                table: "Submodules",
                column: "MenuId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Submodules_Menus_MenuId1",
                table: "Submodules",
                column: "MenuId1",
                principalTable: "Menus",
                principalColumn: "Id");
        }
    }
}
