using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExprtTypeLangId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ExportTypeAudits_LanguageId",
                table: "ExportTypeAudits",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportTypeAudits_Languages_LanguageId",
                table: "ExportTypeAudits",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportTypeAudits_Languages_LanguageId",
                table: "ExportTypeAudits");

            migrationBuilder.DropIndex(
                name: "IX_ExportTypeAudits_LanguageId",
                table: "ExportTypeAudits");
        }
    }
}
