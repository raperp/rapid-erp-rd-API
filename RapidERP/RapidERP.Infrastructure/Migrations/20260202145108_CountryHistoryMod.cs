using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CountryHistoryMod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "CountryHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "CountryHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeZoneId",
                table: "CountryHistory",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "CountryHistory");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "CountryHistory");

            migrationBuilder.DropColumn(
                name: "TimeZoneId",
                table: "CountryHistory");
        }
    }
}
