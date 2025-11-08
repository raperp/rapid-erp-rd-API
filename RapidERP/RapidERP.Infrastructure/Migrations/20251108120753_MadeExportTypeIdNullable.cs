using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MadeExportTypeIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportTypeAudits_ExportTypes_ExportTypeId",
                table: "ExportTypeAudits");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageAudits_ExportTypes_ExportTypeId",
                table: "LanguageAudits");

            migrationBuilder.AlterColumn<int>(
                name: "ExportTypeId",
                table: "LanguageAudits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExportTypeId",
                table: "ExportTypeAudits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportTypeAudits_ExportTypes_ExportTypeId",
                table: "ExportTypeAudits",
                column: "ExportTypeId",
                principalTable: "ExportTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageAudits_ExportTypes_ExportTypeId",
                table: "LanguageAudits",
                column: "ExportTypeId",
                principalTable: "ExportTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportTypeAudits_ExportTypes_ExportTypeId",
                table: "ExportTypeAudits");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageAudits_ExportTypes_ExportTypeId",
                table: "LanguageAudits");

            migrationBuilder.AlterColumn<int>(
                name: "ExportTypeId",
                table: "LanguageAudits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExportTypeId",
                table: "ExportTypeAudits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExportTypeAudits_ExportTypes_ExportTypeId",
                table: "ExportTypeAudits",
                column: "ExportTypeId",
                principalTable: "ExportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageAudits_ExportTypes_ExportTypeId",
                table: "LanguageAudits",
                column: "ExportTypeId",
                principalTable: "ExportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
