using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MessageModd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageModules_TextModules_TextModuleId",
                table: "MessageModules");

            migrationBuilder.AlterColumn<int>(
                name: "TextModuleId",
                table: "MessageModules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TextModuleId",
                table: "MessageModuleAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageModules_TextModules_TextModuleId",
                table: "MessageModules",
                column: "TextModuleId",
                principalTable: "TextModules",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageModules_TextModules_TextModuleId",
                table: "MessageModules");

            migrationBuilder.DropColumn(
                name: "TextModuleId",
                table: "MessageModuleAudits");

            migrationBuilder.AlterColumn<int>(
                name: "TextModuleId",
                table: "MessageModules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageModules_TextModules_TextModuleId",
                table: "MessageModules",
                column: "TextModuleId",
                principalTable: "TextModules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
