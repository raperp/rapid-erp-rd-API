using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserIPWhitelistRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserIPWhitelist_StatusTypes_StatusTypeId",
                table: "UserIPWhitelist");

            migrationBuilder.DropForeignKey(
                name: "FK_UserIPWhitelistHistory_UserIPWhitelist_UserIPWhitelistId",
                table: "UserIPWhitelistHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIPWhitelist",
                table: "UserIPWhitelist");

            migrationBuilder.RenameTable(
                name: "UserIPWhitelist",
                newName: "UserIPWhitelists");

            migrationBuilder.RenameIndex(
                name: "IX_UserIPWhitelist_StatusTypeId",
                table: "UserIPWhitelists",
                newName: "IX_UserIPWhitelists_StatusTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIPWhitelists",
                table: "UserIPWhitelists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserIPWhitelistHistory_UserIPWhitelists_UserIPWhitelistId",
                table: "UserIPWhitelistHistory",
                column: "UserIPWhitelistId",
                principalTable: "UserIPWhitelists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserIPWhitelists_StatusTypes_StatusTypeId",
                table: "UserIPWhitelists",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserIPWhitelistHistory_UserIPWhitelists_UserIPWhitelistId",
                table: "UserIPWhitelistHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_UserIPWhitelists_StatusTypes_StatusTypeId",
                table: "UserIPWhitelists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIPWhitelists",
                table: "UserIPWhitelists");

            migrationBuilder.RenameTable(
                name: "UserIPWhitelists",
                newName: "UserIPWhitelist");

            migrationBuilder.RenameIndex(
                name: "IX_UserIPWhitelists_StatusTypeId",
                table: "UserIPWhitelist",
                newName: "IX_UserIPWhitelist_StatusTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIPWhitelist",
                table: "UserIPWhitelist",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserIPWhitelist_StatusTypes_StatusTypeId",
                table: "UserIPWhitelist",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserIPWhitelistHistory_UserIPWhitelist_UserIPWhitelistId",
                table: "UserIPWhitelistHistory",
                column: "UserIPWhitelistId",
                principalTable: "UserIPWhitelist",
                principalColumn: "Id");
        }
    }
}
