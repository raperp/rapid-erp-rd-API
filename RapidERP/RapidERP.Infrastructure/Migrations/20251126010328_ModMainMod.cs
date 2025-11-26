using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModMainMod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainModules_Languages_LanguageId",
                table: "MainModules");

            migrationBuilder.DropForeignKey(
                name: "FK_MainModules_Menus_MenuId",
                table: "MainModules");

            migrationBuilder.DropForeignKey(
                name: "FK_MainModules_StatusTypes_StatusTypeId",
                table: "MainModules");

            migrationBuilder.DropForeignKey(
                name: "FK_MainModules_Tenants_TenantId",
                table: "MainModules");

            migrationBuilder.DropIndex(
                name: "IX_MainModules_MenuId",
                table: "MainModules");

            migrationBuilder.DropIndex(
                name: "IX_MainModules_StatusTypeId",
                table: "MainModules");

            migrationBuilder.DropIndex(
                name: "IX_MainModules_TenantId",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "TenantId",
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

            migrationBuilder.AlterColumn<string>(
                name: "Prefix",
                table: "MainModules",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MainModules",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "MainModules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "IconURL",
                table: "MainModules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "MainModules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MainModules",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "SetSerial",
                table: "MainModules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Prefix",
                table: "MainModuleAudits",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MainModuleAudits",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "IconURL",
                table: "MainModuleAudits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SetSerial",
                table: "MainModuleAudits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MainModules_Languages_LanguageId",
                table: "MainModules",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainModules_Languages_LanguageId",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "SetSerial",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "SetSerial",
                table: "MainModuleAudits");

            migrationBuilder.AlterColumn<string>(
                name: "Prefix",
                table: "MainModules",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MainModules",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "MainModules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IconURL",
                table: "MainModules",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "MainModules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MainModules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "MainModules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "MainModules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MainModules",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Prefix",
                table: "MainModuleAudits",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MainModuleAudits",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "IconURL",
                table: "MainModuleAudits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateIndex(
                name: "IX_MainModules_MenuId",
                table: "MainModules",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MainModules_StatusTypeId",
                table: "MainModules",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MainModules_TenantId",
                table: "MainModules",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainModules_Languages_LanguageId",
                table: "MainModules",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
        }
    }
}
