using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CountryModifiedA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DialCode",
                table: "CountryAudits",
                newName: "DialingCode");

            migrationBuilder.RenameColumn(
                name: "DialCode",
                table: "Countries",
                newName: "DialingCode");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "UserIPWhitelists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "UserIPWhitelistHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "UserHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "TextModules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "TextModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "TenantHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Tables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "TableHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "SupplierTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "SupplierTypeHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "SupplierHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Submodules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "SubmoduleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "StatusTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "StatusTypeHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RoleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Riders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RiderHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "OrderTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "OrderTypeHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "MessageModules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "MessageModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "MenuModules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "MenuModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "MainModules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "MainModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "LanguageHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Kitchens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "KitchenHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ExportTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ExportTypeHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Designations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "DesignationHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "DepartmentHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "CountryAudits",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Countries",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ActionTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ActionTypeHistory",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "UserIPWhitelists");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "UserIPWhitelistHistory");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "UserHistory");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "TextModules");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "TextModuleHistory");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "TenantHistory");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "TableHistory");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "SupplierTypes");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "SupplierTypeHistory");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "SupplierHistory");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "SubmoduleHistory");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "StatusTypeHistory");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "RoleHistory");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "RiderHistory");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "OrderTypeHistory");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "MessageModules");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "MessageModuleHistory");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "MenuModules");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "MenuModuleHistory");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "MainModuleHistory");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "LanguageHistory");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Kitchens");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "KitchenHistory");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ExportTypeHistory");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "DesignationHistory");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "DepartmentHistory");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ActionTypeHistory");

            migrationBuilder.RenameColumn(
                name: "DialingCode",
                table: "CountryAudits",
                newName: "DialCode");

            migrationBuilder.RenameColumn(
                name: "DialingCode",
                table: "Countries",
                newName: "DialCode");
        }
    }
}
