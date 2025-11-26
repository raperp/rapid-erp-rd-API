using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MenumoduleModd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuModuleAudits_MenuModules_MenuId",
                table: "MenuModuleAudits");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuModules_StatusTypes_StatusTypeId",
                table: "MenuModules");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuModules_Submodules_SubmoduleId",
                table: "MenuModules");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuModules_Tenants_TenantId1",
                table: "MenuModules");

            migrationBuilder.DropIndex(
                name: "IX_MenuModules_StatusTypeId",
                table: "MenuModules");

            migrationBuilder.DropIndex(
                name: "IX_MenuModules_SubmoduleId",
                table: "MenuModules");

            migrationBuilder.DropIndex(
                name: "IX_MenuModules_TenantId1",
                table: "MenuModules");

            migrationBuilder.DropIndex(
                name: "IX_MenuModuleAudits_MenuId",
                table: "MenuModuleAudits");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "MenuModules");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "MenuModules");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "MenuModules");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MenuModules");

            migrationBuilder.DropColumn(
                name: "TenantId1",
                table: "MenuModules");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "MenuModules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MenuModules",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "MenuModuleAudits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "MenuModuleAudits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuModuleAudits_MenuModuleId",
                table: "MenuModuleAudits",
                column: "MenuModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuModuleAudits_MenuModules_MenuModuleId",
                table: "MenuModuleAudits",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuModuleAudits_MenuModules_MenuModuleId",
                table: "MenuModuleAudits");

            migrationBuilder.DropIndex(
                name: "IX_MenuModuleAudits_MenuModuleId",
                table: "MenuModuleAudits");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "MenuModuleAudits");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "MenuModules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "IsDefault",
                table: "MenuModules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "MenuModules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "MenuModules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MenuModules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId1",
                table: "MenuModules",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "MenuModuleAudits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuModules_StatusTypeId",
                table: "MenuModules",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuModules_SubmoduleId",
                table: "MenuModules",
                column: "SubmoduleId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuModules_TenantId1",
                table: "MenuModules",
                column: "TenantId1");

            migrationBuilder.CreateIndex(
                name: "IX_MenuModuleAudits_MenuId",
                table: "MenuModuleAudits",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuModuleAudits_MenuModules_MenuId",
                table: "MenuModuleAudits",
                column: "MenuId",
                principalTable: "MenuModules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuModules_StatusTypes_StatusTypeId",
                table: "MenuModules",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuModules_Submodules_SubmoduleId",
                table: "MenuModules",
                column: "SubmoduleId",
                principalTable: "Submodules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuModules_Tenants_TenantId1",
                table: "MenuModules",
                column: "TenantId1",
                principalTable: "Tenants",
                principalColumn: "Id");
        }
    }
}
