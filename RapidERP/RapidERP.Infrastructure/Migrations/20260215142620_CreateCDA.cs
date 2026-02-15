using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateCDA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultCurrencyId",
                table: "Countries",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultCurrencyId",
                table: "Countries");
        }
    }
}
