using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigMod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "SupplierTypes");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "States");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Areas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "SupplierTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Suppliers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "States",
                type: "bit",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Salesmen",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "OrderTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Designations",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Departments",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Currencies",
                type: "bit",
                nullable: false,
                defaultValue: false)
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Countries",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Cities",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Areas",
                type: "bit",
                nullable: true);
        }
    }
}
