using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Exprt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportTypes_Tenants_TenantId",
                table: "ExportTypes");

            migrationBuilder.DropIndex(
                name: "IX_ExportTypes_TenantId",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "ExportTypeAudits");

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
                name: "SourceURL",
                table: "ExportTypeAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "ExportTypeAudits");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "ExportTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ExportTypes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "ExportTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ExportTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "ExportTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "ExportTypeAudits",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "ExportTypeAudits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "ExportTypeAudits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExportTypes_TenantId",
                table: "ExportTypes",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportTypes_Tenants_TenantId",
                table: "ExportTypes",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");
        }
    }
}
