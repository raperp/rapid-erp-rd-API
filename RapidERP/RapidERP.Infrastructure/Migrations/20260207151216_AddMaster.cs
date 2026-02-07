using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryActivities");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "UserIPWhitelistHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "UserIPWhitelistHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "UserIPWhitelistHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "UserHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "UserHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "UserHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "TextModuleHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "TextModuleHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "TextModuleHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "TenantHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "TenantHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "TenantHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "TableHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "TableHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "TableHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "SupplierTypeHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "SupplierTypeHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "SupplierTypeHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "SupplierHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "SupplierHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "SupplierHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "SubmoduleHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "SubmoduleHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "SubmoduleHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "StatusTypeHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "StatusTypeHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "StatusTypeHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "StateHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "StateHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "StateHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "SolutionHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "SolutionHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "SolutionHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "SalesmanHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "SalesmanHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "SalesmanHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "RoleHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "RoleHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "RoleHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "RiderHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "RiderHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "RiderHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "OrderTypeHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "OrderTypeHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "OrderTypeHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "MessageModuleHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "MessageModuleHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "MessageModuleHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "MenuModuleHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "MenuModuleHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "MenuModuleHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "MainModuleHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "MainModuleHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "MainModuleHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "KitchenHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "KitchenHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "KitchenHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "DesignationHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "DesignationHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "DesignationHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "DepartmentHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "DepartmentHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "DepartmentHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "CurrencyHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "CurrencyHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "CurrencyHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "CityHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "CityHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "CityHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "CalendarHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "CalendarHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "CalendarHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "AreaHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "AreaHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "AreaHistory");

            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "ActionTypeHistory");

            migrationBuilder.DropColumn(
                name: "ExportTypeId",
                table: "ActionTypeHistory");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "ActionTypeHistory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "UserIPWhitelistHistory",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "UserIPWhitelistHistory",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "UserIPWhitelistHistory",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "UserHistory",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 12);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "UserHistory",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "UserHistory",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 13);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "TextModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "TextModuleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "TextModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "TenantHistory",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "TenantHistory",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "TenantHistory",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "TableHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "TableHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "TableHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "SupplierTypeHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "SupplierTypeHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "SupplierTypeHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "SupplierHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "SupplierHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "SupplierHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "SubmoduleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "SubmoduleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "SubmoduleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "StatusTypeHistory",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "StatusTypeHistory",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "StatusTypeHistory",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "StateHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "StateHistory",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "StateHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "SolutionHistory",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "SolutionHistory",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "SolutionHistory",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "SalesmanHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "SalesmanHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "SalesmanHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "RoleHistory",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "RoleHistory",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "RoleHistory",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "RiderHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "RiderHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "RiderHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "OrderTypeHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "OrderTypeHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "OrderTypeHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "MessageModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "MessageModuleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "MessageModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "MenuModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "MenuModuleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "MenuModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "MainModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "MainModuleHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "MainModuleHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "KitchenHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "KitchenHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "KitchenHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "DesignationHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "DesignationHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "DesignationHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "DepartmentHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "DepartmentHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "DepartmentHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "CurrencyHistory",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "CurrencyHistory",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "CurrencyHistory",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "CountryAudits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "CountryAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "CountryAudits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "CityHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "CityHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "CityHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "CalendarHistory",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "CalendarHistory",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "CalendarHistory",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "AreaHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "AreaHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "AreaHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "ActionTypeHistory",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AddColumn<int>(
                name: "ExportTypeId",
                table: "ActionTypeHistory",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "ActionTypeHistory",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.CreateTable(
                name: "CountryActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ActivityTypeId = table.Column<int>(type: "int", nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LocationURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    OS = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PageViewEndedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PageViewStartedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryActivities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryActivities_CountryId",
                table: "CountryActivities",
                column: "CountryId");
        }
    }
}
