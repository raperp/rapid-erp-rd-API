using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                name: "ActionTypeAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTypeAudits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExportTypeAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportTypeAudits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusTypeAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTypeAudits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    StatusTypeId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreaAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaAudits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CityAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityAudits_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    ISONumeric = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    DialCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    ISO2Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ISO3Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    FlagURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    ISONumeric = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    DialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISO2Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ISO3Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    FlagURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryAudits_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyAudits_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentAudits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DesignationAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignationAudits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Designations_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ExportTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KitchenAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitchenId = table.Column<int>(type: "int", nullable: false),
                    PrinterId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitchenAudits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kitchens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrinterId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitchens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanguageAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    ISONumeric = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    ISO2Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ISO3Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageAudits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISONumeric = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    ISO2Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ISO3Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusTypes_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubModuleId = table.Column<int>(type: "int", nullable: true),
                    Prefix = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    IconURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MainModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    IconURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainModules_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MainModules_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MainModules_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MenuAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    SubModuleId = table.Column<int>(type: "int", nullable: true),
                    Prefix = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    IconURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuAudits_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OrderTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTypes_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrderTypes_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Roles_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Salesmen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Territory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salesmen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salesmen_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Salesmen_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Salesmen_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_States_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_States_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_States_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    PaymentTermsId = table.Column<int>(type: "int", nullable: true),
                    DueDays = table.Column<int>(type: "int", nullable: true),
                    DepositTypeId = table.Column<int>(type: "int", nullable: true),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: true),
                    DepositAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    LocalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    ContactPersonName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Suppliers_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Suppliers_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Suppliers_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SupplierTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VATNumber = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierTypes_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SupplierTypes_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SupplierTypes_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SupplierTypes_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SupplierTypes_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPersons = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tables_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tables_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contact = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenants_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tenants_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTP = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Users_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MainModuleAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainModuleId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Prefix = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    IconURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainModuleAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainModuleAudits_MainModules_MainModuleId",
                        column: x => x.MainModuleId,
                        principalTable: "MainModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Submodules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainModuleId = table.Column<int>(type: "int", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MenuId1 = table.Column<int>(type: "int", nullable: true),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submodules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submodules_MainModules_MainModuleId",
                        column: x => x.MainModuleId,
                        principalTable: "MainModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Submodules_Menus_MenuId1",
                        column: x => x.MenuId1,
                        principalTable: "Menus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Submodules_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OrderTypeAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTypeAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTypeAudits_OrderTypes_OrderTypeId",
                        column: x => x.OrderTypeId,
                        principalTable: "OrderTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RoleAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleAudits_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SalesmanAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesmanId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Territory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesmanAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesmanAudits_Salesmen_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "Salesmen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Riders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftedBy = table.Column<int>(type: "int", nullable: true),
                    DraftedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoftDeletedBy = table.Column<int>(type: "int", nullable: true),
                    SoftDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestoredBy = table.Column<int>(type: "int", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Riders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Riders_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Riders_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Riders_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Riders_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Riders_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Riders_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StateAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    MenuId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StateAudits_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SupplierAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    PaymentTermsId = table.Column<int>(type: "int", nullable: true),
                    DueDays = table.Column<int>(type: "int", nullable: true),
                    DepositTypeId = table.Column<int>(type: "int", nullable: true),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: true),
                    DepositAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    LocalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    ContactPersonName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierAudits_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SupplierTypeAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierTypeId = table.Column<int>(type: "int", nullable: false),
                    VATNumber = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierTypeAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierTypeAudits_SupplierTypes_SupplierTypeId",
                        column: x => x.SupplierTypeId,
                        principalTable: "SupplierTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TableAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    TotalPersons = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableAudits_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TenantAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantAudits_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserAudits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTP = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAudits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SubmoduleAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmoduleId = table.Column<int>(type: "int", nullable: false),
                    MainModuleId = table.Column<int>(type: "int", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmoduleAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmoduleAudits_Submodules_SubmoduleId",
                        column: x => x.SubmoduleId,
                        principalTable: "Submodules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RiderAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RiderId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<int>(type: "int", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiderAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiderAudits_Riders_RiderId",
                        column: x => x.RiderId,
                        principalTable: "Riders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypes_LanguageId",
                table: "ActionTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypes_MenuId",
                table: "ActionTypes",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypes_StatusTypeId",
                table: "ActionTypes",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaAudits_AreaId",
                table: "AreaAudits",
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
                name: "IX_Areas_MenuId",
                table: "Areas",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_StateId",
                table: "Areas",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_StatusTypeId",
                table: "Areas",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_MenuId",
                table: "Cities",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StatusTypeId",
                table: "Cities",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CityAudits_CityId",
                table: "CityAudits",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_LanguageId",
                table: "Countries",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_MenuId",
                table: "Countries",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_StatusTypeId",
                table: "Countries",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryAudits_CountryId",
                table: "CountryAudits",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_LanguageId",
                table: "Currencies",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_MenuId",
                table: "Currencies",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_StatusTypeId",
                table: "Currencies",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyAudits_CurrencyId",
                table: "CurrencyAudits",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentAudits_DepartmentId",
                table: "DepartmentAudits",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_MenuId",
                table: "Departments",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_StatusTypeId",
                table: "Departments",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignationAudits_DesignationId",
                table: "DesignationAudits",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_DepartmentId",
                table: "Designations",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_MenuId",
                table: "Designations",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_StatusTypeId",
                table: "Designations",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportTypes_MenuId",
                table: "ExportTypes",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_KitchenAudits_KitchenId",
                table: "KitchenAudits",
                column: "KitchenId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitchens_MenuId",
                table: "Kitchens",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitchens_StatusTypeId",
                table: "Kitchens",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageAudits_LanguageId",
                table: "LanguageAudits",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_MenuId",
                table: "Languages",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MainModuleAudits_MainModuleId",
                table: "MainModuleAudits",
                column: "MainModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_MainModules_LanguageId",
                table: "MainModules",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MainModules_MenuId",
                table: "MainModules",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MainModules_StatusTypeId",
                table: "MainModules",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuAudits_MenuId",
                table: "MenuAudits",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_StatusTypeId",
                table: "Menus",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTypeAudits_OrderTypeId",
                table: "OrderTypeAudits",
                column: "OrderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTypes_MenuId",
                table: "OrderTypes",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTypes_StatusTypeId",
                table: "OrderTypes",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RiderAudits_RiderId",
                table: "RiderAudits",
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
                name: "IX_Riders_MenuId",
                table: "Riders",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Riders_StateId",
                table: "Riders",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Riders_StatusTypeId",
                table: "Riders",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAudits_RoleId",
                table: "RoleAudits",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_MenuId",
                table: "Roles",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_StatusTypeId",
                table: "Roles",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesmanAudits_SalesmanId",
                table: "SalesmanAudits",
                column: "SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Salesmen_DepartmentId",
                table: "Salesmen",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Salesmen_MenuId",
                table: "Salesmen",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Salesmen_StatusTypeId",
                table: "Salesmen",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StateAudits_StateId",
                table: "StateAudits",
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
                name: "IX_States_MenuId",
                table: "States",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_States_StatusTypeId",
                table: "States",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTypes_LanguageId",
                table: "StatusTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmoduleAudits_SubmoduleId",
                table: "SubmoduleAudits",
                column: "SubmoduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Submodules_MainModuleId",
                table: "Submodules",
                column: "MainModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Submodules_MenuId1",
                table: "Submodules",
                column: "MenuId1");

            migrationBuilder.CreateIndex(
                name: "IX_Submodules_StatusTypeId",
                table: "Submodules",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierAudits_SupplierId",
                table: "SupplierAudits",
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
                name: "IX_Suppliers_MenuId",
                table: "Suppliers",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_StatusTypeId",
                table: "Suppliers",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTypeAudits_SupplierTypeId",
                table: "SupplierTypeAudits",
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
                name: "IX_SupplierTypes_MenuId",
                table: "SupplierTypes",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTypes_StatusTypeId",
                table: "SupplierTypes",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TableAudits_TableId",
                table: "TableAudits",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_MenuId",
                table: "Tables",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_StatusTypeId",
                table: "Tables",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantAudits_TenantId",
                table: "TenantAudits",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_MenuId",
                table: "Tenants",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_StatusTypeId",
                table: "Tenants",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAudits_UserId",
                table: "UserAudits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MenuId",
                table: "Users",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StatusTypeId",
                table: "Users",
                column: "StatusTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionTypes_Languages_LanguageId",
                table: "ActionTypes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionTypes_Menus_MenuId",
                table: "ActionTypes",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionTypes_StatusTypes_StatusTypeId",
                table: "ActionTypes",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AreaAudits_Areas_AreaId",
                table: "AreaAudits",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Cities_CityId",
                table: "Areas",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Countries_CountryId",
                table: "Areas",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Menus_MenuId",
                table: "Areas",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_States_StateId",
                table: "Areas",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_StatusTypes_StatusTypeId",
                table: "Areas",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Menus_MenuId",
                table: "Cities",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_StatusTypes_StatusTypeId",
                table: "Cities",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Languages_LanguageId",
                table: "Countries",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Menus_MenuId",
                table: "Countries",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_StatusTypes_StatusTypeId",
                table: "Countries",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_Languages_LanguageId",
                table: "Currencies",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_Menus_MenuId",
                table: "Currencies",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_StatusTypes_StatusTypeId",
                table: "Currencies",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentAudits_Departments_DepartmentId",
                table: "DepartmentAudits",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Menus_MenuId",
                table: "Departments",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_StatusTypes_StatusTypeId",
                table: "Departments",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DesignationAudits_Designations_DesignationId",
                table: "DesignationAudits",
                column: "DesignationId",
                principalTable: "Designations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_Menus_MenuId",
                table: "Designations",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_StatusTypes_StatusTypeId",
                table: "Designations",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ExportTypes_Menus_MenuId",
                table: "ExportTypes",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_KitchenAudits_Kitchens_KitchenId",
                table: "KitchenAudits",
                column: "KitchenId",
                principalTable: "Kitchens",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Kitchens_Menus_MenuId",
                table: "Kitchens",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Kitchens_StatusTypes_StatusTypeId",
                table: "Kitchens",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageAudits_Languages_LanguageId",
                table: "LanguageAudits",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Menus_MenuId",
                table: "Languages",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatusTypes_Languages_LanguageId",
                table: "StatusTypes");

            migrationBuilder.DropTable(
                name: "ActionTypeAudits");

            migrationBuilder.DropTable(
                name: "ActionTypes");

            migrationBuilder.DropTable(
                name: "AreaAudits");

            migrationBuilder.DropTable(
                name: "CityAudits");

            migrationBuilder.DropTable(
                name: "CountryAudits");

            migrationBuilder.DropTable(
                name: "CurrencyAudits");

            migrationBuilder.DropTable(
                name: "DepartmentAudits");

            migrationBuilder.DropTable(
                name: "DesignationAudits");

            migrationBuilder.DropTable(
                name: "ExportTypeAudits");

            migrationBuilder.DropTable(
                name: "ExportTypes");

            migrationBuilder.DropTable(
                name: "KitchenAudits");

            migrationBuilder.DropTable(
                name: "LanguageAudits");

            migrationBuilder.DropTable(
                name: "MainModuleAudits");

            migrationBuilder.DropTable(
                name: "MenuAudits");

            migrationBuilder.DropTable(
                name: "OrderTypeAudits");

            migrationBuilder.DropTable(
                name: "RiderAudits");

            migrationBuilder.DropTable(
                name: "RoleAudits");

            migrationBuilder.DropTable(
                name: "SalesmanAudits");

            migrationBuilder.DropTable(
                name: "StateAudits");

            migrationBuilder.DropTable(
                name: "StatusTypeAudits");

            migrationBuilder.DropTable(
                name: "SubmoduleAudits");

            migrationBuilder.DropTable(
                name: "SupplierAudits");

            migrationBuilder.DropTable(
                name: "SupplierTypeAudits");

            migrationBuilder.DropTable(
                name: "TableAudits");

            migrationBuilder.DropTable(
                name: "TenantAudits");

            migrationBuilder.DropTable(
                name: "UserAudits");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "Kitchens");

            migrationBuilder.DropTable(
                name: "OrderTypes");

            migrationBuilder.DropTable(
                name: "Riders");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Salesmen");

            migrationBuilder.DropTable(
                name: "Submodules");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "SupplierTypes");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "MainModules");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "StatusTypes");
        }
    }
}
