using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ActionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionTypes_StatusTypes_StatusTypeId",
                table: "ActionTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionTypes_Tenants_TenantId",
                table: "ActionTypes");

            migrationBuilder.DropIndex(
                name: "IX_ActionTypes_StatusTypeId",
                table: "ActionTypes");

            migrationBuilder.DropIndex(
                name: "IX_ActionTypes_TenantId",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "ActionTypeId",
                table: "ActionTypeAudits");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "ActionTypeAudits");

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
                name: "SourceURL",
                table: "ActionTypeAudits");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "ActionTypeAudits",
                newName: "ActionTypeId1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ActionTypes",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "ActionTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ActionTypes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ActionTypeAudits",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypeAudits_ActionTypeId1",
                table: "ActionTypeAudits",
                column: "ActionTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypeAudits_LanguageId",
                table: "ActionTypeAudits",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionTypeAudits_ActionTypes_ActionTypeId1",
                table: "ActionTypeAudits",
                column: "ActionTypeId1",
                principalTable: "ActionTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionTypeAudits_Languages_LanguageId",
                table: "ActionTypeAudits",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionTypeAudits_ActionTypes_ActionTypeId1",
                table: "ActionTypeAudits");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionTypeAudits_Languages_LanguageId",
                table: "ActionTypeAudits");

            migrationBuilder.DropIndex(
                name: "IX_ActionTypeAudits_ActionTypeId1",
                table: "ActionTypeAudits");

            migrationBuilder.DropIndex(
                name: "IX_ActionTypeAudits_LanguageId",
                table: "ActionTypeAudits");

            migrationBuilder.RenameColumn(
                name: "ActionTypeId1",
                table: "ActionTypeAudits",
                newName: "TenantId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ActionTypes",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "ActionTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "ActionTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "ActionTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ActionTypeAudits",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AddColumn<int>(
                name: "ActionTypeId",
                table: "ActionTypeAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "ActionTypeAudits",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "ActionTypeAudits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypes_StatusTypeId",
                table: "ActionTypes",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypes_TenantId",
                table: "ActionTypes",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionTypes_StatusTypes_StatusTypeId",
                table: "ActionTypes",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionTypes_Tenants_TenantId",
                table: "ActionTypes",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");
        }
    }
}
