using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SubMOd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submodules_Menus_MenuId",
                table: "Submodules");

            migrationBuilder.DropForeignKey(
                name: "FK_Submodules_StatusTypes_StatusTypeId",
                table: "Submodules");

            migrationBuilder.DropForeignKey(
                name: "FK_Submodules_Tenants_TenantId",
                table: "Submodules");

            migrationBuilder.DropIndex(
                name: "IX_Submodules_MenuId",
                table: "Submodules");

            migrationBuilder.DropIndex(
                name: "IX_Submodules_StatusTypeId",
                table: "Submodules");

            migrationBuilder.DropIndex(
                name: "IX_Submodules_TenantId",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "Prefix",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "SubmoduleAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "SubmoduleAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "SubmoduleAudits");

            migrationBuilder.DropColumn(
                name: "Prefix",
                table: "SubmoduleAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "SubmoduleAudits");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Submodules",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Submodules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Submodules",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "IconURL",
                table: "Submodules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SetSerial",
                table: "Submodules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubmoduleAudits",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AddColumn<string>(
                name: "IconURL",
                table: "SubmoduleAudits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SetSerial",
                table: "SubmoduleAudits",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconURL",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "SetSerial",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "IconURL",
                table: "SubmoduleAudits");

            migrationBuilder.DropColumn(
                name: "SetSerial",
                table: "SubmoduleAudits");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Submodules",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Submodules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Submodules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prefix",
                table: "Submodules",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Submodules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Submodules",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubmoduleAudits",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

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
                name: "MenuId",
                table: "SubmoduleAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prefix",
                table: "SubmoduleAudits",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "SubmoduleAudits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Submodules_MenuId",
                table: "Submodules",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Submodules_StatusTypeId",
                table: "Submodules",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Submodules_TenantId",
                table: "Submodules",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Submodules_Menus_MenuId",
                table: "Submodules",
                column: "MenuId",
                principalTable: "Menus",
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
        }
    }
}
