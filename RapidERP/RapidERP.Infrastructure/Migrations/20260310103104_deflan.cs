using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deflan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "UserIPWhitelists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "UserIPWhitelists",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "TextModules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "TextModules",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "Tenants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Tenants",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "Tables",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Tables",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "SupplierTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "SupplierTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Suppliers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "Submodules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Submodules",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "States",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "States",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "Solutions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Solutions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "Salesmen",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Salesmen",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Roles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "Riders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Riders",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "OrderTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "OrderTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "MessageModules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "MessageModules",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "MenuModules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "MenuModules",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "MainModules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "MainModules",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "Kitchens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Kitchens",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "Designations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Designations",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Departments",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "Currencies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Currencies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Countries",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Cities",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "Calendars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Calendars",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "Areas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Areas",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "UserIPWhitelists");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "UserIPWhitelists");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "TextModules");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "TextModules");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "SupplierTypes");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "SupplierTypes");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "States");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "MessageModules");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "MessageModules");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "MenuModules");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "MenuModules");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "Kitchens");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Kitchens");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Areas");
        }
    }
}
