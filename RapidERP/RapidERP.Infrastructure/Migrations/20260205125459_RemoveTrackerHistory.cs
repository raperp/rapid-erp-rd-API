using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTrackerHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Browser",
                table: "UserIPWhitelistHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "UserIPWhitelistHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "UserIPWhitelistHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "UserIPWhitelistHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "UserIPWhitelistHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "UserIPWhitelistHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "UserIPWhitelistHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "UserHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "UserHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "UserHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "UserHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "UserHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "UserHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "UserHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "TextModuleHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "TextModuleHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "TextModuleHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "TextModuleHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "TextModuleHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "TextModuleHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "TextModuleHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "TenantHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "TenantHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "TenantHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "TenantHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "TenantHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "TenantHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "TenantHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "TableHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "TableHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "TableHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "TableHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "TableHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "TableHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "TableHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "SupplierTypeHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "SupplierTypeHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "SupplierTypeHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "SupplierTypeHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "SupplierTypeHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "SupplierTypeHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "SupplierTypeHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "SupplierHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "SupplierHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "SupplierHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "SupplierHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "SupplierHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "SupplierHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "SupplierHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "SubmoduleHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "SubmoduleHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "SubmoduleHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "SubmoduleHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "SubmoduleHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "SubmoduleHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "SubmoduleHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "StatusTypeHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "StatusTypeHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "StatusTypeHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "StatusTypeHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "StatusTypeHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "StatusTypeHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "StatusTypeHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "StateHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "StateHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "StateHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "StateHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "StateHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "StateHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "StateHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "SolutionHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "SolutionHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "SolutionHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "SolutionHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "SolutionHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "SolutionHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "SolutionHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "SalesmanHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "SalesmanHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "SalesmanHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "SalesmanHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "SalesmanHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "SalesmanHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "SalesmanHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "RoleHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "RoleHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "RoleHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "RoleHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "RoleHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "RoleHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "RoleHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "RiderHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "RiderHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "RiderHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "RiderHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "RiderHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "RiderHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "RiderHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "OrderTypeHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "OrderTypeHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "OrderTypeHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "OrderTypeHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "OrderTypeHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "OrderTypeHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "OrderTypeHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "MessageModuleHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "MessageModuleHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "MessageModuleHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "MessageModuleHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "MessageModuleHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "MessageModuleHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "MessageModuleHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "MenuModuleHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "MenuModuleHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "MenuModuleHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "MenuModuleHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "MenuModuleHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "MenuModuleHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "MenuModuleHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "MainModuleHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "MainModuleHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "MainModuleHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "MainModuleHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "MainModuleHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "MainModuleHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "MainModuleHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "LanguageHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "LanguageHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "LanguageHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "LanguageHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "LanguageHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "LanguageHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "LanguageHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "KitchenHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "KitchenHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "KitchenHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "KitchenHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "KitchenHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "KitchenHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "KitchenHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "ExportTypeHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "ExportTypeHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "ExportTypeHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "ExportTypeHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "ExportTypeHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "ExportTypeHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "ExportTypeHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "DesignationHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "DesignationHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "DesignationHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "DesignationHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "DesignationHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "DesignationHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "DesignationHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "DepartmentHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "DepartmentHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "DepartmentHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "DepartmentHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "DepartmentHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "DepartmentHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "DepartmentHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "CurrencyHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "CurrencyHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "CurrencyHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "CurrencyHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "CurrencyHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "CurrencyHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "CurrencyHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "CityHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "CityHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "CityHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "CityHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "CityHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "CityHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "CityHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "CalendarHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "CalendarHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "CalendarHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "CalendarHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "CalendarHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "CalendarHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "CalendarHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "AreaHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "AreaHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "AreaHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "AreaHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "AreaHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "AreaHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "AreaHistory");

            migrationBuilder.DropColumn(
                name: "Browser",
                table: "ActionTypeHistory");

            migrationBuilder.DropColumn(
                name: "DeviceIP",
                table: "ActionTypeHistory");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "ActionTypeHistory");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "ActionTypeHistory");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "ActionTypeHistory");

            migrationBuilder.DropColumn(
                name: "LocationURL",
                table: "ActionTypeHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "ActionTypeHistory");

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "UserIPWhitelistHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 15);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "UserIPWhitelistHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .OldAnnotation("Relational:ColumnOrder", 16);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "UserHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 21);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "UserHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .OldAnnotation("Relational:ColumnOrder", 22);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "TenantHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 36);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "TenantHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .OldAnnotation("Relational:ColumnOrder", 37);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "TableHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 15);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "TableHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .OldAnnotation("Relational:ColumnOrder", 16);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "StatusTypeHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 16);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "StatusTypeHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .OldAnnotation("Relational:ColumnOrder", 17);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "StateHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "StateHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .OldAnnotation("Relational:ColumnOrder", 21);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "SolutionHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "SolutionHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .OldAnnotation("Relational:ColumnOrder", 21);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "RoleHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 14);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "RoleHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .OldAnnotation("Relational:ColumnOrder", 15);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "LanguageHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 14);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "LanguageHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .OldAnnotation("Relational:ColumnOrder", 15);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "ExportTypeHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 12);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "ExportTypeHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .OldAnnotation("Relational:ColumnOrder", 13);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "CurrencyHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 21);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "CurrencyHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .OldAnnotation("Relational:ColumnOrder", 22);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "CalendarHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 21);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "CalendarHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .OldAnnotation("Relational:ColumnOrder", 22);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "ActionTypeHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 15);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "ActionTypeHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .OldAnnotation("Relational:ColumnOrder", 16);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "UserIPWhitelistHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "UserIPWhitelistHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 16);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "UserIPWhitelistHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "UserIPWhitelistHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "UserIPWhitelistHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 12);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "UserIPWhitelistHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 13);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "UserIPWhitelistHistory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "UserIPWhitelistHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 11);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "UserIPWhitelistHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "UserHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 21);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "UserHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 22);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "UserHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "UserHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 16);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "UserHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 18);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "UserHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 19);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "UserHistory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "UserHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 17);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "UserHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 20);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "TextModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "TextModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "TextModuleHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "TextModuleHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "TextModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "TextModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "TextModuleHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "TenantHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 36);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "TenantHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 37);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "TenantHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 29);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "TenantHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 31);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "TenantHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 33);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "TenantHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 34);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "TenantHistory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 30);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "TenantHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 32);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "TenantHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 35);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "TableHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "TableHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 16);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "TableHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "TableHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "TableHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 12);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "TableHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 13);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "TableHistory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "TableHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 11);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "TableHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "SupplierTypeHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "SupplierTypeHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "SupplierTypeHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "SupplierTypeHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "SupplierTypeHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "SupplierTypeHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "SupplierTypeHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "SupplierHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "SupplierHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "SupplierHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "SupplierHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "SupplierHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "SupplierHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "SupplierHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "SubmoduleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "SubmoduleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "SubmoduleHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "SubmoduleHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "SubmoduleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "SubmoduleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "SubmoduleHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "StatusTypeHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 16);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "StatusTypeHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 17);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "StatusTypeHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "StatusTypeHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 11);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "StatusTypeHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 13);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "StatusTypeHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "StatusTypeHistory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "StatusTypeHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 12);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "StatusTypeHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "StateHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "StateHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 21);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "StateHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 13);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "StateHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "StateHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 17);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "StateHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 18);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "StateHistory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "StateHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 16);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "StateHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 19);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "SolutionHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "SolutionHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 21);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "SolutionHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 13);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "SolutionHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "SolutionHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 17);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "SolutionHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 18);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "SolutionHistory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "SolutionHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 16);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "SolutionHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 19);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "SalesmanHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "SalesmanHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "SalesmanHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "SalesmanHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "SalesmanHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "SalesmanHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "SalesmanHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "RoleHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "RoleHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "RoleHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "RoleHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "RoleHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 11);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "RoleHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 12);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "RoleHistory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "RoleHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "RoleHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 13);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "RiderHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "RiderHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "RiderHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "RiderHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "RiderHistory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "RiderHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "RiderHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "OrderTypeHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "OrderTypeHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "OrderTypeHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "OrderTypeHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "OrderTypeHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "OrderTypeHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "OrderTypeHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "MessageModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "MessageModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "MessageModuleHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "MessageModuleHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "MessageModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "MessageModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "MessageModuleHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "MenuModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "MenuModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "MenuModuleHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "MenuModuleHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "MenuModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "MenuModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "MenuModuleHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "MainModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "MainModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "MainModuleHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "MainModuleHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "MainModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "MainModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "MainModuleHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "LanguageHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "LanguageHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "LanguageHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "LanguageHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "LanguageHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 11);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "LanguageHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 12);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "LanguageHistory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "LanguageHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "LanguageHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 13);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "KitchenHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "KitchenHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "KitchenHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "KitchenHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "KitchenHistory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "KitchenHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "KitchenHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "ExportTypeHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 12);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "ExportTypeHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 13);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "ExportTypeHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "ExportTypeHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "ExportTypeHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "ExportTypeHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "ExportTypeHistory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "ExportTypeHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "ExportTypeHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 11);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "DesignationHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "DesignationHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "DesignationHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "DesignationHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "DesignationHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "DesignationHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "DesignationHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "DepartmentHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "DepartmentHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "DepartmentHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "DepartmentHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "DepartmentHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "DepartmentHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "DepartmentHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "CurrencyHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 21);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "CurrencyHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 22);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "CurrencyHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "CurrencyHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 16);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "CurrencyHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 18);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "CurrencyHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 19);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "CurrencyHistory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "CurrencyHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 17);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "CurrencyHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 20);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "CountryAudits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "CountryAudits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "CountryAudits",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "CountryAudits",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "CountryAudits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "CountryAudits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "CountryAudits",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "CityHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "CityHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "CityHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "CityHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "CityHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "CityHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "CityHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "CalendarHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 21);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "CalendarHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 22);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "CalendarHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "CalendarHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 16);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "CalendarHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 18);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "CalendarHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 19);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "CalendarHistory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "CalendarHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 17);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "CalendarHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 20);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "AreaHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "AreaHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "AreaHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "AreaHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "AreaHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "AreaHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "AreaHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "ActionTypeHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "ActionTypeHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 16);

            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "ActionTypeHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIP",
                table: "ActionTypeHistory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "ActionTypeHistory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 12);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "ActionTypeHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 13);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "ActionTypeHistory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AddColumn<string>(
                name: "LocationURL",
                table: "ActionTypeHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 11);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "ActionTypeHistory",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 14);
        }
    }
}
