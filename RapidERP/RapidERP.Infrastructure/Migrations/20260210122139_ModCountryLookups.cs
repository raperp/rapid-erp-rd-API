using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModCountryLookups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "CountryLookups");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "CountryLookups");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "CountryLookups",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "CountryLookups",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "CountryLookups");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "CountryLookups");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "CountryLookups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "CountryLookups",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
