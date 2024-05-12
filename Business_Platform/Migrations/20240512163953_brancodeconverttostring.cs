using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class brancodeconverttostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeCompanyBranches_OfficeCompanies_OfficeCompanyId",
                table: "OfficeCompanyBranches");

            migrationBuilder.AlterColumn<string>(
                name: "BranchCode",
                table: "RestaurantBranches",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OfficeCompanyId",
                table: "OfficeCompanyBranches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BranchCode",
                table: "OfficeCompanyBranches",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeCompanyBranches_OfficeCompanies_OfficeCompanyId",
                table: "OfficeCompanyBranches",
                column: "OfficeCompanyId",
                principalTable: "OfficeCompanies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeCompanyBranches_OfficeCompanies_OfficeCompanyId",
                table: "OfficeCompanyBranches");

            migrationBuilder.AlterColumn<int>(
                name: "BranchCode",
                table: "RestaurantBranches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OfficeCompanyId",
                table: "OfficeCompanyBranches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BranchCode",
                table: "OfficeCompanyBranches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeCompanyBranches_OfficeCompanies_OfficeCompanyId",
                table: "OfficeCompanyBranches",
                column: "OfficeCompanyId",
                principalTable: "OfficeCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
