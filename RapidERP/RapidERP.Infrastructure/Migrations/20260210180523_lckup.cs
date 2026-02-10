using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class lckup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "CountryLookups");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "CountryLookups");

            migrationBuilder.RenameColumn(
                name: "Localization",
                table: "CountryLookups",
                newName: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "CountryLookups",
                newName: "Localization");

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
    }
}
