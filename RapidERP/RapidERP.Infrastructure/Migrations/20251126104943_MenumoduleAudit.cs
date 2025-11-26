using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MenumoduleAudit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "MenuModuleAudits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "MenuModuleAudits");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "MenuModuleAudits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MenuModuleAudits");

            migrationBuilder.RenameColumn(
                name: "SubModuleId",
                table: "MenuModuleAudits",
                newName: "SubmoduleId");

            migrationBuilder.AlterColumn<string>(
                name: "Prefix",
                table: "MenuModuleAudits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MenuModuleAudits",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "IconURL",
                table: "MenuModuleAudits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubmoduleId",
                table: "MenuModuleAudits",
                newName: "SubModuleId");

            migrationBuilder.AlterColumn<string>(
                name: "Prefix",
                table: "MenuModuleAudits",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MenuModuleAudits",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "IconURL",
                table: "MenuModuleAudits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "MenuModuleAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "MenuModuleAudits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "MenuModuleAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MenuModuleAudits",
                type: "int",
                nullable: true);
        }
    }
}
