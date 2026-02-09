using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Coumod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionTypes_Languages_LanguageId",
                table: "ActionTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Languages_LanguageId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Areas_MenuModules_MenuModuleId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Areas_StatusTypes_StatusTypeId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_Languages_LanguageId",
                table: "Calendars");

            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_MenuModules_MenuModuleId",
                table: "Calendars");

            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_StatusTypes_StatusTypeId",
                table: "Calendars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Languages_LanguageId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_MenuModules_MenuModuleId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_StatusTypes_StatusTypeId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Languages_LanguageId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_MenuModules_MenuModuleId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_StatusTypes_StatusTypeId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_Languages_LanguageId",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_MenuModules_MenuModuleId",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_StatusTypes_StatusTypeId",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Languages_LanguageId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_MenuModules_MenuModuleId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_StatusTypes_StatusTypeId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Designations_Languages_LanguageId",
                table: "Designations");

            migrationBuilder.DropForeignKey(
                name: "FK_Designations_MenuModules_MenuModuleId",
                table: "Designations");

            migrationBuilder.DropForeignKey(
                name: "FK_Designations_StatusTypes_StatusTypeId",
                table: "Designations");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportTypes_Languages_LanguageId",
                table: "ExportTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitchens_Languages_LanguageId",
                table: "Kitchens");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitchens_MenuModules_MenuModuleId",
                table: "Kitchens");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitchens_StatusTypes_StatusTypeId",
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
                name: "FK_OrderTypes_MenuModules_MenuModuleId",
                table: "OrderTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTypes_StatusTypes_StatusTypeId",
                table: "OrderTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Riders_Languages_LanguageId",
                table: "Riders");

            migrationBuilder.DropForeignKey(
                name: "FK_Riders_MenuModules_MenuModuleId",
                table: "Riders");

            migrationBuilder.DropForeignKey(
                name: "FK_Riders_StatusTypes_StatusTypeId",
                table: "Riders");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Languages_LanguageId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_StatusTypes_StatusTypeId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Salesmen_Languages_LanguageId",
                table: "Salesmen");

            migrationBuilder.DropForeignKey(
                name: "FK_Salesmen_MenuModules_MenuModuleId",
                table: "Salesmen");

            migrationBuilder.DropForeignKey(
                name: "FK_Salesmen_StatusTypes_StatusTypeId",
                table: "Salesmen");

            migrationBuilder.DropForeignKey(
                name: "FK_Solutions_Languages_LanguageId",
                table: "Solutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Solutions_MenuModules_MenuModuleId",
                table: "Solutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Solutions_StatusTypes_StatusTypeId",
                table: "Solutions");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Languages_LanguageId",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_States_MenuModules_MenuModuleId",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_States_StatusTypes_StatusTypeId",
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
                name: "FK_Suppliers_MenuModules_MenuModuleId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_StatusTypes_StatusTypeId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierTypes_MenuModules_MenuModuleId",
                table: "SupplierTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierTypes_StatusTypes_StatusTypeId",
                table: "SupplierTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Languages_LanguageId",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_MenuModules_MenuModuleId",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_StatusTypes_StatusTypeId",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_TextModules_Languages_LanguageId",
                table: "TextModules");

            migrationBuilder.DropForeignKey(
                name: "FK_TextModules_MenuModules_MenuModuleId",
                table: "TextModules");

            migrationBuilder.DropForeignKey(
                name: "FK_UserIPWhitelists_Languages_LanguageId",
                table: "UserIPWhitelists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserIPWhitelists_StatusTypes_StatusTypeId",
                table: "UserIPWhitelists");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Languages_LanguageId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_StatusTypes_StatusTypeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_LanguageId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StatusTypeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserIPWhitelists_LanguageId",
                table: "UserIPWhitelists");

            migrationBuilder.DropIndex(
                name: "IX_UserIPWhitelists_StatusTypeId",
                table: "UserIPWhitelists");

            migrationBuilder.DropIndex(
                name: "IX_TextModules_LanguageId",
                table: "TextModules");

            migrationBuilder.DropIndex(
                name: "IX_TextModules_MenuModuleId",
                table: "TextModules");

            migrationBuilder.DropIndex(
                name: "IX_Tables_LanguageId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_MenuModuleId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_StatusTypeId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_SupplierTypes_MenuModuleId",
                table: "SupplierTypes");

            migrationBuilder.DropIndex(
                name: "IX_SupplierTypes_StatusTypeId",
                table: "SupplierTypes");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_LanguageId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_MenuModuleId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_StatusTypeId",
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
                name: "IX_States_MenuModuleId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_StatusTypeId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Solutions_LanguageId",
                table: "Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Solutions_MenuModuleId",
                table: "Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Solutions_StatusTypeId",
                table: "Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Salesmen_LanguageId",
                table: "Salesmen");

            migrationBuilder.DropIndex(
                name: "IX_Salesmen_MenuModuleId",
                table: "Salesmen");

            migrationBuilder.DropIndex(
                name: "IX_Salesmen_StatusTypeId",
                table: "Salesmen");

            migrationBuilder.DropIndex(
                name: "IX_Roles_LanguageId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_StatusTypeId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Riders_LanguageId",
                table: "Riders");

            migrationBuilder.DropIndex(
                name: "IX_Riders_MenuModuleId",
                table: "Riders");

            migrationBuilder.DropIndex(
                name: "IX_Riders_StatusTypeId",
                table: "Riders");

            migrationBuilder.DropIndex(
                name: "IX_OrderTypes_LanguageId",
                table: "OrderTypes");

            migrationBuilder.DropIndex(
                name: "IX_OrderTypes_MenuModuleId",
                table: "OrderTypes");

            migrationBuilder.DropIndex(
                name: "IX_OrderTypes_StatusTypeId",
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
                name: "IX_Kitchens_MenuModuleId",
                table: "Kitchens");

            migrationBuilder.DropIndex(
                name: "IX_Kitchens_StatusTypeId",
                table: "Kitchens");

            migrationBuilder.DropIndex(
                name: "IX_ExportTypes_LanguageId",
                table: "ExportTypes");

            migrationBuilder.DropIndex(
                name: "IX_Designations_LanguageId",
                table: "Designations");

            migrationBuilder.DropIndex(
                name: "IX_Designations_MenuModuleId",
                table: "Designations");

            migrationBuilder.DropIndex(
                name: "IX_Designations_StatusTypeId",
                table: "Designations");

            migrationBuilder.DropIndex(
                name: "IX_Departments_LanguageId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_MenuModuleId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_StatusTypeId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_LanguageId",
                table: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_MenuModuleId",
                table: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_StatusTypeId",
                table: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Countries_LanguageId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_MenuModuleId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_StatusTypeId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Cities_LanguageId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_MenuModuleId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_StatusTypeId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Calendars_LanguageId",
                table: "Calendars");

            migrationBuilder.DropIndex(
                name: "IX_Calendars_MenuModuleId",
                table: "Calendars");

            migrationBuilder.DropIndex(
                name: "IX_Calendars_StatusTypeId",
                table: "Calendars");

            migrationBuilder.DropIndex(
                name: "IX_Areas_LanguageId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Areas_MenuModuleId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Areas_StatusTypeId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_ActionTypes_LanguageId",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "UserIPWhitelists");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "UserIPWhitelists");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "TextModules");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "TextModules");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "SupplierTypes");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "SupplierTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "MessageModules");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "MenuModules");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "LanguageId1",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Kitchens");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "Kitchens");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Kitchens");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "DialingCode",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ActionTypes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserIPWhitelists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserIPWhitelists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserIPWhitelists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TextModules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TextModules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TextModules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Tenants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tenants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tenants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tenants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tables",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SupplierTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SupplierTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SupplierTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Suppliers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Suppliers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Suppliers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Submodules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Submodules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Submodules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "StatusTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "StatusTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StatusTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "States",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "States",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "States",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Solutions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Solutions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Solutions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Salesmen",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Salesmen",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Salesmen",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Riders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Riders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Riders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "OrderTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "OrderTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MessageModules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MessageModules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MessageModules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MenuModules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MenuModules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MenuModules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MainModules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MainModules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MainModules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Languages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Languages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Languages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Kitchens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Kitchens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Kitchens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ExportTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ExportTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExportTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Designations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Designations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Designations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Currencies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Currencies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Countries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Countries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Calendars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Calendars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Calendars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Areas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Areas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Areas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ActionTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ActionTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ActionTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserIPWhitelists");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserIPWhitelists");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TextModules");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TextModules");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SupplierTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SupplierTypes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "States");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "States");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MessageModules");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MessageModules");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MenuModules");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MenuModules");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Kitchens");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Kitchens");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ActionTypes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Users",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserIPWhitelists",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "UserIPWhitelists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "UserIPWhitelists",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TextModules",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "TextModules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "TextModules",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Tenants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tenants",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tables",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Tables",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "Tables",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Tables",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SupplierTypes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "SupplierTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "SupplierTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Suppliers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Submodules",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Submodules",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "StatusTypes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "StatusTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "States",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "States",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "States",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "States",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Solutions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Solutions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "Solutions",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Solutions",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Salesmen",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Salesmen",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "Salesmen",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Salesmen",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Roles",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Riders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Riders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "Riders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Riders",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "OrderTypes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "OrderTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "OrderTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "OrderTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MessageModules",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "MessageModules",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MenuModules",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "MenuModules",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MainModules",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "MainModules",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Languages",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Kitchens",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Kitchens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "Kitchens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Kitchens",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ExportTypes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "ExportTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Designations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Designations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "Designations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Designations",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Departments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Currencies",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Currencies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "Currencies",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Currencies",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Countries",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "DialingCode",
                table: "Countries",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Countries",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Calendars",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Calendars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "Calendars",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Calendars",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Areas",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Areas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "Areas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Areas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ActionTypes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "ActionTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_LanguageId",
                table: "Users",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StatusTypeId",
                table: "Users",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIPWhitelists_LanguageId",
                table: "UserIPWhitelists",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIPWhitelists_StatusTypeId",
                table: "UserIPWhitelists",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TextModules_LanguageId",
                table: "TextModules",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TextModules_MenuModuleId",
                table: "TextModules",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_LanguageId",
                table: "Tables",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_MenuModuleId",
                table: "Tables",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_StatusTypeId",
                table: "Tables",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTypes_MenuModuleId",
                table: "SupplierTypes",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTypes_StatusTypeId",
                table: "SupplierTypes",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_LanguageId",
                table: "Suppliers",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_MenuModuleId",
                table: "Suppliers",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_StatusTypeId",
                table: "Suppliers",
                column: "StatusTypeId");

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
                name: "IX_States_MenuModuleId",
                table: "States",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_States_StatusTypeId",
                table: "States",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_LanguageId",
                table: "Solutions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_MenuModuleId",
                table: "Solutions",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_StatusTypeId",
                table: "Solutions",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Salesmen_LanguageId",
                table: "Salesmen",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Salesmen_MenuModuleId",
                table: "Salesmen",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Salesmen_StatusTypeId",
                table: "Salesmen",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_LanguageId",
                table: "Roles",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_StatusTypeId",
                table: "Roles",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Riders_LanguageId",
                table: "Riders",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Riders_MenuModuleId",
                table: "Riders",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Riders_StatusTypeId",
                table: "Riders",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTypes_LanguageId",
                table: "OrderTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTypes_MenuModuleId",
                table: "OrderTypes",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTypes_StatusTypeId",
                table: "OrderTypes",
                column: "StatusTypeId");

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
                name: "IX_Kitchens_MenuModuleId",
                table: "Kitchens",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitchens_StatusTypeId",
                table: "Kitchens",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportTypes_LanguageId",
                table: "ExportTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_LanguageId",
                table: "Designations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_MenuModuleId",
                table: "Designations",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_StatusTypeId",
                table: "Designations",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_LanguageId",
                table: "Departments",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_MenuModuleId",
                table: "Departments",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_StatusTypeId",
                table: "Departments",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_LanguageId",
                table: "Currencies",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_MenuModuleId",
                table: "Currencies",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_StatusTypeId",
                table: "Currencies",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_LanguageId",
                table: "Countries",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_MenuModuleId",
                table: "Countries",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_StatusTypeId",
                table: "Countries",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_LanguageId",
                table: "Cities",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_MenuModuleId",
                table: "Cities",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StatusTypeId",
                table: "Cities",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_LanguageId",
                table: "Calendars",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_MenuModuleId",
                table: "Calendars",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_StatusTypeId",
                table: "Calendars",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_LanguageId",
                table: "Areas",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_MenuModuleId",
                table: "Areas",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_StatusTypeId",
                table: "Areas",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypes_LanguageId",
                table: "ActionTypes",
                column: "LanguageId");

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
                name: "FK_Areas_MenuModules_MenuModuleId",
                table: "Areas",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_StatusTypes_StatusTypeId",
                table: "Areas",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_Languages_LanguageId",
                table: "Calendars",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_MenuModules_MenuModuleId",
                table: "Calendars",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_StatusTypes_StatusTypeId",
                table: "Calendars",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Languages_LanguageId",
                table: "Cities",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_MenuModules_MenuModuleId",
                table: "Cities",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_StatusTypes_StatusTypeId",
                table: "Cities",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Languages_LanguageId",
                table: "Countries",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_MenuModules_MenuModuleId",
                table: "Countries",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_StatusTypes_StatusTypeId",
                table: "Countries",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_Languages_LanguageId",
                table: "Currencies",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_MenuModules_MenuModuleId",
                table: "Currencies",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_StatusTypes_StatusTypeId",
                table: "Currencies",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Languages_LanguageId",
                table: "Departments",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_MenuModules_MenuModuleId",
                table: "Departments",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_StatusTypes_StatusTypeId",
                table: "Departments",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_Languages_LanguageId",
                table: "Designations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_MenuModules_MenuModuleId",
                table: "Designations",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_StatusTypes_StatusTypeId",
                table: "Designations",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
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
                name: "FK_Kitchens_MenuModules_MenuModuleId",
                table: "Kitchens",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitchens_StatusTypes_StatusTypeId",
                table: "Kitchens",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
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
                name: "FK_OrderTypes_MenuModules_MenuModuleId",
                table: "OrderTypes",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTypes_StatusTypes_StatusTypeId",
                table: "OrderTypes",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Riders_Languages_LanguageId",
                table: "Riders",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Riders_MenuModules_MenuModuleId",
                table: "Riders",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Riders_StatusTypes_StatusTypeId",
                table: "Riders",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Languages_LanguageId",
                table: "Roles",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_StatusTypes_StatusTypeId",
                table: "Roles",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Salesmen_Languages_LanguageId",
                table: "Salesmen",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Salesmen_MenuModules_MenuModuleId",
                table: "Salesmen",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Salesmen_StatusTypes_StatusTypeId",
                table: "Salesmen",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Solutions_Languages_LanguageId",
                table: "Solutions",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Solutions_MenuModules_MenuModuleId",
                table: "Solutions",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Solutions_StatusTypes_StatusTypeId",
                table: "Solutions",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Languages_LanguageId",
                table: "States",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_States_MenuModules_MenuModuleId",
                table: "States",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_States_StatusTypes_StatusTypeId",
                table: "States",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
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
                name: "FK_Suppliers_MenuModules_MenuModuleId",
                table: "Suppliers",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_StatusTypes_StatusTypeId",
                table: "Suppliers",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierTypes_MenuModules_MenuModuleId",
                table: "SupplierTypes",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierTypes_StatusTypes_StatusTypeId",
                table: "SupplierTypes",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Languages_LanguageId",
                table: "Tables",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_MenuModules_MenuModuleId",
                table: "Tables",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_StatusTypes_StatusTypeId",
                table: "Tables",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TextModules_Languages_LanguageId",
                table: "TextModules",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TextModules_MenuModules_MenuModuleId",
                table: "TextModules",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserIPWhitelists_Languages_LanguageId",
                table: "UserIPWhitelists",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserIPWhitelists_StatusTypes_StatusTypeId",
                table: "UserIPWhitelists",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Languages_LanguageId",
                table: "Users",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_StatusTypes_StatusTypeId",
                table: "Users",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");
        }
    }
}
