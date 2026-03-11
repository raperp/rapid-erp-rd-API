using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StatusType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatusTypes_StatusTypes_StatusTypeId1",
                table: "StatusTypes");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId1",
                table: "StatusTypes",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "StatusTypes",
                newName: "DefaultLanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_StatusTypes_StatusTypeId1",
                table: "StatusTypes",
                newName: "IX_StatusTypes_LanguageId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StatusTypes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StatusTypes",
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
                table: "StatusTypes",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StatusTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 0)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "StatusTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "StatusTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StatusTypes_Languages_LanguageId",
                table: "StatusTypes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatusTypes_Languages_LanguageId",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "StatusTypes");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "StatusTypes",
                newName: "StatusTypeId1");

            migrationBuilder.RenameColumn(
                name: "DefaultLanguageId",
                table: "StatusTypes",
                newName: "StatusTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_StatusTypes_LanguageId",
                table: "StatusTypes",
                newName: "IX_StatusTypes_StatusTypeId1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StatusTypes",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StatusTypes",
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
                table: "StatusTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StatusTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusTypes_StatusTypes_StatusTypeId1",
                table: "StatusTypes",
                column: "StatusTypeId1",
                principalTable: "StatusTypes",
                principalColumn: "Id");
        }
    }
}
