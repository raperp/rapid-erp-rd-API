using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateExportTypeExportsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExportTo",
                table: "ExportTypeTrackers");

            migrationBuilder.DropColumn(
                name: "SourceURL",
                table: "ExportTypeTrackers");

            migrationBuilder.CreateTable(
                name: "ExportTypeExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExportTypeId = table.Column<int>(type: "int", nullable: false),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportTypeExports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportTypeExports_ExportTypes_ExportTypeId",
                        column: x => x.ExportTypeId,
                        principalTable: "ExportTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExportTypeExports_ExportTypeId",
                table: "ExportTypeExports",
                column: "ExportTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExportTypeExports");

            migrationBuilder.AddColumn<string>(
                name: "ExportTo",
                table: "ExportTypeTrackers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SourceURL",
                table: "ExportTypeTrackers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
