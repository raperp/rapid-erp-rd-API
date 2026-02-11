using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusTypeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserIPWhitelists");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserIPWhitelists");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TextModules");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TextModules");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SupplierTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SupplierTypes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "States");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "States");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MessageModules");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MessageModules");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MenuModules");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MenuModules");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Kitchens");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Kitchens");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ActionTypes");

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "UserIPWhitelists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "TextModules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Tables",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "SupplierTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Submodules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "StatusTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId1",
                table: "StatusTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "States",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Solutions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Salesmen",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Riders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "OrderTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "MessageModules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "MenuModules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "MainModules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Kitchens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "ExportTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Designations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Currencies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Calendars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "Areas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "ActionTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_StatusTypeId",
                table: "Users",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIPWhitelists_StatusTypeId",
                table: "UserIPWhitelists",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TextModules_StatusTypeId",
                table: "TextModules",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_StatusTypeId",
                table: "Tables",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTypes_StatusTypeId",
                table: "SupplierTypes",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_StatusTypeId",
                table: "Suppliers",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Submodules_StatusTypeId",
                table: "Submodules",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTypes_StatusTypeId1",
                table: "StatusTypes",
                column: "StatusTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_States_StatusTypeId",
                table: "States",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_StatusTypeId",
                table: "Solutions",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Salesmen_StatusTypeId",
                table: "Salesmen",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_StatusTypeId",
                table: "Roles",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Riders_StatusTypeId",
                table: "Riders",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTypes_StatusTypeId",
                table: "OrderTypes",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageModules_StatusTypeId",
                table: "MessageModules",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuModules_StatusTypeId",
                table: "MenuModules",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MainModules_StatusTypeId",
                table: "MainModules",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_StatusTypeId",
                table: "Languages",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitchens_StatusTypeId",
                table: "Kitchens",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportTypes_StatusTypeId",
                table: "ExportTypes",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_StatusTypeId",
                table: "Designations",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_StatusTypeId",
                table: "Departments",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_StatusTypeId",
                table: "Currencies",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_StatusTypeId",
                table: "Countries",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StatusTypeId",
                table: "Cities",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_StatusTypeId",
                table: "Calendars",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_StatusTypeId",
                table: "Areas",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypes_StatusTypeId",
                table: "ActionTypes",
                column: "StatusTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionTypes_StatusTypes_StatusTypeId",
                table: "ActionTypes",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_StatusTypes_StatusTypeId",
                table: "Areas",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_StatusTypes_StatusTypeId",
                table: "Calendars",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_StatusTypes_StatusTypeId",
                table: "Cities",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_StatusTypes_StatusTypeId",
                table: "Countries",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_StatusTypes_StatusTypeId",
                table: "Currencies",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_StatusTypes_StatusTypeId",
                table: "Departments",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_StatusTypes_StatusTypeId",
                table: "Designations",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportTypes_StatusTypes_StatusTypeId",
                table: "ExportTypes",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitchens_StatusTypes_StatusTypeId",
                table: "Kitchens",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_StatusTypes_StatusTypeId",
                table: "Languages",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MainModules_StatusTypes_StatusTypeId",
                table: "MainModules",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuModules_StatusTypes_StatusTypeId",
                table: "MenuModules",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageModules_StatusTypes_StatusTypeId",
                table: "MessageModules",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTypes_StatusTypes_StatusTypeId",
                table: "OrderTypes",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Riders_StatusTypes_StatusTypeId",
                table: "Riders",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_StatusTypes_StatusTypeId",
                table: "Roles",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Salesmen_StatusTypes_StatusTypeId",
                table: "Salesmen",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Solutions_StatusTypes_StatusTypeId",
                table: "Solutions",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_States_StatusTypes_StatusTypeId",
                table: "States",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusTypes_StatusTypes_StatusTypeId1",
                table: "StatusTypes",
                column: "StatusTypeId1",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Submodules_StatusTypes_StatusTypeId",
                table: "Submodules",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_StatusTypes_StatusTypeId",
                table: "Suppliers",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierTypes_StatusTypes_StatusTypeId",
                table: "SupplierTypes",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_StatusTypes_StatusTypeId",
                table: "Tables",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TextModules_StatusTypes_StatusTypeId",
                table: "TextModules",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserIPWhitelists_StatusTypes_StatusTypeId",
                table: "UserIPWhitelists",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_StatusTypes_StatusTypeId",
                table: "Users",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionTypes_StatusTypes_StatusTypeId",
                table: "ActionTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Areas_StatusTypes_StatusTypeId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_StatusTypes_StatusTypeId",
                table: "Calendars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_StatusTypes_StatusTypeId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_StatusTypes_StatusTypeId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_StatusTypes_StatusTypeId",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_StatusTypes_StatusTypeId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Designations_StatusTypes_StatusTypeId",
                table: "Designations");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportTypes_StatusTypes_StatusTypeId",
                table: "ExportTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitchens_StatusTypes_StatusTypeId",
                table: "Kitchens");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_StatusTypes_StatusTypeId",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_MainModules_StatusTypes_StatusTypeId",
                table: "MainModules");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuModules_StatusTypes_StatusTypeId",
                table: "MenuModules");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageModules_StatusTypes_StatusTypeId",
                table: "MessageModules");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTypes_StatusTypes_StatusTypeId",
                table: "OrderTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Riders_StatusTypes_StatusTypeId",
                table: "Riders");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_StatusTypes_StatusTypeId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Salesmen_StatusTypes_StatusTypeId",
                table: "Salesmen");

            migrationBuilder.DropForeignKey(
                name: "FK_Solutions_StatusTypes_StatusTypeId",
                table: "Solutions");

            migrationBuilder.DropForeignKey(
                name: "FK_States_StatusTypes_StatusTypeId",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusTypes_StatusTypes_StatusTypeId1",
                table: "StatusTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Submodules_StatusTypes_StatusTypeId",
                table: "Submodules");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_StatusTypes_StatusTypeId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierTypes_StatusTypes_StatusTypeId",
                table: "SupplierTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_StatusTypes_StatusTypeId",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_TextModules_StatusTypes_StatusTypeId",
                table: "TextModules");

            migrationBuilder.DropForeignKey(
                name: "FK_UserIPWhitelists_StatusTypes_StatusTypeId",
                table: "UserIPWhitelists");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_StatusTypes_StatusTypeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StatusTypeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserIPWhitelists_StatusTypeId",
                table: "UserIPWhitelists");

            migrationBuilder.DropIndex(
                name: "IX_TextModules_StatusTypeId",
                table: "TextModules");

            migrationBuilder.DropIndex(
                name: "IX_Tables_StatusTypeId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_SupplierTypes_StatusTypeId",
                table: "SupplierTypes");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_StatusTypeId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Submodules_StatusTypeId",
                table: "Submodules");

            migrationBuilder.DropIndex(
                name: "IX_StatusTypes_StatusTypeId1",
                table: "StatusTypes");

            migrationBuilder.DropIndex(
                name: "IX_States_StatusTypeId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Solutions_StatusTypeId",
                table: "Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Salesmen_StatusTypeId",
                table: "Salesmen");

            migrationBuilder.DropIndex(
                name: "IX_Roles_StatusTypeId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Riders_StatusTypeId",
                table: "Riders");

            migrationBuilder.DropIndex(
                name: "IX_OrderTypes_StatusTypeId",
                table: "OrderTypes");

            migrationBuilder.DropIndex(
                name: "IX_MessageModules_StatusTypeId",
                table: "MessageModules");

            migrationBuilder.DropIndex(
                name: "IX_MenuModules_StatusTypeId",
                table: "MenuModules");

            migrationBuilder.DropIndex(
                name: "IX_MainModules_StatusTypeId",
                table: "MainModules");

            migrationBuilder.DropIndex(
                name: "IX_Languages_StatusTypeId",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Kitchens_StatusTypeId",
                table: "Kitchens");

            migrationBuilder.DropIndex(
                name: "IX_ExportTypes_StatusTypeId",
                table: "ExportTypes");

            migrationBuilder.DropIndex(
                name: "IX_Designations_StatusTypeId",
                table: "Designations");

            migrationBuilder.DropIndex(
                name: "IX_Departments_StatusTypeId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_StatusTypeId",
                table: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Countries_StatusTypeId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Cities_StatusTypeId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Calendars_StatusTypeId",
                table: "Calendars");

            migrationBuilder.DropIndex(
                name: "IX_Areas_StatusTypeId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_ActionTypes_StatusTypeId",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "UserIPWhitelists");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "TextModules");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "SupplierTypes");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "StatusTypeId1",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "MessageModules");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "MenuModules");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Kitchens");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "ActionTypes");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserIPWhitelists",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserIPWhitelists",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TextModules",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TextModules",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tenants",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tenants",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tables",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tables",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SupplierTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SupplierTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Suppliers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Suppliers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Submodules",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Submodules",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "StatusTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StatusTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "States",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "States",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Solutions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Solutions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Salesmen",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Salesmen",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Roles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Roles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Riders",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Riders",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "OrderTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MessageModules",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MessageModules",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MenuModules",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MenuModules",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MainModules",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MainModules",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Languages",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Languages",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Kitchens",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Kitchens",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ExportTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExportTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Designations",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Designations",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Departments",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Departments",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Currencies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Currencies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Countries",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Countries",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cities",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cities",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Calendars",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Calendars",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Areas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Areas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ActionTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ActionTypes",
                type: "bit",
                nullable: true);
        }
    }
}
