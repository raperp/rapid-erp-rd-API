using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChkCurrCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_Languages_LanguageId",
                table: "Currencies");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "UserAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "TenantAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "TableAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "SupplierTypeAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "SupplierAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "SubmoduleAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "StatusTypeAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "StateAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "SalesmanAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "RoleAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "RiderAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "OrderTypeAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "MenuAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "MainModuleAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "LanguageAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "KitchenAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "ExportTypeAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "DesignationAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "DepartmentAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "CurrencyAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "CountryAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "CityAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "AreaAudits",
                newName: "LocationURL");

            migrationBuilder.RenameColumn(
                name: "GoogleMapURL",
                table: "ActionTypeAudits",
                newName: "LocationURL");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "Currencies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "CountryAudits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CurrencyId",
                table: "Countries",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Currencies_CurrencyId",
                table: "Countries",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_Languages_LanguageId",
                table: "Currencies",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Currencies_CurrencyId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_Languages_LanguageId",
                table: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CurrencyId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "CountryAudits");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Countries");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "UserAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "TenantAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "TableAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "SupplierTypeAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "SupplierAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "SubmoduleAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "StatusTypeAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "StateAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "SalesmanAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "RoleAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "RiderAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "OrderTypeAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "MenuAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "MainModuleAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "LanguageAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "KitchenAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "ExportTypeAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "DesignationAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "DepartmentAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "CurrencyAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "CountryAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "CityAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "AreaAudits",
                newName: "GoogleMapURL");

            migrationBuilder.RenameColumn(
                name: "LocationURL",
                table: "ActionTypeAudits",
                newName: "GoogleMapURL");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "Currencies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_Languages_LanguageId",
                table: "Currencies",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
