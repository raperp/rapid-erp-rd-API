using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCountryExportsTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_countryExports_Countries_CountryId",
                table: "countryExports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_countryExports",
                table: "countryExports");

            migrationBuilder.RenameTable(
                name: "countryExports",
                newName: "CountryExports");

            migrationBuilder.RenameIndex(
                name: "IX_countryExports_CountryId",
                table: "CountryExports",
                newName: "IX_CountryExports_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryExports",
                table: "CountryExports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryExports_Countries_CountryId",
                table: "CountryExports",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryExports_Countries_CountryId",
                table: "CountryExports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryExports",
                table: "CountryExports");

            migrationBuilder.RenameTable(
                name: "CountryExports",
                newName: "countryExports");

            migrationBuilder.RenameIndex(
                name: "IX_CountryExports_CountryId",
                table: "countryExports",
                newName: "IX_countryExports_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_countryExports",
                table: "countryExports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_countryExports_Countries_CountryId",
                table: "countryExports",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
