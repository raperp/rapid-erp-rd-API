using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateCA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "SupplierTypeHistory");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "SupplierHistory");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "StateHistory");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "SalesmanHistory");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "OrderTypeHistory");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "DesignationHistory");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "DepartmentHistory");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "CurrencyHistory");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "CityHistory");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "AreaHistory");

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "UserIPWhitelistHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "UserHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "TextModuleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "TableHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "SupplierTypeHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "SupplierHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "SubmoduleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "StatusTypeHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "StateHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "SolutionHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "SalesmanHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "RoleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "RiderHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "OrderTypeHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "MessageModuleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "MenuModuleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "MainModuleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "LanguageHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "KitchenHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "ExportTypeHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "DesignationHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "DepartmentHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "CurrencyHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultCurrencyId",
                table: "CountryAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "CountryAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "CityHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "CalendarHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "AreaHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "ActionTypeHistory",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "UserIPWhitelistHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "UserHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "TextModuleHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "TableHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "SupplierTypeHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "SupplierHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "SubmoduleHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "StatusTypeHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "StateHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "SolutionHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "SalesmanHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "RoleHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "RiderHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "OrderTypeHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "MessageModuleHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "MenuModuleHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "MainModuleHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "LanguageHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "KitchenHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "ExportTypeHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "DesignationHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "DepartmentHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "CurrencyHistory");

            migrationBuilder.DropColumn(
                name: "DefaultCurrencyId",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "CityHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "CalendarHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "AreaHistory");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "ActionTypeHistory");

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "SupplierTypeHistory",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "SupplierHistory",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "StateHistory",
                type: "bit",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 12);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "SalesmanHistory",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "OrderTypeHistory",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "DesignationHistory",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "DepartmentHistory",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "CurrencyHistory",
                type: "bit",
                nullable: false,
                defaultValue: false)
                .Annotation("Relational:ColumnOrder", 12);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "CountryAudits",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "CityHistory",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "AreaHistory",
                type: "bit",
                nullable: true);
        }
    }
}
