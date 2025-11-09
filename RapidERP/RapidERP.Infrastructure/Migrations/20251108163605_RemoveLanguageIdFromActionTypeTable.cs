using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLanguageIdFromActionTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionTypes_Languages_LanguageId",
                table: "ActionTypes");

            migrationBuilder.DropIndex(
                name: "IX_ActionTypes_LanguageId",
                table: "ActionTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ActionTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "ActionTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypes_LanguageId",
                table: "ActionTypes",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionTypes_Languages_LanguageId",
                table: "ActionTypes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
