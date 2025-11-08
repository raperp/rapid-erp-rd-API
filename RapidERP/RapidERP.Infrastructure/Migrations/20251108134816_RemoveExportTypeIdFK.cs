using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveExportTypeIdFK : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_LanguageAudits_ExportTypeId",
                table: "LanguageAudits");

            migrationBuilder.DropIndex(
                name: "IX_ExportTypeAudits_ExportTypeId",
                table: "ExportTypeAudits");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_LanguageAudits_ExportTypeId",
                table: "LanguageAudits",
                column: "ExportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportTypeAudits_ExportTypeId",
                table: "ExportTypeAudits",
                column: "ExportTypeId");

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
    }
}
