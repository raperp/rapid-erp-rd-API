using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CountryModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "TableHistory");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "SupplierTypeHistory");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "SupplierHistory");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "SolutionHistory");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "SalesmanHistory");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "RiderHistory");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "OrderTypeHistory");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "KitchenHistory");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "DesignationHistory");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "DepartmentHistory");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "CurrencyHistory");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "TimeZoneId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "CityHistory");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "CalendarHistory");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "AreaHistory");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "TextModuleHistory",
                newName: "StatusTypeId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "TenantHistory",
                newName: "StatusTypeId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "TableHistory",
                newName: "StatusTypeId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "SupplierTypeHistory",
                newName: "StatusTypeId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "SupplierHistory",
                newName: "StatusTypeId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "StateHistory",
                newName: "StatusTypeId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "SolutionHistory",
                newName: "StatusTypeId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "SalesmanHistory",
                newName: "StatusTypeId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "RiderHistory",
                newName: "StatusTypeId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "OrderTypeHistory",
                newName: "StatusTypeId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "KitchenHistory",
                newName: "StatusTypeId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "DesignationHistory",
                newName: "StatusTypeId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "DepartmentHistory",
                newName: "StatusTypeId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "CurrencyHistory",
                newName: "StatusTypeId");

            migrationBuilder.RenameColumn(
                name: "TimeZoneId",
                table: "CountryAudits",
                newName: "StatusTypeId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "CityHistory",
                newName: "StatusTypeId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "CalendarHistory",
                newName: "StatusTypeId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "AreaHistory",
                newName: "StatusTypeId");

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "UserIPWhitelistHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "UserHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "TenantHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "SubmoduleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "StateHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "SolutionHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "RoleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "MessageModuleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "MenuModuleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "MainModuleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "LanguageHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "ExportTypeHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "CurrencyHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "CalendarHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "ActionTypeHistory",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "UserIPWhitelistHistory");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "UserHistory");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "SubmoduleHistory");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "RoleHistory");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "MessageModuleHistory");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "MenuModuleHistory");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "MainModuleHistory");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "LanguageHistory");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "ExportTypeHistory");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "ActionTypeHistory");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "TextModuleHistory",
                newName: "MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "TenantHistory",
                newName: "MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "TableHistory",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "SupplierTypeHistory",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "SupplierHistory",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "StateHistory",
                newName: "MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "SolutionHistory",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "SalesmanHistory",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "RiderHistory",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "OrderTypeHistory",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "KitchenHistory",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "DesignationHistory",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "DepartmentHistory",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "CurrencyHistory",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "CountryAudits",
                newName: "TimeZoneId");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "CityHistory",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "CalendarHistory",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "AreaHistory",
                newName: "TenantId");

            migrationBuilder.AlterColumn<int>(
                name: "MenuModuleId",
                table: "TenantHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "TableHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "SupplierTypeHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "SupplierHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuModuleId",
                table: "StateHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "SolutionHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "SolutionHistory",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "SalesmanHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "RiderHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "OrderTypeHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "KitchenHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "DesignationHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "DepartmentHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "CurrencyHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "CurrencyHistory",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "CountryAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "CountryAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "CountryAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "CountryAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeZoneId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "CityHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "CalendarHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "CalendarHistory",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "AreaHistory",
                type: "int",
                nullable: true);
        }
    }
}
