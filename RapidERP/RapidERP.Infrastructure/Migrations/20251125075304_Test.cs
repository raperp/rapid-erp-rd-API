using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Menus_MenuId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Areas_StatusTypes_StatusTypeId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Menus_MenuId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_StatusTypes_StatusTypeId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Languages_LanguageId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Menus_MenuId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_StatusTypes_StatusTypeId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_StatusTypes_StatusTypeId",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Menus_MenuId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_StatusTypes_StatusTypeId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Designations_Menus_MenuId",
                table: "Designations");

            migrationBuilder.DropForeignKey(
                name: "FK_Designations_StatusTypes_StatusTypeId",
                table: "Designations");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitchens_Menus_MenuId",
                table: "Kitchens");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitchens_StatusTypes_StatusTypeId",
                table: "Kitchens");

            migrationBuilder.DropForeignKey(
                name: "FK_MainModules_Menus_MenuId",
                table: "MainModules");

            migrationBuilder.DropForeignKey(
                name: "FK_MainModules_StatusTypes_StatusTypeId",
                table: "MainModules");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_StatusTypes_StatusTypeId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTypes_Menus_MenuId",
                table: "OrderTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTypes_StatusTypes_StatusTypeId",
                table: "OrderTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Riders_Menus_MenuId",
                table: "Riders");

            migrationBuilder.DropForeignKey(
                name: "FK_Riders_StatusTypes_StatusTypeId",
                table: "Riders");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Menus_MenuId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_StatusTypes_StatusTypeId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Salesmen_Menus_MenuId",
                table: "Salesmen");

            migrationBuilder.DropForeignKey(
                name: "FK_Salesmen_StatusTypes_StatusTypeId",
                table: "Salesmen");

            migrationBuilder.DropForeignKey(
                name: "FK_States_StatusTypes_StatusTypeId",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusTypes_Languages_LanguageId",
                table: "StatusTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Submodules_StatusTypes_StatusTypeId",
                table: "Submodules");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Menus_MenuId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_StatusTypes_StatusTypeId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierTypes_Menus_MenuId",
                table: "SupplierTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierTypes_StatusTypes_StatusTypeId",
                table: "SupplierTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Menus_MenuId",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_StatusTypes_StatusTypeId",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Menus_MenuId",
                table: "Tenants");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_StatusTypes_StatusTypeId",
                table: "Tenants");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Menus_MenuId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_StatusTypes_StatusTypeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "SupplierTypes");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "States");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Kitchens");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "RestoredBy",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "ActionTypes");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "Users",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "Users",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "Users",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "Tenants",
                newName: "TenantId1");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "Tenants",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "Tenants",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "Tables",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "Tables",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "Tables",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "SupplierTypes",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "SupplierTypes",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "SupplierTypes",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "Suppliers",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "Suppliers",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "Suppliers",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "Submodules",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "Submodules",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "Submodules",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "StatusTypes",
                newName: "TenantId1");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "StatusTypes",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "StatusTypes",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "States",
                newName: "TenantId1");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "States",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "States",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "Salesmen",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "Salesmen",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "Salesmen",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "Roles",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "Roles",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "Roles",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "Riders",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "Riders",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "Riders",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "OrderTypes",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "OrderTypes",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "OrderTypes",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "Menus",
                newName: "TenantId1");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "Menus",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "Menus",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "MainModules",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "MainModules",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "MainModules",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "Languages",
                newName: "TenantId1");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "Languages",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "Languages",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "Kitchens",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "Kitchens",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "Kitchens",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "ExportTypes",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "ExportTypes",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "ExportTypes",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "Designations",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "Designations",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "Designations",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "Departments",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "Departments",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "Departments",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "Currencies",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "Currencies",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "Currencies",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "Countries",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "Countries",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "Cities",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "Cities",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "Cities",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "Areas",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "Areas",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "Areas",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedBy",
                table: "ActionTypes",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "SoftDeletedAt",
                table: "ActionTypes",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "RestoredBy",
                table: "ActionTypes",
                newName: "DeletedBy");

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "UserAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "UserAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "UserAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "UserAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "UserAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Tenants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Tenants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Tenants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Tenants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Tenants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Tenants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "TenantAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "TenantAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "TenantAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "TenantAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Tables",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Tables",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Tables",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Tables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Tables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "TableAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "TableAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "TableAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "TableAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "TableAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "SupplierTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "SupplierTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "SupplierTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "SupplierTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "SupplierTypeAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "SupplierTypeAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "SupplierTypeAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "SupplierTypeAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Suppliers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Suppliers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Suppliers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Suppliers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "SupplierAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "SupplierAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "SupplierAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "SupplierAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "SupplierAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Submodules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Submodules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Submodules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Submodules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Submodules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "SubmoduleAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "SubmoduleAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "SubmoduleAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "SubmoduleAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "SubmoduleAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "StatusTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "StatusTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "StatusTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "StatusTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "StatusTypeAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "StatusTypeAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "StatusTypeAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "StatusTypeAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "States",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "States",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "States",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "StateAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "StateAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "StateAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Salesmen",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Salesmen",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Salesmen",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Salesmen",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Salesmen",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "SalesmanAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "SalesmanAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "SalesmanAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "SalesmanAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "SalesmanAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Roles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Roles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "RoleAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "RoleAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "RoleAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "RoleAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "RoleAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Riders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Riders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Riders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Riders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Riders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "RiderAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "RiderAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "RiderAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "RiderAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "RiderAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "OrderTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "OrderTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "OrderTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "OrderTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "OrderTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "OrderTypeAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "OrderTypeAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "OrderTypeAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "OrderTypeAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "OrderTypeAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Menus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Menus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Menus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Menus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Menus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "MenuAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "MenuAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "MenuAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MenuAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "MainModules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "MainModules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "MainModules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "MainModules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "MainModuleAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "MainModuleAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "MainModuleAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MainModuleAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Languages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Languages",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "LanguageAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "LanguageAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "LanguageAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "LanguageAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Kitchens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Kitchens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Kitchens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Kitchens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Kitchens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "KitchenAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "KitchenAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "KitchenAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "KitchenAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "KitchenAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "ExportTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "ExportTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "ExportTypeAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "ExportTypeAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "ExportTypeAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "ExportTypeAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Designations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Designations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Designations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Designations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Designations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "DesignationAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "DesignationAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "DesignationAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "DesignationAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "DesignationAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "DepartmentAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "DepartmentAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "DepartmentAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "DepartmentAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "DepartmentAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "CurrencyAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "CurrencyAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "CurrencyAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Currencies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Currencies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "CountryAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "CountryAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Countries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Countries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "Countries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Countries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "CityAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "CityAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "CityAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "CityAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "CityAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Cities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Cities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Areas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Areas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Areas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Areas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Areas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "AreaAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "AreaAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "AreaAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "AreaAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "AreaAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "ActionTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "ActionTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "ActionTypeAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "ActionTypeAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "ActionTypeAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "ActionTypeAudits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_LanguageId",
                table: "Users",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TenantId",
                table: "Users",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_LanguageId",
                table: "Tenants",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_TenantId1",
                table: "Tenants",
                column: "TenantId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_LanguageId",
                table: "Tables",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_TenantId",
                table: "Tables",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTypes_TenantId",
                table: "SupplierTypes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_LanguageId",
                table: "Suppliers",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_TenantId",
                table: "Suppliers",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Submodules_LanguageId",
                table: "Submodules",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Submodules_TenantId",
                table: "Submodules",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTypes_TenantId1",
                table: "StatusTypes",
                column: "TenantId1");

            migrationBuilder.CreateIndex(
                name: "IX_States_TenantId1",
                table: "States",
                column: "TenantId1");

            migrationBuilder.CreateIndex(
                name: "IX_Salesmen_LanguageId",
                table: "Salesmen",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Salesmen_TenantId",
                table: "Salesmen",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_LanguageId",
                table: "Roles",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_TenantId",
                table: "Roles",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Riders_LanguageId",
                table: "Riders",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Riders_TenantId",
                table: "Riders",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTypes_LanguageId",
                table: "OrderTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTypes_TenantId",
                table: "OrderTypes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_LanguageId",
                table: "Menus",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_TenantId1",
                table: "Menus",
                column: "TenantId1");

            migrationBuilder.CreateIndex(
                name: "IX_MainModules_TenantId",
                table: "MainModules",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_LanguageId1",
                table: "Languages",
                column: "LanguageId1");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_TenantId1",
                table: "Languages",
                column: "TenantId1");

            migrationBuilder.CreateIndex(
                name: "IX_Kitchens_LanguageId",
                table: "Kitchens",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitchens_TenantId",
                table: "Kitchens",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportTypes_LanguageId",
                table: "ExportTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportTypes_TenantId",
                table: "ExportTypes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_LanguageId",
                table: "Designations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_TenantId",
                table: "Designations",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_LanguageId",
                table: "Departments",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_TenantId",
                table: "Departments",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_TenantId",
                table: "Currencies",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_TenantId",
                table: "Countries",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_LanguageId",
                table: "Cities",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_TenantId",
                table: "Cities",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_LanguageId",
                table: "Areas",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_TenantId",
                table: "Areas",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypes_TenantId",
                table: "ActionTypes",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionTypes_Tenants_TenantId",
                table: "ActionTypes",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Languages_LanguageId",
                table: "Areas",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Menus_MenuId",
                table: "Areas",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_StatusTypes_StatusTypeId",
                table: "Areas",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Tenants_TenantId",
                table: "Areas",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Languages_LanguageId",
                table: "Cities",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Menus_MenuId",
                table: "Cities",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_StatusTypes_StatusTypeId",
                table: "Cities",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Tenants_TenantId",
                table: "Cities",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Languages_LanguageId",
                table: "Countries",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Menus_MenuId",
                table: "Countries",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_StatusTypes_StatusTypeId",
                table: "Countries",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Tenants_TenantId",
                table: "Countries",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_StatusTypes_StatusTypeId",
                table: "Currencies",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_Tenants_TenantId",
                table: "Currencies",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Languages_LanguageId",
                table: "Departments",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Menus_MenuId",
                table: "Departments",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_StatusTypes_StatusTypeId",
                table: "Departments",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Tenants_TenantId",
                table: "Departments",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_Languages_LanguageId",
                table: "Designations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_Menus_MenuId",
                table: "Designations",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_StatusTypes_StatusTypeId",
                table: "Designations",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_Tenants_TenantId",
                table: "Designations",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportTypes_Languages_LanguageId",
                table: "ExportTypes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportTypes_Tenants_TenantId",
                table: "ExportTypes",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitchens_Languages_LanguageId",
                table: "Kitchens",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitchens_Menus_MenuId",
                table: "Kitchens",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitchens_StatusTypes_StatusTypeId",
                table: "Kitchens",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitchens_Tenants_TenantId",
                table: "Kitchens",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Languages_LanguageId1",
                table: "Languages",
                column: "LanguageId1",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Tenants_TenantId1",
                table: "Languages",
                column: "TenantId1",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MainModules_Menus_MenuId",
                table: "MainModules",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MainModules_StatusTypes_StatusTypeId",
                table: "MainModules",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MainModules_Tenants_TenantId",
                table: "MainModules",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Languages_LanguageId",
                table: "Menus",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_StatusTypes_StatusTypeId",
                table: "Menus",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Tenants_TenantId1",
                table: "Menus",
                column: "TenantId1",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTypes_Languages_LanguageId",
                table: "OrderTypes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTypes_Menus_MenuId",
                table: "OrderTypes",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTypes_StatusTypes_StatusTypeId",
                table: "OrderTypes",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTypes_Tenants_TenantId",
                table: "OrderTypes",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Riders_Languages_LanguageId",
                table: "Riders",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Riders_Menus_MenuId",
                table: "Riders",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Riders_StatusTypes_StatusTypeId",
                table: "Riders",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Riders_Tenants_TenantId",
                table: "Riders",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Languages_LanguageId",
                table: "Roles",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Menus_MenuId",
                table: "Roles",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_StatusTypes_StatusTypeId",
                table: "Roles",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Tenants_TenantId",
                table: "Roles",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Salesmen_Languages_LanguageId",
                table: "Salesmen",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Salesmen_Menus_MenuId",
                table: "Salesmen",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Salesmen_StatusTypes_StatusTypeId",
                table: "Salesmen",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Salesmen_Tenants_TenantId",
                table: "Salesmen",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_States_StatusTypes_StatusTypeId",
                table: "States",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Tenants_TenantId1",
                table: "States",
                column: "TenantId1",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusTypes_Languages_LanguageId",
                table: "StatusTypes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusTypes_Tenants_TenantId1",
                table: "StatusTypes",
                column: "TenantId1",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Submodules_Languages_LanguageId",
                table: "Submodules",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Submodules_StatusTypes_StatusTypeId",
                table: "Submodules",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Submodules_Tenants_TenantId",
                table: "Submodules",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Languages_LanguageId",
                table: "Suppliers",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Menus_MenuId",
                table: "Suppliers",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_StatusTypes_StatusTypeId",
                table: "Suppliers",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Tenants_TenantId",
                table: "Suppliers",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierTypes_Menus_MenuId",
                table: "SupplierTypes",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierTypes_StatusTypes_StatusTypeId",
                table: "SupplierTypes",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierTypes_Tenants_TenantId",
                table: "SupplierTypes",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Languages_LanguageId",
                table: "Tables",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Menus_MenuId",
                table: "Tables",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_StatusTypes_StatusTypeId",
                table: "Tables",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Tenants_TenantId",
                table: "Tables",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Languages_LanguageId",
                table: "Tenants",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Menus_MenuId",
                table: "Tenants",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_StatusTypes_StatusTypeId",
                table: "Tenants",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Tenants_TenantId1",
                table: "Tenants",
                column: "TenantId1",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Languages_LanguageId",
                table: "Users",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Menus_MenuId",
                table: "Users",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_StatusTypes_StatusTypeId",
                table: "Users",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Tenants_TenantId",
                table: "Users",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionTypes_Tenants_TenantId",
                table: "ActionTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Languages_LanguageId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Menus_MenuId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Areas_StatusTypes_StatusTypeId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Tenants_TenantId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Languages_LanguageId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Menus_MenuId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_StatusTypes_StatusTypeId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Tenants_TenantId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Languages_LanguageId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Menus_MenuId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_StatusTypes_StatusTypeId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Tenants_TenantId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_StatusTypes_StatusTypeId",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_Tenants_TenantId",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Languages_LanguageId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Menus_MenuId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_StatusTypes_StatusTypeId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Tenants_TenantId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Designations_Languages_LanguageId",
                table: "Designations");

            migrationBuilder.DropForeignKey(
                name: "FK_Designations_Menus_MenuId",
                table: "Designations");

            migrationBuilder.DropForeignKey(
                name: "FK_Designations_StatusTypes_StatusTypeId",
                table: "Designations");

            migrationBuilder.DropForeignKey(
                name: "FK_Designations_Tenants_TenantId",
                table: "Designations");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportTypes_Languages_LanguageId",
                table: "ExportTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportTypes_Tenants_TenantId",
                table: "ExportTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitchens_Languages_LanguageId",
                table: "Kitchens");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitchens_Menus_MenuId",
                table: "Kitchens");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitchens_StatusTypes_StatusTypeId",
                table: "Kitchens");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitchens_Tenants_TenantId",
                table: "Kitchens");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Languages_LanguageId1",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Tenants_TenantId1",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_MainModules_Menus_MenuId",
                table: "MainModules");

            migrationBuilder.DropForeignKey(
                name: "FK_MainModules_StatusTypes_StatusTypeId",
                table: "MainModules");

            migrationBuilder.DropForeignKey(
                name: "FK_MainModules_Tenants_TenantId",
                table: "MainModules");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Languages_LanguageId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_StatusTypes_StatusTypeId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Tenants_TenantId1",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTypes_Languages_LanguageId",
                table: "OrderTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTypes_Menus_MenuId",
                table: "OrderTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTypes_StatusTypes_StatusTypeId",
                table: "OrderTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTypes_Tenants_TenantId",
                table: "OrderTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Riders_Languages_LanguageId",
                table: "Riders");

            migrationBuilder.DropForeignKey(
                name: "FK_Riders_Menus_MenuId",
                table: "Riders");

            migrationBuilder.DropForeignKey(
                name: "FK_Riders_StatusTypes_StatusTypeId",
                table: "Riders");

            migrationBuilder.DropForeignKey(
                name: "FK_Riders_Tenants_TenantId",
                table: "Riders");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Languages_LanguageId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Menus_MenuId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_StatusTypes_StatusTypeId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Tenants_TenantId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Salesmen_Languages_LanguageId",
                table: "Salesmen");

            migrationBuilder.DropForeignKey(
                name: "FK_Salesmen_Menus_MenuId",
                table: "Salesmen");

            migrationBuilder.DropForeignKey(
                name: "FK_Salesmen_StatusTypes_StatusTypeId",
                table: "Salesmen");

            migrationBuilder.DropForeignKey(
                name: "FK_Salesmen_Tenants_TenantId",
                table: "Salesmen");

            migrationBuilder.DropForeignKey(
                name: "FK_States_StatusTypes_StatusTypeId",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Tenants_TenantId1",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusTypes_Languages_LanguageId",
                table: "StatusTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusTypes_Tenants_TenantId1",
                table: "StatusTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Submodules_Languages_LanguageId",
                table: "Submodules");

            migrationBuilder.DropForeignKey(
                name: "FK_Submodules_StatusTypes_StatusTypeId",
                table: "Submodules");

            migrationBuilder.DropForeignKey(
                name: "FK_Submodules_Tenants_TenantId",
                table: "Submodules");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Languages_LanguageId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Menus_MenuId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_StatusTypes_StatusTypeId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Tenants_TenantId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierTypes_Menus_MenuId",
                table: "SupplierTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierTypes_StatusTypes_StatusTypeId",
                table: "SupplierTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierTypes_Tenants_TenantId",
                table: "SupplierTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Languages_LanguageId",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Menus_MenuId",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_StatusTypes_StatusTypeId",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Tenants_TenantId",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Languages_LanguageId",
                table: "Tenants");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Menus_MenuId",
                table: "Tenants");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_StatusTypes_StatusTypeId",
                table: "Tenants");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Tenants_TenantId1",
                table: "Tenants");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Languages_LanguageId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Menus_MenuId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_StatusTypes_StatusTypeId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Tenants_TenantId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_LanguageId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TenantId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_LanguageId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_TenantId1",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tables_LanguageId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_TenantId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_SupplierTypes_TenantId",
                table: "SupplierTypes");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_LanguageId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_TenantId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Submodules_LanguageId",
                table: "Submodules");

            migrationBuilder.DropIndex(
                name: "IX_Submodules_TenantId",
                table: "Submodules");

            migrationBuilder.DropIndex(
                name: "IX_StatusTypes_TenantId1",
                table: "StatusTypes");

            migrationBuilder.DropIndex(
                name: "IX_States_TenantId1",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Salesmen_LanguageId",
                table: "Salesmen");

            migrationBuilder.DropIndex(
                name: "IX_Salesmen_TenantId",
                table: "Salesmen");

            migrationBuilder.DropIndex(
                name: "IX_Roles_LanguageId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_TenantId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Riders_LanguageId",
                table: "Riders");

            migrationBuilder.DropIndex(
                name: "IX_Riders_TenantId",
                table: "Riders");

            migrationBuilder.DropIndex(
                name: "IX_OrderTypes_LanguageId",
                table: "OrderTypes");

            migrationBuilder.DropIndex(
                name: "IX_OrderTypes_TenantId",
                table: "OrderTypes");

            migrationBuilder.DropIndex(
                name: "IX_Menus_LanguageId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_TenantId1",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_MainModules_TenantId",
                table: "MainModules");

            migrationBuilder.DropIndex(
                name: "IX_Languages_LanguageId1",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_TenantId1",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Kitchens_LanguageId",
                table: "Kitchens");

            migrationBuilder.DropIndex(
                name: "IX_Kitchens_TenantId",
                table: "Kitchens");

            migrationBuilder.DropIndex(
                name: "IX_ExportTypes_LanguageId",
                table: "ExportTypes");

            migrationBuilder.DropIndex(
                name: "IX_ExportTypes_TenantId",
                table: "ExportTypes");

            migrationBuilder.DropIndex(
                name: "IX_Designations_LanguageId",
                table: "Designations");

            migrationBuilder.DropIndex(
                name: "IX_Designations_TenantId",
                table: "Designations");

            migrationBuilder.DropIndex(
                name: "IX_Departments_LanguageId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_TenantId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_TenantId",
                table: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Countries_TenantId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Cities_LanguageId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_TenantId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Areas_LanguageId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Areas_TenantId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_ActionTypes_TenantId",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "UserAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "UserAudits");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "UserAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "UserAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "UserAudits");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "TenantAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "TenantAudits");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "TenantAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "TenantAudits");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "TableAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "TableAudits");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "TableAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "TableAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "TableAudits");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "SupplierTypes");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "SupplierTypes");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "SupplierTypeAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "SupplierTypeAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "SupplierTypeAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "SupplierTypeAudits");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "SupplierAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "SupplierAudits");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "SupplierAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "SupplierAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "SupplierAudits");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "SubmoduleAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "SubmoduleAudits");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "SubmoduleAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "SubmoduleAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "SubmoduleAudits");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "StatusTypeAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "StatusTypeAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "StatusTypeAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "StatusTypeAudits");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "States");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "States");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "StateAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "StateAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "StateAudits");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "SalesmanAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "SalesmanAudits");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "SalesmanAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "SalesmanAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "SalesmanAudits");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "RoleAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "RoleAudits");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "RoleAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "RoleAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "RoleAudits");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "RiderAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "RiderAudits");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "RiderAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "RiderAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "RiderAudits");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "OrderTypeAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "OrderTypeAudits");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "OrderTypeAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "OrderTypeAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "OrderTypeAudits");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "MenuAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "MenuAudits");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "MenuAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MenuAudits");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "MainModuleAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "MainModuleAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "MainModuleAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MainModuleAudits");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "LanguageId1",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "LanguageAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "LanguageAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "LanguageAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "LanguageAudits");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Kitchens");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Kitchens");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Kitchens");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "KitchenAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "KitchenAudits");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "KitchenAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "KitchenAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "KitchenAudits");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "ExportTypeAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "ExportTypeAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "ExportTypeAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "ExportTypeAudits");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "DesignationAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "DesignationAudits");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "DesignationAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "DesignationAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "DesignationAudits");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "DepartmentAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "DepartmentAudits");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "DepartmentAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "DepartmentAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "DepartmentAudits");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "CurrencyAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "CurrencyAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "CurrencyAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "CityAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "CityAudits");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "CityAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "CityAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "CityAudits");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "AreaAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "AreaAudits");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "AreaAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "AreaAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AreaAudits");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "ActionTypeAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "ActionTypeAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "ActionTypeAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "ActionTypeAudits");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Users",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "Users",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Users",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId1",
                table: "Tenants",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Tenants",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Tenants",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Tables",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "Tables",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Tables",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "SupplierTypes",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "SupplierTypes",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "SupplierTypes",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Suppliers",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "Suppliers",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Suppliers",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Submodules",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "Submodules",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Submodules",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId1",
                table: "StatusTypes",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "StatusTypes",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "StatusTypes",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId1",
                table: "States",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "States",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "States",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Salesmen",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "Salesmen",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Salesmen",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Roles",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "Roles",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Roles",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Riders",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "Riders",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Riders",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "OrderTypes",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "OrderTypes",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "OrderTypes",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId1",
                table: "Menus",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Menus",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Menus",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "MainModules",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "MainModules",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "MainModules",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId1",
                table: "Languages",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Languages",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Languages",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Kitchens",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "Kitchens",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Kitchens",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "ExportTypes",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ExportTypes",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ExportTypes",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Designations",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "Designations",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Designations",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Departments",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "Departments",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Departments",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Currencies",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Currencies",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Currencies",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Countries",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Countries",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Cities",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "Cities",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Cities",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Areas",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "Areas",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Areas",
                newName: "SoftDeletedAt");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "ActionTypes",
                newName: "SoftDeletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ActionTypes",
                newName: "RestoredBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ActionTypes",
                newName: "SoftDeletedAt");

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Tenants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Tenants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Tenants",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Tables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Tables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Tables",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "SupplierTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "SupplierTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "SupplierTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Suppliers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Submodules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Submodules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Submodules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "StatusTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "StatusTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "States",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "States",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Salesmen",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Salesmen",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Salesmen",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Riders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Riders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Riders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "OrderTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "OrderTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "OrderTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Menus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "MainModules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "MainModules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "MainModules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Languages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Kitchens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Kitchens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Kitchens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "ExportTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Designations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Designations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Designations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Departments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Currencies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Currencies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Countries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestoredBy",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Cities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTypeId",
                table: "Areas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Areas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Areas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "ActionTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Menus_MenuId",
                table: "Areas",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_StatusTypes_StatusTypeId",
                table: "Areas",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Menus_MenuId",
                table: "Cities",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_StatusTypes_StatusTypeId",
                table: "Cities",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Languages_LanguageId",
                table: "Countries",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Menus_MenuId",
                table: "Countries",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_StatusTypes_StatusTypeId",
                table: "Countries",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_StatusTypes_StatusTypeId",
                table: "Currencies",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Menus_MenuId",
                table: "Departments",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_StatusTypes_StatusTypeId",
                table: "Departments",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_Menus_MenuId",
                table: "Designations",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_StatusTypes_StatusTypeId",
                table: "Designations",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kitchens_Menus_MenuId",
                table: "Kitchens",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kitchens_StatusTypes_StatusTypeId",
                table: "Kitchens",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MainModules_Menus_MenuId",
                table: "MainModules",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MainModules_StatusTypes_StatusTypeId",
                table: "MainModules",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_StatusTypes_StatusTypeId",
                table: "Menus",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTypes_Menus_MenuId",
                table: "OrderTypes",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTypes_StatusTypes_StatusTypeId",
                table: "OrderTypes",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Riders_Menus_MenuId",
                table: "Riders",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Riders_StatusTypes_StatusTypeId",
                table: "Riders",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Menus_MenuId",
                table: "Roles",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_StatusTypes_StatusTypeId",
                table: "Roles",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salesmen_Menus_MenuId",
                table: "Salesmen",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salesmen_StatusTypes_StatusTypeId",
                table: "Salesmen",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_States_StatusTypes_StatusTypeId",
                table: "States",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatusTypes_Languages_LanguageId",
                table: "StatusTypes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Submodules_StatusTypes_StatusTypeId",
                table: "Submodules",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Menus_MenuId",
                table: "Suppliers",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_StatusTypes_StatusTypeId",
                table: "Suppliers",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierTypes_Menus_MenuId",
                table: "SupplierTypes",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierTypes_StatusTypes_StatusTypeId",
                table: "SupplierTypes",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Menus_MenuId",
                table: "Tables",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_StatusTypes_StatusTypeId",
                table: "Tables",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Menus_MenuId",
                table: "Tenants",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_StatusTypes_StatusTypeId",
                table: "Tenants",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Menus_MenuId",
                table: "Users",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_StatusTypes_StatusTypeId",
                table: "Users",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
