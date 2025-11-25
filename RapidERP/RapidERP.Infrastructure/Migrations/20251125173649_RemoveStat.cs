using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatusTypes_StatusTypes_StatusTypeId1",
                table: "StatusTypes");

            migrationBuilder.DropIndex(
                name: "IX_StatusTypes_StatusTypeId1",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "StatusTypeId",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "StatusTypeId1",
                table: "StatusTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_StatusTypes_StatusTypeId1",
                table: "StatusTypes",
                column: "StatusTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusTypes_StatusTypes_StatusTypeId1",
                table: "StatusTypes",
                column: "StatusTypeId1",
                principalTable: "StatusTypes",
                principalColumn: "Id");
        }
    }
}
