using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateOrderType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTypes_StatusTypes_StatusTypeId",
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
                    GoogleMapUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    ActionBy = table.Column<long>(type: "bigint", nullable: false),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExportTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExportTypeId = table.Column<int>(type: "int", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: false),
                    StatusTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTypeAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTypeAudits_ActionTypes_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalTable: "ActionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrderTypeAudits_OrderTypes_OrderTypeId",
                        column: x => x.OrderTypeId,
                        principalTable: "OrderTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrderTypeAudits_StatusTypes_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderTypeAudits_ActionTypeId",
                table: "OrderTypeAudits",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTypeAudits_OrderTypeId",
                table: "OrderTypeAudits",
                column: "OrderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTypeAudits_StatusTypeId",
                table: "OrderTypeAudits",
                column: "StatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTypes_StatusTypeId",
                table: "OrderTypes",
                column: "StatusTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderTypeAudits");

            migrationBuilder.DropTable(
                name: "OrderTypes");
        }
    }
}
