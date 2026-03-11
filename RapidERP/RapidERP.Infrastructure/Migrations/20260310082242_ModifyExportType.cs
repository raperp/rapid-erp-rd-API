using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyExportType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportTypes_StatusTypes_StatusTypeId",
                table: "ExportTypes");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "ExportTypes",
                newName: "LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_ExportTypes_StatusTypeId",
                table: "ExportTypes",
                newName: "IX_ExportTypes_LanguageId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ExportTypes",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ExportTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ExportTypes",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ExportTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 0)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DefaultLanguageId",
                table: "ExportTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "ExportTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "ExportTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExportTypes_Languages_LanguageId",
                table: "ExportTypes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportTypes_Languages_LanguageId",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "DefaultLanguageId",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "ExportTypes");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "ExportTypes");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "ExportTypes",
                newName: "StatusTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ExportTypes_LanguageId",
                table: "ExportTypes",
                newName: "IX_ExportTypes_StatusTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ExportTypes",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ExportTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ExportTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ExportTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportTypes_StatusTypes_StatusTypeId",
                table: "ExportTypes",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id");
        }
    }
}
