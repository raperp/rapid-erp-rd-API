using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CountryModifiedP1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryExports_Countries_CountryId",
                table: "CountryExports");

            migrationBuilder.DropTable(
                name: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "ActionAt",
                table: "CountryExports");

            migrationBuilder.DropColumn(
                name: "ActionBy",
                table: "CountryExports");

            migrationBuilder.DropColumn(
                name: "ActionTypeId",
                table: "CountryExports");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CountryExports");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "CountryExports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "CountryCurrencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCurrencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryCurrencies_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CountryCurrencies_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryCurrencies_CountryId",
                table: "CountryCurrencies",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryCurrencies_CurrencyId",
                table: "CountryCurrencies",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryExports_Countries_CountryId",
                table: "CountryExports",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryExports_Countries_CountryId",
                table: "CountryExports");

            migrationBuilder.DropTable(
                name: "CountryCurrencies");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "CountryExports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActionAt",
                table: "CountryExports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ActionBy",
                table: "CountryExports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActionTypeId",
                table: "CountryExports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CountryExports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CountryAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    DialingCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlagURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISO2Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ISO3Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ISONumeric = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDraft = table.Column<bool>(type: "bit", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryAudits_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryAudits_CountryId",
                table: "CountryAudits",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryExports_Countries_CountryId",
                table: "CountryExports",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
