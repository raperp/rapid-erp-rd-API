using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSubModuke : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Submodules_SubmoduleId1",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_SubmoduleId1",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "SubmoduleId1",
                table: "Menus");

            migrationBuilder.AlterColumn<int>(
                name: "SubmoduleId",
                table: "Menus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_Menus_SubmoduleId1",
                table: "Menus",
                column: "SubmoduleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Submodules_SubmoduleId1",
                table: "Menus",
                column: "SubmoduleId1",
                principalTable: "Submodules",
                principalColumn: "Id");
        }
    }
}
