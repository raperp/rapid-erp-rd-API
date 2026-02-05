using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLanguageId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionTypes_Languages_LanguageId",
                table: "ActionTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Languages_LanguageId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_Languages_LanguageId",
                table: "Calendars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Languages_LanguageId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_Languages_LanguageId",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Languages_LanguageId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Designations_Languages_LanguageId",
                table: "Designations");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportTypes_Languages_LanguageId",
                table: "ExportTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MainModules_Languages_LanguageId",
                table: "MainModules");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuModules_Languages_LanguageId",
                table: "MenuModules");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageModules_Languages_LanguageId",
                table: "MessageModules");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTypes_Languages_LanguageId",
                table: "OrderTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Salesmen_Languages_LanguageId",
                table: "Salesmen");

            migrationBuilder.DropForeignKey(
                name: "FK_Solutions_Languages_LanguageId",
                table: "Solutions");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Languages_LanguageId",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusTypes_Languages_LanguageId",
                table: "StatusTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Submodules_Languages_LanguageId",
                table: "Submodules");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Languages_LanguageId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_TextModules_Languages_LanguageId",
                table: "TextModules");

            migrationBuilder.DropIndex(
                name: "IX_TextModules_LanguageId",
                table: "TextModules");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_LanguageId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Submodules_LanguageId",
                table: "Submodules");

            migrationBuilder.DropIndex(
                name: "IX_StatusTypes_LanguageId",
                table: "StatusTypes");

            migrationBuilder.DropIndex(
                name: "IX_States_LanguageId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Solutions_LanguageId",
                table: "Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Salesmen_LanguageId",
                table: "Salesmen");

            migrationBuilder.DropIndex(
                name: "IX_OrderTypes_LanguageId",
                table: "OrderTypes");

            migrationBuilder.DropIndex(
                name: "IX_MessageModules_LanguageId",
                table: "MessageModules");

            migrationBuilder.DropIndex(
                name: "IX_MenuModules_LanguageId",
                table: "MenuModules");

            migrationBuilder.DropIndex(
                name: "IX_MainModules_LanguageId",
                table: "MainModules");

            migrationBuilder.DropIndex(
                name: "IX_ExportTypes_LanguageId",
                table: "ExportTypes");

            migrationBuilder.DropIndex(
                name: "IX_Designations_LanguageId",
                table: "Designations");

            migrationBuilder.DropIndex(
                name: "IX_Departments_LanguageId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_LanguageId",
                table: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Cities_LanguageId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Calendars_LanguageId",
                table: "Calendars");

            migrationBuilder.DropIndex(
                name: "IX_Areas_LanguageId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_ActionTypes_LanguageId",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "TextModules");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Submodules");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "MessageModules");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "MenuModules");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "MainModules");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ActionTypes");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "Tenants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "TextModules",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "Tenants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Submodules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "StatusTypes",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "States",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Solutions",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Salesmen",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "OrderTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "MessageModules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "MenuModules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "MainModules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "ExportTypes",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Designations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Currencies",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Calendars",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Areas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "ActionTypes",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.CreateIndex(
                name: "IX_TextModules_LanguageId",
                table: "TextModules",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_LanguageId",
                table: "Suppliers",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Submodules_LanguageId",
                table: "Submodules",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTypes_LanguageId",
                table: "StatusTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_States_LanguageId",
                table: "States",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_LanguageId",
                table: "Solutions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Salesmen_LanguageId",
                table: "Salesmen",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTypes_LanguageId",
                table: "OrderTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageModules_LanguageId",
                table: "MessageModules",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuModules_LanguageId",
                table: "MenuModules",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MainModules_LanguageId",
                table: "MainModules",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportTypes_LanguageId",
                table: "ExportTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_LanguageId",
                table: "Designations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_LanguageId",
                table: "Departments",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_LanguageId",
                table: "Currencies",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_LanguageId",
                table: "Cities",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_LanguageId",
                table: "Calendars",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_LanguageId",
                table: "Areas",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypes_LanguageId",
                table: "ActionTypes",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionTypes_Languages_LanguageId",
                table: "ActionTypes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Languages_LanguageId",
                table: "Areas",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_Languages_LanguageId",
                table: "Calendars",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Languages_LanguageId",
                table: "Cities",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_Languages_LanguageId",
                table: "Currencies",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Languages_LanguageId",
                table: "Departments",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_Languages_LanguageId",
                table: "Designations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportTypes_Languages_LanguageId",
                table: "ExportTypes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MainModules_Languages_LanguageId",
                table: "MainModules",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuModules_Languages_LanguageId",
                table: "MenuModules",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageModules_Languages_LanguageId",
                table: "MessageModules",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTypes_Languages_LanguageId",
                table: "OrderTypes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Salesmen_Languages_LanguageId",
                table: "Salesmen",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Solutions_Languages_LanguageId",
                table: "Solutions",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Languages_LanguageId",
                table: "States",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusTypes_Languages_LanguageId",
                table: "StatusTypes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Submodules_Languages_LanguageId",
                table: "Submodules",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Languages_LanguageId",
                table: "Suppliers",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TextModules_Languages_LanguageId",
                table: "TextModules",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");
        }
    }
}
