using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class updatemodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProdBranchProducts_OfficeProducts_OfficeProductId",
                table: "OfficeProdBranchProducts");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "OfficeProductType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "OfficeProdBranchProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OfficeProductId",
                table: "OfficeProdBranchProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "OfficeProdBranchProducts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "OfficeProdBranchProducts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "OfficeProductTypeId",
                table: "OfficeProdBranchProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProdBranchProducts_OfficeProducts_OfficeProductId",
                table: "OfficeProdBranchProducts",
                column: "OfficeProductId",
                principalTable: "OfficeProducts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProdBranchProducts_OfficeProducts_OfficeProductId",
                table: "OfficeProdBranchProducts");

            migrationBuilder.DropColumn(
                name: "OfficeProductTypeId",
                table: "OfficeProdBranchProducts");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "OfficeProductType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "OfficeProdBranchProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OfficeProductId",
                table: "OfficeProdBranchProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "OfficeProdBranchProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "OfficeProdBranchProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProdBranchProducts_OfficeProducts_OfficeProductId",
                table: "OfficeProdBranchProducts",
                column: "OfficeProductId",
                principalTable: "OfficeProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
