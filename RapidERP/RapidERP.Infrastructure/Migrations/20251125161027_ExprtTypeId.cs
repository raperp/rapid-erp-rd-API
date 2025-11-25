using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExprtTypeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportTypeAudits_ExportTypes_ExportTypeId",
                table: "ExportTypeAudits");

            migrationBuilder.DropIndex(
                name: "IX_ExportTypeAudits_ExportTypeId",
                table: "ExportTypeAudits");
        }
    }
}
