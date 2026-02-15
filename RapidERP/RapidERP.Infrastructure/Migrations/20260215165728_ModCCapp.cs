using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModCCapp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryCapture_Countries_CountryId",
                table: "CountryCapture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryCapture",
                table: "CountryCapture");

            migrationBuilder.RenameTable(
                name: "CountryCapture",
                newName: "CountryCaptures");

            migrationBuilder.RenameIndex(
                name: "IX_CountryCapture_CountryId",
                table: "CountryCaptures",
                newName: "IX_CountryCaptures_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryCaptures",
                table: "CountryCaptures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCaptures_Countries_CountryId",
                table: "CountryCaptures",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryCaptures_Countries_CountryId",
                table: "CountryCaptures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryCaptures",
                table: "CountryCaptures");

            migrationBuilder.RenameTable(
                name: "CountryCaptures",
                newName: "CountryCapture");

            migrationBuilder.RenameIndex(
                name: "IX_CountryCaptures_CountryId",
                table: "CountryCapture",
                newName: "IX_CountryCapture_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryCapture",
                table: "CountryCapture",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCapture_Countries_CountryId",
                table: "CountryCapture",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
