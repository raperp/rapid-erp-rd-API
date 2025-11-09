using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCountryIdInCountryAuditTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "CountryAudits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CountryAudits_CountryId",
                table: "CountryAudits",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryAudits_Countries_CountryId",
                table: "CountryAudits",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryAudits_Countries_CountryId",
                table: "CountryAudits");

            migrationBuilder.DropIndex(
                name: "IX_CountryAudits_CountryId",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "CountryAudits");
        }
    }
}
