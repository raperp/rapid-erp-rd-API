using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Textmodule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuModuleAudits_MenuModules_MenuModuleId",
                table: "MenuModuleAudits");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "UserAudits",
                newName: "MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "TenantAudits",
                newName: "MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "TableAudits",
                newName: "MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "SupplierTypeAudits",
                newName: "MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "SupplierAudits",
                newName: "MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "SalesmanAudits",
                newName: "MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "RoleAudits",
                newName: "MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "RiderAudits",
                newName: "MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "OrderTypeAudits",
                newName: "MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "MenuModuleAudits",
                newName: "MenuModuleId1");

            migrationBuilder.RenameIndex(
                name: "IX_MenuModuleAudits_MenuModuleId",
                table: "MenuModuleAudits",
                newName: "IX_MenuModuleAudits_MenuModuleId1");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "KitchenAudits",
                newName: "MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "DesignationAudits",
                newName: "MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "DepartmentAudits",
                newName: "MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "CountryAudits",
                newName: "MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "CityAudits",
                newName: "MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "AreaAudits",
                newName: "MenuModuleId");

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "StateAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuModuleId",
                table: "CurrencyAudits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TextModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MenuModuleId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextModules_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TextModules_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TextModuleAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextModuleId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MenuModuleId = table.Column<int>(type: "int", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextModuleAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextModuleAudits_TextModules_TextModuleId",
                        column: x => x.TextModuleId,
                        principalTable: "TextModules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TextModuleAudits_TextModuleId",
                table: "TextModuleAudits",
                column: "TextModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_TextModules_LanguageId",
                table: "TextModules",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TextModules_MenuModuleId",
                table: "TextModules",
                column: "MenuModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuModuleAudits_MenuModules_MenuModuleId1",
                table: "MenuModuleAudits",
                column: "MenuModuleId1",
                principalTable: "MenuModules",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuModuleAudits_MenuModules_MenuModuleId1",
                table: "MenuModuleAudits");

            migrationBuilder.DropTable(
                name: "TextModuleAudits");

            migrationBuilder.DropTable(
                name: "TextModules");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "StateAudits");

            migrationBuilder.DropColumn(
                name: "MenuModuleId",
                table: "CurrencyAudits");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "UserAudits",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "TenantAudits",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "TableAudits",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "SupplierTypeAudits",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "SupplierAudits",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "SalesmanAudits",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "RoleAudits",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "RiderAudits",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "OrderTypeAudits",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId1",
                table: "MenuModuleAudits",
                newName: "MenuModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuModuleAudits_MenuModuleId1",
                table: "MenuModuleAudits",
                newName: "IX_MenuModuleAudits_MenuModuleId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "KitchenAudits",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "DesignationAudits",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "DepartmentAudits",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "CountryAudits",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "CityAudits",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "MenuModuleId",
                table: "AreaAudits",
                newName: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuModuleAudits_MenuModules_MenuModuleId",
                table: "MenuModuleAudits",
                column: "MenuModuleId",
                principalTable: "MenuModules",
                principalColumn: "Id");
        }
    }
}
