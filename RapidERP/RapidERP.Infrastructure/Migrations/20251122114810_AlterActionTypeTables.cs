using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterActionTypeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "ActionTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeId",
                table: "ActionTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "ActionTypeAudits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypes_LanguageId",
                table: "ActionTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypes_StatusTypeId",
                table: "ActionTypes",
                column: "StatusTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionTypes_Languages_LanguageId",
                table: "ActionTypes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionTypes_StatusTypes_StatusTypeId",
                table: "ActionTypes",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionTypes_Languages_LanguageId",
                table: "ActionTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionTypes_StatusTypes_StatusTypeId",
                table: "ActionTypes");

            migrationBuilder.DropIndex(
                name: "IX_ActionTypes_LanguageId",
                table: "ActionTypes");

            migrationBuilder.DropIndex(
                name: "IX_ActionTypes_StatusTypeId",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ActionTypeAudits");
        }
    }
}
