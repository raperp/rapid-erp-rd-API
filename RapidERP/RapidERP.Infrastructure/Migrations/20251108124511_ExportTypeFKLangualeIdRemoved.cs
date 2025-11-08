using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExportTypeFKLangualeIdRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportTypes_Languages_LanguageId",
                table: "ExportTypes");

            migrationBuilder.DropIndex(
                name: "IX_ExportTypes_LanguageId",
                table: "ExportTypes");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "ExportTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "ExportTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExportTypes_LanguageId",
                table: "ExportTypes",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportTypes_Languages_LanguageId",
                table: "ExportTypes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
