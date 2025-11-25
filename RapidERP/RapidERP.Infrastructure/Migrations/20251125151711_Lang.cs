using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Lang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Languages_LanguageId1",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Tenants_TenantId1",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_LanguageId1",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_TenantId1",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "LanguageId1",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "TenantId1",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "LanguageAudits");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "LanguageAudits");

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
                name: "SourceURL",
                table: "LanguageAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "LanguageAudits");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "Languages",
                newName: "IconURL");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "LanguageAudits",
                newName: "IconURL");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Languages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Languages",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IconURL",
                table: "Languages",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "IconURL",
                table: "LanguageAudits",
                newName: "Icon");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Languages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Languages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId1",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "LanguageAudits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "LanguageAudits",
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

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "LanguageAudits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "LanguageAudits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_LanguageId1",
                table: "Languages",
                column: "LanguageId1");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_TenantId1",
                table: "Languages",
                column: "TenantId1");

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
        }
    }
}
