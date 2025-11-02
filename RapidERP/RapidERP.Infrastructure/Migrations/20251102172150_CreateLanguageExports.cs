using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateLanguageExports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LanguageExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    ExportTypeId = table.Column<int>(type: "int", nullable: false),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageExports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageExports_ExportTypes_ExportTypeId",
                        column: x => x.ExportTypeId,
                        principalTable: "ExportTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageExports_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageExports_ExportTypeId",
                table: "LanguageExports",
                column: "ExportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageExports_LanguageId",
                table: "LanguageExports",
                column: "LanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageExports");
        }
    }
}
