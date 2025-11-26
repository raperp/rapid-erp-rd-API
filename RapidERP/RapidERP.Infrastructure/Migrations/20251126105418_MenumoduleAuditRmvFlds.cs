using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MenumoduleAuditRmvFlds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prefix",
                table: "MenuModuleAudits");

            migrationBuilder.AddColumn<int>(
                name: "SetSerial",
                table: "MenuModuleAudits",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SetSerial",
                table: "MenuModuleAudits");

            migrationBuilder.AddColumn<string>(
                name: "Prefix",
                table: "MenuModuleAudits",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
