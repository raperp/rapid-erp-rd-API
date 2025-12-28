using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ISONumeric = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    DialCode = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    ISO2Code = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    ISO3Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ISONumeric = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    ISO2Code = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    ISO3Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    IconURL = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionTypes_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExportTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportTypes_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LanguageHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LanguageId = table.Column<int>(type: "integer", maxLength: 40, nullable: false),
                    ISONumeric = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    ISO2Code = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    ISO3Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    IconURL = table.Column<string>(type: "text", nullable: false),
                    Browser = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Location = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    DeviceIP = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    LocationURL = table.Column<string>(type: "text", nullable: false),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageHistory_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MainModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Prefix = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    IconURL = table.Column<string>(type: "text", nullable: false),
                    SetSerial = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainModules_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MenuModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubmoduleId = table.Column<int>(type: "integer", nullable: true),
                    IconURL = table.Column<string>(type: "text", nullable: false),
                    SetSerial = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuModules_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StatusTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusTypes_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActionTypeHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Browser = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Location = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    DeviceIP = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    LocationURL = table.Column<string>(type: "text", nullable: false),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTypeHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionTypeHistory_ActionTypes_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalTable: "ActionTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExportTypeHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Browser = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Location = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    DeviceIP = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    LocationURL = table.Column<string>(type: "text", nullable: false),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportTypeHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportTypeHistory_ExportTypes_ExportTypeId",
                        column: x => x.ExportTypeId,
                        principalTable: "ExportTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MainModuleHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MainModuleId = table.Column<int>(type: "integer", nullable: true),
                    Prefix = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    IconURL = table.Column<string>(type: "text", nullable: false),
                    SetSerial = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Browser = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    DeviceIP = table.Column<string>(type: "text", nullable: true),
                    LocationURL = table.Column<string>(type: "text", nullable: true),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainModuleHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainModuleHistory_MainModules_MainModuleId",
                        column: x => x.MainModuleId,
                        principalTable: "MainModules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Submodules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MainModuleId = table.Column<int>(type: "integer", nullable: false),
                    IconURL = table.Column<string>(type: "text", nullable: false),
                    SetSerial = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submodules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submodules_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Submodules_MainModules_MainModuleId",
                        column: x => x.MainModuleId,
                        principalTable: "MainModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuModuleHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    SubmoduleId = table.Column<int>(type: "integer", nullable: true),
                    IconURL = table.Column<string>(type: "text", nullable: false),
                    SetSerial = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Browser = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    DeviceIP = table.Column<string>(type: "text", nullable: true),
                    LocationURL = table.Column<string>(type: "text", nullable: true),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuModuleHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuModuleHistory_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TextModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextModules_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TextModules_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    StatusTypeId = table.Column<int>(type: "integer", nullable: true),
                    Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalMonth = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendars_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Calendars_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Calendars_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusTypeId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Solutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    StatusTypeId = table.Column<int>(type: "integer", nullable: true),
                    Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solutions_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Solutions_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Solutions_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StatusTypeHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusTypeId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Browser = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Location = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    DeviceIP = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    LocationURL = table.Column<string>(type: "text", nullable: false),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTypeHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusTypeHistory_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: true),
                    StateId = table.Column<int>(type: "integer", nullable: true),
                    StatusTypeId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Contact = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Mobile = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Website = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenants_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tenants_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tenants_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubmoduleHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubmoduleId = table.Column<int>(type: "integer", nullable: false),
                    MainModuleId = table.Column<int>(type: "integer", nullable: false),
                    IconURL = table.Column<string>(type: "text", nullable: false),
                    SetSerial = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Browser = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    DeviceIP = table.Column<string>(type: "text", nullable: true),
                    LocationURL = table.Column<string>(type: "text", nullable: true),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmoduleHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmoduleHistory_Submodules_SubmoduleId",
                        column: x => x.SubmoduleId,
                        principalTable: "Submodules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TextModuleId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageModules_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MessageModules_TextModules_TextModuleId",
                        column: x => x.TextModuleId,
                        principalTable: "TextModules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TextModuleHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TextModuleId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Browser = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    DeviceIP = table.Column<string>(type: "text", nullable: true),
                    LocationURL = table.Column<string>(type: "text", nullable: true),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextModuleHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextModuleHistory_TextModules_TextModuleId",
                        column: x => x.TextModuleId,
                        principalTable: "TextModules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CalendarHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CalendarId = table.Column<int>(type: "integer", nullable: true),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalMonth = table.Column<int>(type: "integer", nullable: false),
                    Browser = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Location = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    DeviceIP = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    LocationURL = table.Column<string>(type: "text", nullable: false),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarHistory_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true),
                    Browser = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Location = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    DeviceIP = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    LocationURL = table.Column<string>(type: "text", nullable: false),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleHistory_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: true),
                    StatusTypeId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    Mobile = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UserName = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Password = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    OTP = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SolutionHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SolutionId = table.Column<int>(type: "integer", nullable: true),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Browser = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Location = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    DeviceIP = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    LocationURL = table.Column<string>(type: "text", nullable: false),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolutionHistory_Solutions_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "Solutions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    StatusTypeId = table.Column<int>(type: "integer", nullable: true),
                    Code = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Currencies_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Currencies_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Currencies_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Currencies_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    StatusTypeId = table.Column<int>(type: "integer", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Departments_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Departments_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Departments_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kitchens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrinterId = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    StatusTypeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitchens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kitchens_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Kitchens_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Kitchens_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    StatusTypeId = table.Column<int>(type: "integer", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTypes_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderTypes_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderTypes_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderTypes_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TotalPersons = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    StatusTypeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tables_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tables_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tables_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TenantCalendars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    CalendarId = table.Column<int>(type: "integer", nullable: true),
                    DefaultCalendarId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantCalendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantCalendars_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TenantHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: true),
                    StateId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    CalendarId = table.Column<int>(type: "integer", nullable: true),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Contact = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Mobile = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Address = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Website = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    LicenseNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    LimitUsers = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    ERPPlan = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    IssueAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ValidityDays = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ExpiryAt = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 20, nullable: true),
                    ReminderAt = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 20, nullable: true),
                    InterfaceLanguageId = table.Column<int>(type: "integer", nullable: true),
                    DataLanguageId = table.Column<int>(type: "integer", nullable: true),
                    DefaultLanguageId = table.Column<int>(type: "integer", nullable: true),
                    DefaultCalendarId = table.Column<int>(type: "integer", nullable: true),
                    Browser = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Location = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    DeviceIP = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    LocationURL = table.Column<string>(type: "text", nullable: false),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantHistory_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TenantLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    InterfaceLanguageId = table.Column<int>(type: "integer", nullable: false),
                    DataLanguageId = table.Column<int>(type: "integer", nullable: false),
                    DefaultLanguageId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantLanguages_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TenantLicenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    LicenseNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    LimitUsers = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    ERPPlan = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    IssueAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValidityDays = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ExpiryAt = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 20, nullable: false),
                    ReminderAt = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantLicenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantLicenses_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MessageModuleHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MessageModuleId = table.Column<int>(type: "integer", nullable: true),
                    TextModuleId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Browser = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    DeviceIP = table.Column<string>(type: "text", nullable: true),
                    LocationURL = table.Column<string>(type: "text", nullable: true),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageModuleHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageModuleHistory_MessageModules_MessageModuleId",
                        column: x => x.MessageModuleId,
                        principalTable: "MessageModules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    Mobile = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UserName = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Password = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    OTP = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true),
                    Browser = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Location = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    DeviceIP = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    LocationURL = table.Column<string>(type: "text", nullable: false),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserHistory_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserIPWhitelists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusTypeId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    IPAddress = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIPWhitelists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserIPWhitelists_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserIPWhitelists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CurrencyId = table.Column<int>(type: "integer", nullable: true),
                    ISONumeric = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    DialCode = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    ISO2Code = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    ISO3Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    FlagURL = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    StatusTypeId = table.Column<int>(type: "integer", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Countries_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Countries_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Countries_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CurrencyHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    Browser = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Location = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    DeviceIP = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    LocationURL = table.Column<string>(type: "text", nullable: false),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyHistory_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Browser = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    DeviceIP = table.Column<string>(type: "text", nullable: true),
                    LocationURL = table.Column<string>(type: "text", nullable: true),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentHistory_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    StatusTypeId = table.Column<int>(type: "integer", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Designations_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Designations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Designations_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Designations_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Designations_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Salesmen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Commission = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    Territory = table.Column<string>(type: "text", nullable: true),
                    Experience = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    ManagerId = table.Column<int>(type: "integer", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    StatusTypeId = table.Column<int>(type: "integer", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salesmen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salesmen_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Salesmen_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Salesmen_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Salesmen_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Salesmen_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KitchenHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KitchenId = table.Column<int>(type: "integer", nullable: false),
                    PrinterId = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Browser = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Location = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    DeviceIP = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    LocationURL = table.Column<string>(type: "text", nullable: false),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitchenHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KitchenHistory_Kitchens_KitchenId",
                        column: x => x.KitchenId,
                        principalTable: "Kitchens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderTypeHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderTypeId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Browser = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    DeviceIP = table.Column<string>(type: "text", nullable: true),
                    LocationURL = table.Column<string>(type: "text", nullable: true),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTypeHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTypeHistory_OrderTypes_OrderTypeId",
                        column: x => x.OrderTypeId,
                        principalTable: "OrderTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableHistory",
                columns: table => new
                {
                    Browser = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Location = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    DeviceIP = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    LocationURL = table.Column<string>(type: "text", nullable: false),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TableId = table.Column<int>(type: "integer", nullable: false),
                    TotalPersons = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableHistory_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserIPWhitelistHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserIPWhitelistId = table.Column<int>(type: "integer", nullable: true),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    IPAddress = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true),
                    Browser = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Location = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    DeviceIP = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    LocationURL = table.Column<string>(type: "text", nullable: false),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIPWhitelistHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserIPWhitelistHistory_UserIPWhitelists_UserIPWhitelistId",
                        column: x => x.UserIPWhitelistId,
                        principalTable: "UserIPWhitelists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CountryHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    CurrencyId = table.Column<int>(type: "integer", nullable: true),
                    ISONumeric = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    DialCode = table.Column<string>(type: "text", nullable: true),
                    ISO2Code = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    ISO3Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    FlagURL = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Browser = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    DeviceIP = table.Column<string>(type: "text", nullable: true),
                    LocationURL = table.Column<string>(type: "text", nullable: true),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryHistory_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    StatusTypeId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    Code = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_States_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_States_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_States_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    PaymentTermsId = table.Column<int>(type: "integer", nullable: true),
                    DueDays = table.Column<int>(type: "integer", nullable: true),
                    DepositTypeId = table.Column<int>(type: "integer", nullable: true),
                    PaymentTypeId = table.Column<int>(type: "integer", nullable: true),
                    DepositAmount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    LocalAmount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    ContactPersonName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Mobile = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    StatusTypeId = table.Column<int>(type: "integer", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suppliers_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suppliers_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Suppliers_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Suppliers_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Suppliers_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SupplierTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VATNumber = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Website = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: true),
                    PostCode = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    StatusTypeId = table.Column<int>(type: "integer", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierTypes_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierTypes_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierTypes_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierTypes_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SupplierTypes_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SupplierTypes_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DesignationHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DesignationId = table.Column<int>(type: "integer", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Browser = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    DeviceIP = table.Column<string>(type: "text", nullable: true),
                    LocationURL = table.Column<string>(type: "text", nullable: true),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignationHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesignationHistory_Designations_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesmanHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SalesmanId = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Commission = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    Territory = table.Column<string>(type: "text", nullable: true),
                    Experience = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    DepartmentId = table.Column<int>(type: "integer", nullable: true),
                    ManagerId = table.Column<int>(type: "integer", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Browser = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    DeviceIP = table.Column<string>(type: "text", nullable: true),
                    LocationURL = table.Column<string>(type: "text", nullable: true),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesmanHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesmanHistory_Salesmen_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "Salesmen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    StatusTypeId = table.Column<int>(type: "integer", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cities_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cities_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cities_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cities_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StateHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StateId = table.Column<int>(type: "integer", nullable: false),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: false),
                    SourceURL = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false),
                    Browser = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Location = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    DeviceIP = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    LocationURL = table.Column<string>(type: "text", nullable: false),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StateHistory_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SupplierId = table.Column<int>(type: "integer", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: true),
                    PaymentTermsId = table.Column<int>(type: "integer", nullable: true),
                    DueDays = table.Column<int>(type: "integer", nullable: true),
                    DepositTypeId = table.Column<int>(type: "integer", nullable: true),
                    PaymentTypeId = table.Column<int>(type: "integer", nullable: true),
                    DepositAmount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    CurrencyId = table.Column<int>(type: "integer", nullable: true),
                    ExchangeRate = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    LocalAmount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    ContactPersonName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Mobile = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Browser = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    DeviceIP = table.Column<string>(type: "text", nullable: true),
                    LocationURL = table.Column<string>(type: "text", nullable: true),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierHistory_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierTypeHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SupplierTypeId = table.Column<int>(type: "integer", nullable: false),
                    VATNumber = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Website = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    CurrencyId = table.Column<int>(type: "integer", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    PostCode = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Browser = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    DeviceIP = table.Column<string>(type: "text", nullable: true),
                    LocationURL = table.Column<string>(type: "text", nullable: true),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierTypeHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierTypeHistory_SupplierTypes_SupplierTypeId",
                        column: x => x.SupplierTypeId,
                        principalTable: "SupplierTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    StatusTypeId = table.Column<int>(type: "integer", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Areas_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Areas_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Areas_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Areas_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Areas_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Areas_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CityHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: true),
                    StateId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Browser = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    DeviceIP = table.Column<string>(type: "text", nullable: true),
                    LocationURL = table.Column<string>(type: "text", nullable: true),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityHistory_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreaHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AreaId = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: true),
                    StateId = table.Column<int>(type: "integer", nullable: true),
                    CityId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Browser = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    DeviceIP = table.Column<string>(type: "text", nullable: true),
                    LocationURL = table.Column<string>(type: "text", nullable: true),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaHistory_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Riders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    MobileNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    AreaId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    StatusTypeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Riders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Riders_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Riders_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Riders_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Riders_MenuModules_MenuModuleId",
                        column: x => x.MenuModuleId,
                        principalTable: "MenuModules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Riders_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Riders_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Riders_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RiderHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RiderId = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    MobileNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: true),
                    StateId = table.Column<int>(type: "integer", nullable: true),
                    CityId = table.Column<int>(type: "integer", nullable: true),
                    AreaId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Browser = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Location = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    DeviceIP = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    LocationURL = table.Column<string>(type: "text", nullable: false),
                    DeviceName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "integer", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    MenuModuleId = table.Column<int>(type: "integer", nullable: true),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTypeId = table.Column<int>(type: "integer", nullable: true),
                    ExportTo = table.Column<string>(type: "text", nullable: true),
                    SourceURL = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiderHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiderHistory_Riders_RiderId",
                        column: x => x.RiderId,
                        principalTable: "Riders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypeHistory_ActionTypeId",
                table: "ActionTypeHistory",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypes_LanguageId",
                table: "ActionTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaHistory_AreaId",
                table: "AreaHistory",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CityId",
                table: "Areas",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CountryId",
                table: "Areas",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_LanguageId",
                table: "Areas",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_MenuModuleId",
                table: "Areas",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_StateId",
                table: "Areas",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_StatusTypeId",
                table: "Areas",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_TenantId",
                table: "Areas",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarHistory_CalendarId",
                table: "CalendarHistory",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_LanguageId",
                table: "Calendars",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_MenuModuleId",
                table: "Calendars",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_StatusTypeId",
                table: "Calendars",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_LanguageId",
                table: "Cities",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_MenuModuleId",
                table: "Cities",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StatusTypeId",
                table: "Cities",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_TenantId",
                table: "Cities",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_CityHistory_CityId",
                table: "CityHistory",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CurrencyId",
                table: "Countries",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_LanguageId",
                table: "Countries",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_MenuModuleId",
                table: "Countries",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_StatusTypeId",
                table: "Countries",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryHistory_CountryId",
                table: "CountryHistory",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_LanguageId",
                table: "Currencies",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_MenuModuleId",
                table: "Currencies",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_StatusTypeId",
                table: "Currencies",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_TenantId",
                table: "Currencies",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyHistory_CurrencyId",
                table: "CurrencyHistory",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentHistory_DepartmentId",
                table: "DepartmentHistory",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_LanguageId",
                table: "Departments",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_MenuModuleId",
                table: "Departments",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_StatusTypeId",
                table: "Departments",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_TenantId",
                table: "Departments",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignationHistory_DesignationId",
                table: "DesignationHistory",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_DepartmentId",
                table: "Designations",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_LanguageId",
                table: "Designations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_MenuModuleId",
                table: "Designations",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_StatusTypeId",
                table: "Designations",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_TenantId",
                table: "Designations",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportTypeHistory_ExportTypeId",
                table: "ExportTypeHistory",
                column: "ExportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportTypes_LanguageId",
                table: "ExportTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_KitchenHistory_KitchenId",
                table: "KitchenHistory",
                column: "KitchenId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitchens_MenuModuleId",
                table: "Kitchens",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitchens_StatusTypeId",
                table: "Kitchens",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitchens_TenantId",
                table: "Kitchens",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageHistory_LanguageId",
                table: "LanguageHistory",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MainModuleHistory_MainModuleId",
                table: "MainModuleHistory",
                column: "MainModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_MainModules_LanguageId",
                table: "MainModules",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuModuleHistory_MenuModuleId",
                table: "MenuModuleHistory",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuModules_LanguageId",
                table: "MenuModules",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageModuleHistory_MessageModuleId",
                table: "MessageModuleHistory",
                column: "MessageModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageModules_LanguageId",
                table: "MessageModules",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageModules_TextModuleId",
                table: "MessageModules",
                column: "TextModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTypeHistory_OrderTypeId",
                table: "OrderTypeHistory",
                column: "OrderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTypes_LanguageId",
                table: "OrderTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTypes_MenuModuleId",
                table: "OrderTypes",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTypes_StatusTypeId",
                table: "OrderTypes",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTypes_TenantId",
                table: "OrderTypes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_RiderHistory_RiderId",
                table: "RiderHistory",
                column: "RiderId");

            migrationBuilder.CreateIndex(
                name: "IX_Riders_AreaId",
                table: "Riders",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Riders_CityId",
                table: "Riders",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Riders_CountryId",
                table: "Riders",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Riders_MenuModuleId",
                table: "Riders",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Riders_StateId",
                table: "Riders",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Riders_StatusTypeId",
                table: "Riders",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Riders_TenantId",
                table: "Riders",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleHistory_RoleId",
                table: "RoleHistory",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_StatusTypeId",
                table: "Roles",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesmanHistory_SalesmanId",
                table: "SalesmanHistory",
                column: "SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Salesmen_DepartmentId",
                table: "Salesmen",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Salesmen_LanguageId",
                table: "Salesmen",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Salesmen_MenuModuleId",
                table: "Salesmen",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Salesmen_StatusTypeId",
                table: "Salesmen",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Salesmen_TenantId",
                table: "Salesmen",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionHistory_SolutionId",
                table: "SolutionHistory",
                column: "SolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_LanguageId",
                table: "Solutions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_MenuModuleId",
                table: "Solutions",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_StatusTypeId",
                table: "Solutions",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StateHistory_StateId",
                table: "StateHistory",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_States_LanguageId",
                table: "States",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_States_MenuModuleId",
                table: "States",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_States_StatusTypeId",
                table: "States",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTypeHistory_StatusTypeId",
                table: "StatusTypeHistory",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTypes_LanguageId",
                table: "StatusTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmoduleHistory_SubmoduleId",
                table: "SubmoduleHistory",
                column: "SubmoduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Submodules_LanguageId",
                table: "Submodules",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Submodules_MainModuleId",
                table: "Submodules",
                column: "MainModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierHistory_SupplierId",
                table: "SupplierHistory",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CountryId",
                table: "Suppliers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CurrencyId",
                table: "Suppliers",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_LanguageId",
                table: "Suppliers",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_MenuModuleId",
                table: "Suppliers",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_StatusTypeId",
                table: "Suppliers",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_TenantId",
                table: "Suppliers",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTypeHistory_SupplierTypeId",
                table: "SupplierTypeHistory",
                column: "SupplierTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTypes_CountryId",
                table: "SupplierTypes",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTypes_CurrencyId",
                table: "SupplierTypes",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTypes_LanguageId",
                table: "SupplierTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTypes_MenuModuleId",
                table: "SupplierTypes",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTypes_StatusTypeId",
                table: "SupplierTypes",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTypes_TenantId",
                table: "SupplierTypes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_TableHistory_TableId",
                table: "TableHistory",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_MenuModuleId",
                table: "Tables",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_StatusTypeId",
                table: "Tables",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_TenantId",
                table: "Tables",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantCalendars_TenantId",
                table: "TenantCalendars",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantHistory_TenantId",
                table: "TenantHistory",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantLanguages_TenantId",
                table: "TenantLanguages",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantLicenses_TenantId",
                table: "TenantLicenses",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_LanguageId",
                table: "Tenants",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_MenuModuleId",
                table: "Tenants",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_StatusTypeId",
                table: "Tenants",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TextModuleHistory_TextModuleId",
                table: "TextModuleHistory",
                column: "TextModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_TextModules_LanguageId",
                table: "TextModules",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TextModules_MenuModuleId",
                table: "TextModules",
                column: "MenuModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistory_UserId",
                table: "UserHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIPWhitelistHistory_UserIPWhitelistId",
                table: "UserIPWhitelistHistory",
                column: "UserIPWhitelistId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIPWhitelists_StatusTypeId",
                table: "UserIPWhitelists",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIPWhitelists_UserId",
                table: "UserIPWhitelists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StatusTypeId",
                table: "Users",
                column: "StatusTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionTypeHistory");

            migrationBuilder.DropTable(
                name: "AreaHistory");

            migrationBuilder.DropTable(
                name: "CalendarHistory");

            migrationBuilder.DropTable(
                name: "CityHistory");

            migrationBuilder.DropTable(
                name: "CountryHistory");

            migrationBuilder.DropTable(
                name: "CountryTemplate");

            migrationBuilder.DropTable(
                name: "CurrencyHistory");

            migrationBuilder.DropTable(
                name: "DepartmentHistory");

            migrationBuilder.DropTable(
                name: "DesignationHistory");

            migrationBuilder.DropTable(
                name: "ExportTypeHistory");

            migrationBuilder.DropTable(
                name: "KitchenHistory");

            migrationBuilder.DropTable(
                name: "LanguageHistory");

            migrationBuilder.DropTable(
                name: "MainModuleHistory");

            migrationBuilder.DropTable(
                name: "MenuModuleHistory");

            migrationBuilder.DropTable(
                name: "MessageModuleHistory");

            migrationBuilder.DropTable(
                name: "OrderTypeHistory");

            migrationBuilder.DropTable(
                name: "RiderHistory");

            migrationBuilder.DropTable(
                name: "RoleHistory");

            migrationBuilder.DropTable(
                name: "SalesmanHistory");

            migrationBuilder.DropTable(
                name: "SolutionHistory");

            migrationBuilder.DropTable(
                name: "StateHistory");

            migrationBuilder.DropTable(
                name: "StatusTypeHistory");

            migrationBuilder.DropTable(
                name: "SubmoduleHistory");

            migrationBuilder.DropTable(
                name: "SupplierHistory");

            migrationBuilder.DropTable(
                name: "SupplierTypeHistory");

            migrationBuilder.DropTable(
                name: "TableHistory");

            migrationBuilder.DropTable(
                name: "TenantCalendars");

            migrationBuilder.DropTable(
                name: "TenantHistory");

            migrationBuilder.DropTable(
                name: "TenantLanguages");

            migrationBuilder.DropTable(
                name: "TenantLicenses");

            migrationBuilder.DropTable(
                name: "TextModuleHistory");

            migrationBuilder.DropTable(
                name: "UserHistory");

            migrationBuilder.DropTable(
                name: "UserIPWhitelistHistory");

            migrationBuilder.DropTable(
                name: "ActionTypes");

            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "ExportTypes");

            migrationBuilder.DropTable(
                name: "Kitchens");

            migrationBuilder.DropTable(
                name: "MessageModules");

            migrationBuilder.DropTable(
                name: "OrderTypes");

            migrationBuilder.DropTable(
                name: "Riders");

            migrationBuilder.DropTable(
                name: "Salesmen");

            migrationBuilder.DropTable(
                name: "Solutions");

            migrationBuilder.DropTable(
                name: "Submodules");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "SupplierTypes");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "UserIPWhitelists");

            migrationBuilder.DropTable(
                name: "TextModules");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "MainModules");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "MenuModules");

            migrationBuilder.DropTable(
                name: "StatusTypes");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
