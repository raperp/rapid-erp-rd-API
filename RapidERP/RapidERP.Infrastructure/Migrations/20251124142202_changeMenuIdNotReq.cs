using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeMenuIdNotReq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionTypes_Menus_MenuId",
                table: "ActionTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportTypes_Menus_MenuId",
                table: "ExportTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Menus_MenuId",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_MenuId",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_ExportTypes_MenuId",
                table: "ExportTypes");

            migrationBuilder.DropIndex(
                name: "IX_ActionTypes_MenuId",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "ActionTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Languages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "ExportTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "ActionTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_MenuId",
                table: "Languages",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportTypes_MenuId",
                table: "ExportTypes",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypes_MenuId",
                table: "ActionTypes",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionTypes_Menus_MenuId",
                table: "ActionTypes",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExportTypes_Menus_MenuId",
                table: "ExportTypes",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Menus_MenuId",
                table: "Languages",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
