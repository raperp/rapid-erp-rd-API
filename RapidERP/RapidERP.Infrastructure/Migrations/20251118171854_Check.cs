using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Check : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KitchenId",
                table: "KitchenAudits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_KitchenAudits_KitchenId",
                table: "KitchenAudits",
                column: "KitchenId");

            migrationBuilder.AddForeignKey(
                name: "FK_KitchenAudits_Kitchens_KitchenId",
                table: "KitchenAudits",
                column: "KitchenId",
                principalTable: "Kitchens",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KitchenAudits_Kitchens_KitchenId",
                table: "KitchenAudits");

            migrationBuilder.DropIndex(
                name: "IX_KitchenAudits_KitchenId",
                table: "KitchenAudits");

            migrationBuilder.DropColumn(
                name: "KitchenId",
                table: "KitchenAudits");
        }
    }
}
