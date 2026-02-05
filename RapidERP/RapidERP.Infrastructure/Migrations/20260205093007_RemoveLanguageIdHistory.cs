using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLanguageIdHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "TextModuleHistory");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "TenantHistory");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "SupplierHistory");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "SubmoduleHistory");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "StatusTypeHistory");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "StateHistory");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "SolutionHistory");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "SalesmanHistory");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "OrderTypeHistory");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "MessageModuleHistory");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "MenuModuleHistory");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "MainModuleHistory");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ExportTypeHistory");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "DesignationHistory");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "DepartmentHistory");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "CurrencyHistory");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "CityHistory");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "CalendarHistory");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "AreaHistory");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ActionTypeHistory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "TextModuleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "TenantHistory",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "SupplierHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "SubmoduleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "StatusTypeHistory",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "StateHistory",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "SolutionHistory",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "SalesmanHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "OrderTypeHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "MessageModuleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "MenuModuleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "MainModuleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "ExportTypeHistory",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "DesignationHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "DepartmentHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "CurrencyHistory",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "CountryAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "CityHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "CalendarHistory",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "AreaHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "ActionTypeHistory",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 2);
        }
    }
}
