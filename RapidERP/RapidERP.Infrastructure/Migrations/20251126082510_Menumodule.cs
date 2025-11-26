using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Menumodule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Menus_MenuId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Menus_MenuId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Menus_MenuId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_Menus_MenuId",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Menus_MenuId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Designations_Menus_MenuId",
                table: "Designations");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitchens_Menus_MenuId",
                table: "Kitchens");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTypes_Menus_MenuId",
                table: "OrderTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Riders_Menus_MenuId",
                table: "Riders");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Menus_MenuId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Salesmen_Menus_MenuId",
                table: "Salesmen");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Menus_MenuId",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Menus_MenuId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierTypes_Menus_MenuId",
                table: "SupplierTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Menus_MenuId",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Menus_MenuId",
                table: "Tenants");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Menus_MenuId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "MenuAudits");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_States_MenuId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_MenuId",
                table: "Currencies");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Users",
                newName: "MenuModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_MenuId",
                table: "Users",
                newName: "IX_Users_MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Tenants",
                newName: "MenuModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Tenants_MenuId",
                table: "Tenants",
                newName: "IX_Tenants_MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Tables",
                newName: "MenuModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_MenuId",
                table: "Tables",
                newName: "IX_Tables_MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "SupplierTypes",
                newName: "MenuModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierTypes_MenuId",
                table: "SupplierTypes",
                newName: "IX_SupplierTypes_MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Suppliers",
                newName: "MenuModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Suppliers_MenuId",
                table: "Suppliers",
                newName: "IX_Suppliers_MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Salesmen",
                newName: "MenuModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Salesmen_MenuId",
                table: "Salesmen",
                newName: "IX_Salesmen_MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Roles",
                newName: "MenuModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_MenuId",
                table: "Roles",
                newName: "IX_Roles_MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Riders",
                newName: "MenuModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Riders_MenuId",
                table: "Riders",
                newName: "IX_Riders_MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "OrderTypes",
                newName: "MenuModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderTypes_MenuId",
                table: "OrderTypes",
                newName: "IX_OrderTypes_MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Kitchens",
                newName: "MenuModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Kitchens_MenuId",
                table: "Kitchens",
                newName: "IX_Kitchens_MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Designations",
                newName: "MenuModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Designations_MenuId",
                table: "Designations",
                newName: "IX_Designations_MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Departments",
                newName: "MenuModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_MenuId",
                table: "Departments",
                newName: "IX_Departments_MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Countries",
                newName: "MenuModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Countries_MenuId",
                table: "Countries",
                newName: "IX_Countries_MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Cities",
                newName: "MenuModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_MenuId",
                table: "Cities",
                newName: "IX_Cities_MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Areas",
                newName: "MenuModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Areas_MenuId",
                table: "Areas",
                newName: "IX_Areas_MenuModuleId");

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "States",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "Currencies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MenuModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmoduleId = table.Column<int>(type: "int", nullable: true),
                    IconURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SetSerial = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenantId1 = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    StatusTypeId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDraft = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuModules_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MenuModules_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MenuModules_Submodules_SubmoduleId",
                        column: x => x.SubmoduleId,
                        principalTable: "Submodules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MenuModules_Tenants_TenantId1",
                        column: x => x.TenantId1,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MenuModuleAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    SubModuleId = table.Column<int>(type: "int", nullable: true),
                    Prefix = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    IconURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDraft = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuModuleAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuModuleAudits_MenuModules_MenuId",
                        column: x => x.MenuId,
                        principalTable: "MenuModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_States_MenuModuleId",
                table: "States",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_MenuModuleId",
                table: "Currencies",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuModuleAudits_MenuId",
                table: "MenuModuleAudits",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuModules_LanguageId",
                table: "MenuModules",
                column: "LanguageId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_MenuModules_MenuModuleId",
                table: "Areas",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_MenuModules_MenuModuleId",
                table: "Cities",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_MenuModules_MenuModuleId",
                table: "Countries",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_MenuModules_MenuModuleId",
                table: "Currencies",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_MenuModules_MenuModuleId",
                table: "Departments",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_MenuModules_MenuModuleId",
                table: "Designations",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitchens_MenuModules_MenuModuleId",
                table: "Kitchens",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTypes_MenuModules_MenuModuleId",
                table: "OrderTypes",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Riders_MenuModules_MenuModuleId",
                table: "Riders",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_MenuModules_MenuModuleId",
                table: "Roles",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Salesmen_MenuModules_MenuModuleId",
                table: "Salesmen",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_States_MenuModules_MenuModuleId",
                table: "States",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_MenuModules_MenuModuleId",
                table: "Suppliers",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierTypes_MenuModules_MenuModuleId",
                table: "SupplierTypes",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_MenuModules_MenuModuleId",
                table: "Tables",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_MenuModules_MenuModuleId",
                table: "Tenants",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MenuModules_MenuModuleId",
                table: "Users",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_MenuModules_MenuModuleId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_MenuModules_MenuModuleId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_MenuModules_MenuModuleId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_MenuModules_MenuModuleId",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_MenuModules_MenuModuleId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Designations_MenuModules_MenuModuleId",
                table: "Designations");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitchens_MenuModules_MenuModuleId",
                table: "Kitchens");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTypes_MenuModules_MenuModuleId",
                table: "OrderTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Riders_MenuModules_MenuModuleId",
                table: "Riders");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_MenuModules_MenuModuleId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Salesmen_MenuModules_MenuModuleId",
                table: "Salesmen");

            migrationBuilder.DropForeignKey(
                name: "FK_States_MenuModules_MenuModuleId",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_MenuModules_MenuModuleId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierTypes_MenuModules_MenuModuleId",
                table: "SupplierTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_MenuModules_MenuModuleId",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_MenuModules_MenuModuleId",
                table: "Tenants");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_MenuModules_MenuModuleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "MenuModuleAudits");

            migrationBuilder.DropTable(
                name: "MenuModules");

            migrationBuilder.DropIndex(
                name: "IX_States_MenuModuleId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_MenuModuleId",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "Currencies");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "Users",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_MenuModuleId",
                table: "Users",
                newName: "IX_Users_MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "Tenants",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Tenants_MenuModuleId",
                table: "Tenants",
                newName: "IX_Tenants_MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "Tables",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_MenuModuleId",
                table: "Tables",
                newName: "IX_Tables_MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "SupplierTypes",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierTypes_MenuModuleId",
                table: "SupplierTypes",
                newName: "IX_SupplierTypes_MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "Suppliers",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Suppliers_MenuModuleId",
                table: "Suppliers",
                newName: "IX_Suppliers_MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "Salesmen",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Salesmen_MenuModuleId",
                table: "Salesmen",
                newName: "IX_Salesmen_MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "Roles",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_MenuModuleId",
                table: "Roles",
                newName: "IX_Roles_MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "Riders",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Riders_MenuModuleId",
                table: "Riders",
                newName: "IX_Riders_MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "OrderTypes",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderTypes_MenuModuleId",
                table: "OrderTypes",
                newName: "IX_OrderTypes_MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "Kitchens",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Kitchens_MenuModuleId",
                table: "Kitchens",
                newName: "IX_Kitchens_MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "Designations",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Designations_MenuModuleId",
                table: "Designations",
                newName: "IX_Designations_MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "Departments",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_MenuModuleId",
                table: "Departments",
                newName: "IX_Departments_MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "Countries",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Countries_MenuModuleId",
                table: "Countries",
                newName: "IX_Countries_MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "Cities",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_MenuModuleId",
                table: "Cities",
                newName: "IX_Cities_MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "Areas",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Areas_MenuModuleId",
                table: "Areas",
                newName: "IX_Areas_MenuId");

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    StatusTypeId = table.Column<int>(type: "int", nullable: true),
                    TenantId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    IconURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDraft = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    SubmoduleId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Menus_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Menus_Tenants_TenantId1",
                        column: x => x.TenantId1,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MenuAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    IconURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDraft = table.Column<bool>(type: "bit", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubModuleId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuAudits_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_States_MenuId",
                table: "States",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_MenuId",
                table: "Currencies",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuAudits_MenuId",
                table: "MenuAudits",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_LanguageId",
                table: "Menus",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_StatusTypeId",
                table: "Menus",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_TenantId1",
                table: "Menus",
                column: "TenantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Menus_MenuId",
                table: "Areas",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Menus_MenuId",
                table: "Cities",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Menus_MenuId",
                table: "Countries",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_Menus_MenuId",
                table: "Currencies",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Menus_MenuId",
                table: "Departments",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_Menus_MenuId",
                table: "Designations",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitchens_Menus_MenuId",
                table: "Kitchens",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTypes_Menus_MenuId",
                table: "OrderTypes",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Riders_Menus_MenuId",
                table: "Riders",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Menus_MenuId",
                table: "Roles",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Salesmen_Menus_MenuId",
                table: "Salesmen",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Menus_MenuId",
                table: "States",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Menus_MenuId",
                table: "Suppliers",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierTypes_Menus_MenuId",
                table: "SupplierTypes",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Menus_MenuId",
                table: "Tables",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Menus_MenuId",
                table: "Tenants",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Menus_MenuId",
                table: "Users",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");
        }
    }
}
