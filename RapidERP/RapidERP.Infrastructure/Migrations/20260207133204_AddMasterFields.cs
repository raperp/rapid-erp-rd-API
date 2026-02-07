using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMasterFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UserIPWhitelists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "UserIPWhitelists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "UserIPWhitelists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "UserIPWhitelists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "UserIPWhitelists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "UserIPWhitelistHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "UserHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TextModules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "TextModules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "TextModules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "TextModules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "TextModules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "TextModuleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Tenants",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Tenants",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "Tenants",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Tenants",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "TenantHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Tables",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Tables",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "Tables",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Tables",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Tables",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "TableHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SupplierTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "SupplierTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "SupplierTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "SupplierTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Suppliers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Suppliers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "Suppliers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Suppliers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "SupplierHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Submodules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Submodules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "Submodules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Submodules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Submodules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "SubmoduleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "StatusTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "StatusTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "StatusTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "StatusTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "StatusTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "StatusTypeHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "States",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "States",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "States",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "States",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "States",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "StateHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Solutions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Solutions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "Solutions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Solutions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Solutions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "SolutionHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Salesmen",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Salesmen",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "Salesmen",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Salesmen",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Salesmen",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "SalesmanHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "RoleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Riders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Riders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "Riders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Riders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Riders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "RiderHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "OrderTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "OrderTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "OrderTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "OrderTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "OrderTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "OrderTypeHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MessageModules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "MessageModules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "MessageModules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "MessageModules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "MessageModules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "MessageModuleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MenuModules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "MenuModules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "MenuModules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "MenuModules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "MenuModules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "MenuModuleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MainModules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "MainModules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "MainModules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "MainModules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "MainModules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "MainModuleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Languages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Languages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "Languages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId1",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Languages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Kitchens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Kitchens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "Kitchens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Kitchens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Kitchens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "KitchenHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ExportTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "ExportTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "ExportTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "ExportTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ExportTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "ExportTypeHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Designations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Designations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "Designations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Designations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Designations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "DesignationHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Departments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Departments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "Departments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Departments",
                type: "datetime2",
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
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Currencies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Currencies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "Currencies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Currencies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Currencies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "CountryAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PageViewStartedAt",
                table: "CountryActivities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PageViewEndedAt",
                table: "CountryActivities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "CountryActivities",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)",
                oldPrecision: 9,
                oldScale: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "CountryActivities",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)",
                oldPrecision: 9,
                oldScale: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "CountryActivities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "CountryActivities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Countries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Countries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "Countries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Countries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "CityHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Cities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "Cities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Calendars",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Calendars",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "Calendars",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Calendars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Calendars",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "CalendarHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Areas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Areas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "Areas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Areas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Areas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "AreaHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ActionTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "ActionTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DraftedAt",
                table: "ActionTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "ActionTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ActionTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "ActionTypeHistory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "countryExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExportMediaId = table.Column<int>(type: "int", nullable: true),
                    ExportMediaTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExportMediaURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countryExports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_countryExports_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_LanguageId",
                table: "Users",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIPWhitelists_LanguageId",
                table: "UserIPWhitelists",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TextModules_LanguageId",
                table: "TextModules",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_LanguageId",
                table: "Tables",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_LanguageId",
                table: "Suppliers",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Submodules_LanguageId",
                table: "Submodules",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTypes_LanguageId",
                table: "StatusTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_States_LanguageId",
                table: "States",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_LanguageId",
                table: "Solutions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Salesmen_LanguageId",
                table: "Salesmen",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_LanguageId",
                table: "Roles",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Riders_LanguageId",
                table: "Riders",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTypes_LanguageId",
                table: "OrderTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageModules_LanguageId",
                table: "MessageModules",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuModules_LanguageId",
                table: "MenuModules",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MainModules_LanguageId",
                table: "MainModules",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_LanguageId1",
                table: "Languages",
                column: "LanguageId1");

            migrationBuilder.CreateIndex(
                name: "IX_Kitchens_LanguageId",
                table: "Kitchens",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportTypes_LanguageId",
                table: "ExportTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_LanguageId",
                table: "Designations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_LanguageId",
                table: "Departments",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_LanguageId",
                table: "Currencies",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_LanguageId",
                table: "Countries",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_LanguageId",
                table: "Cities",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_LanguageId",
                table: "Calendars",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_LanguageId",
                table: "Areas",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypes_LanguageId",
                table: "ActionTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_countryExports_CountryId",
                table: "countryExports",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionTypes_Languages_LanguageId",
                table: "ActionTypes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Languages_LanguageId",
                table: "Areas",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_Languages_LanguageId",
                table: "Calendars",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Languages_LanguageId",
                table: "Cities",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Languages_LanguageId",
                table: "Countries",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_Languages_LanguageId",
                table: "Currencies",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Languages_LanguageId",
                table: "Departments",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_Languages_LanguageId",
                table: "Designations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportTypes_Languages_LanguageId",
                table: "ExportTypes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitchens_Languages_LanguageId",
                table: "Kitchens",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Languages_LanguageId1",
                table: "Languages",
                column: "LanguageId1",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MainModules_Languages_LanguageId",
                table: "MainModules",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuModules_Languages_LanguageId",
                table: "MenuModules",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageModules_Languages_LanguageId",
                table: "MessageModules",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTypes_Languages_LanguageId",
                table: "OrderTypes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Riders_Languages_LanguageId",
                table: "Riders",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Languages_LanguageId",
                table: "Roles",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Salesmen_Languages_LanguageId",
                table: "Salesmen",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Solutions_Languages_LanguageId",
                table: "Solutions",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Languages_LanguageId",
                table: "States",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusTypes_Languages_LanguageId",
                table: "StatusTypes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Submodules_Languages_LanguageId",
                table: "Submodules",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Languages_LanguageId",
                table: "Suppliers",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Languages_LanguageId",
                table: "Tables",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TextModules_Languages_LanguageId",
                table: "TextModules",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserIPWhitelists_Languages_LanguageId",
                table: "UserIPWhitelists",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Languages_LanguageId",
                table: "Users",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionTypes_Languages_LanguageId",
                table: "ActionTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Languages_LanguageId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_Languages_LanguageId",
                table: "Calendars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Languages_LanguageId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Languages_LanguageId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_Languages_LanguageId",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Languages_LanguageId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Designations_Languages_LanguageId",
                table: "Designations");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportTypes_Languages_LanguageId",
                table: "ExportTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitchens_Languages_LanguageId",
                table: "Kitchens");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Languages_LanguageId1",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_MainModules_Languages_LanguageId",
                table: "MainModules");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuModules_Languages_LanguageId",
                table: "MenuModules");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageModules_Languages_LanguageId",
                table: "MessageModules");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTypes_Languages_LanguageId",
                table: "OrderTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Riders_Languages_LanguageId",
                table: "Riders");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Languages_LanguageId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Salesmen_Languages_LanguageId",
                table: "Salesmen");

            migrationBuilder.DropForeignKey(
                name: "FK_Solutions_Languages_LanguageId",
                table: "Solutions");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Languages_LanguageId",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusTypes_Languages_LanguageId",
                table: "StatusTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Submodules_Languages_LanguageId",
                table: "Submodules");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Languages_LanguageId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Languages_LanguageId",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_TextModules_Languages_LanguageId",
                table: "TextModules");

            migrationBuilder.DropForeignKey(
                name: "FK_UserIPWhitelists_Languages_LanguageId",
                table: "UserIPWhitelists");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Languages_LanguageId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "countryExports");

            migrationBuilder.DropIndex(
                name: "IX_Users_LanguageId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserIPWhitelists_LanguageId",
                table: "UserIPWhitelists");

            migrationBuilder.DropIndex(
                name: "IX_TextModules_LanguageId",
                table: "TextModules");

            migrationBuilder.DropIndex(
                name: "IX_Tables_LanguageId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_LanguageId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Submodules_LanguageId",
                table: "Submodules");

            migrationBuilder.DropIndex(
                name: "IX_StatusTypes_LanguageId",
                table: "StatusTypes");

            migrationBuilder.DropIndex(
                name: "IX_States_LanguageId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Solutions_LanguageId",
                table: "Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Salesmen_LanguageId",
                table: "Salesmen");

            migrationBuilder.DropIndex(
                name: "IX_Roles_LanguageId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Riders_LanguageId",
                table: "Riders");

            migrationBuilder.DropIndex(
                name: "IX_OrderTypes_LanguageId",
                table: "OrderTypes");

            migrationBuilder.DropIndex(
                name: "IX_MessageModules_LanguageId",
                table: "MessageModules");

            migrationBuilder.DropIndex(
                name: "IX_MenuModules_LanguageId",
                table: "MenuModules");

            migrationBuilder.DropIndex(
                name: "IX_MainModules_LanguageId",
                table: "MainModules");

            migrationBuilder.DropIndex(
                name: "IX_Languages_LanguageId1",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Kitchens_LanguageId",
                table: "Kitchens");

            migrationBuilder.DropIndex(
                name: "IX_ExportTypes_LanguageId",
                table: "ExportTypes");

            migrationBuilder.DropIndex(
                name: "IX_Designations_LanguageId",
                table: "Designations");

            migrationBuilder.DropIndex(
                name: "IX_Departments_LanguageId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_LanguageId",
                table: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Countries_LanguageId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Cities_LanguageId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Calendars_LanguageId",
                table: "Calendars");

            migrationBuilder.DropIndex(
                name: "IX_Areas_LanguageId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_ActionTypes_LanguageId",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UserIPWhitelists");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "UserIPWhitelists");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "UserIPWhitelists");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "UserIPWhitelists");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "UserIPWhitelists");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "UserIPWhitelistHistory");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "UserHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TextModules");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "TextModules");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "TextModules");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "TextModules");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "TextModules");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "TextModuleHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "TenantHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "TableHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SupplierTypes");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "SupplierTypes");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "SupplierTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "SupplierTypes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "SupplierHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "SubmoduleHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "StatusTypeHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "States");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "States");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "States");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "States");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "StateHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "SolutionHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "SalesmanHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "RoleHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "RiderHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "OrderTypeHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MessageModules");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "MessageModules");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "MessageModules");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "MessageModules");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MessageModules");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "MessageModuleHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MenuModules");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "MenuModules");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "MenuModules");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "MenuModules");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MenuModules");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "MenuModuleHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "MainModuleHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "LanguageId1",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Kitchens");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Kitchens");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "Kitchens");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Kitchens");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Kitchens");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "KitchenHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ExportTypeHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "DesignationHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "DepartmentHistory");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "CurrencyHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "CityHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "CalendarHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "AreaHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "DraftedAt",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ActionTypeHistory");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PageViewStartedAt",
                table: "CountryActivities",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PageViewEndedAt",
                table: "CountryActivities",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "CountryActivities",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)",
                oldPrecision: 9,
                oldScale: 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "CountryActivities",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)",
                oldPrecision: 9,
                oldScale: 6);

            migrationBuilder.AlterColumn<int>(
                name: "ActionBy",
                table: "CountryActivities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionAt",
                table: "CountryActivities",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
