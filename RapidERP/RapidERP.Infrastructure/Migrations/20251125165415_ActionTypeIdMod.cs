using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ActionTypeIdMod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionTypeAudits_ActionTypes_ActionTypeId1",
                table: "ActionTypeAudits");

            migrationBuilder.RenameColumn(
                name: "ActionTypeId1",
                table: "ActionTypeAudits",
                newName: "ActionTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ActionTypeAudits_ActionTypeId1",
                table: "ActionTypeAudits",
                newName: "IX_ActionTypeAudits_ActionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionTypeAudits_ActionTypes_ActionTypeId",
                table: "ActionTypeAudits",
                column: "ActionTypeId",
                principalTable: "ActionTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionTypeAudits_ActionTypes_ActionTypeId",
                table: "ActionTypeAudits");

            migrationBuilder.RenameColumn(
                name: "ActionTypeId",
                table: "ActionTypeAudits",
                newName: "ActionTypeId1");

            migrationBuilder.RenameIndex(
                name: "IX_ActionTypeAudits_ActionTypeId",
                table: "ActionTypeAudits",
                newName: "IX_ActionTypeAudits_ActionTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionTypeAudits_ActionTypes_ActionTypeId1",
                table: "ActionTypeAudits",
                column: "ActionTypeId1",
                principalTable: "ActionTypes",
                principalColumn: "Id");
        }
    }
}
