using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class officecompanyaddtoproductoffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCompanies_CompanyCategories_CompanyCategoryId",
                table: "FoodCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodCompanies_States_StateId",
                table: "FoodCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_ManageOffers_AspNetUsers_AppUserId",
                table: "ManageOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_ManageOffers_OfficeCompanies_OfficeCompanyId",
                table: "ManageOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_ManageOffers_OfficeCompanyBranches_OfficeCompanyBranchId",
                table: "ManageOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_ManageOffers_OfficeProdBranchProducts_ProductId",
                table: "ManageOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_ManageOffers_OfficeProductOffers_OfficeProductOfferId",
                table: "ManageOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProductOffers_OfficeCompanyBranches_OfficeCompanyBranchId",
                table: "OfficeProductOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProductOffers_OfficeProdBranchProducts_ProductId",
                table: "OfficeProductOffers");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "OfficeProductOffers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OfficeCompanyBranchId",
                table: "OfficeProductOffers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ManageOffers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OfficeProductOfferId",
                table: "ManageOffers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OfficeCompanyId",
                table: "ManageOffers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OfficeCompanyBranchId",
                table: "ManageOffers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "AppUserId",
                table: "ManageOffers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<byte>(
                name: "StateId",
                table: "FoodCompanies",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyCategoryId",
                table: "FoodCompanies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCompanies_CompanyCategories_CompanyCategoryId",
                table: "FoodCompanies",
                column: "CompanyCategoryId",
                principalTable: "CompanyCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCompanies_States_StateId",
                table: "FoodCompanies",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ManageOffers_AspNetUsers_AppUserId",
                table: "ManageOffers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ManageOffers_OfficeCompanies_OfficeCompanyId",
                table: "ManageOffers",
                column: "OfficeCompanyId",
                principalTable: "OfficeCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ManageOffers_OfficeCompanyBranches_OfficeCompanyBranchId",
                table: "ManageOffers",
                column: "OfficeCompanyBranchId",
                principalTable: "OfficeCompanyBranches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ManageOffers_OfficeProdBranchProducts_ProductId",
                table: "ManageOffers",
                column: "ProductId",
                principalTable: "OfficeProdBranchProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ManageOffers_OfficeProductOffers_OfficeProductOfferId",
                table: "ManageOffers",
                column: "OfficeProductOfferId",
                principalTable: "OfficeProductOffers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProductOffers_OfficeCompanyBranches_OfficeCompanyBranchId",
                table: "OfficeProductOffers",
                column: "OfficeCompanyBranchId",
                principalTable: "OfficeCompanyBranches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProductOffers_OfficeProdBranchProducts_ProductId",
                table: "OfficeProductOffers",
                column: "ProductId",
                principalTable: "OfficeProdBranchProducts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCompanies_CompanyCategories_CompanyCategoryId",
                table: "FoodCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodCompanies_States_StateId",
                table: "FoodCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_ManageOffers_AspNetUsers_AppUserId",
                table: "ManageOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_ManageOffers_OfficeCompanies_OfficeCompanyId",
                table: "ManageOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_ManageOffers_OfficeCompanyBranches_OfficeCompanyBranchId",
                table: "ManageOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_ManageOffers_OfficeProdBranchProducts_ProductId",
                table: "ManageOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_ManageOffers_OfficeProductOffers_OfficeProductOfferId",
                table: "ManageOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProductOffers_OfficeCompanyBranches_OfficeCompanyBranchId",
                table: "OfficeProductOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProductOffers_OfficeProdBranchProducts_ProductId",
                table: "OfficeProductOffers");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "OfficeProductOffers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OfficeCompanyBranchId",
                table: "OfficeProductOffers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ManageOffers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OfficeProductOfferId",
                table: "ManageOffers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OfficeCompanyId",
                table: "ManageOffers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OfficeCompanyBranchId",
                table: "ManageOffers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AppUserId",
                table: "ManageOffers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "StateId",
                table: "FoodCompanies",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyCategoryId",
                table: "FoodCompanies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCompanies_CompanyCategories_CompanyCategoryId",
                table: "FoodCompanies",
                column: "CompanyCategoryId",
                principalTable: "CompanyCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCompanies_States_StateId",
                table: "FoodCompanies",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ManageOffers_AspNetUsers_AppUserId",
                table: "ManageOffers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ManageOffers_OfficeCompanies_OfficeCompanyId",
                table: "ManageOffers",
                column: "OfficeCompanyId",
                principalTable: "OfficeCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ManageOffers_OfficeCompanyBranches_OfficeCompanyBranchId",
                table: "ManageOffers",
                column: "OfficeCompanyBranchId",
                principalTable: "OfficeCompanyBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ManageOffers_OfficeProdBranchProducts_ProductId",
                table: "ManageOffers",
                column: "ProductId",
                principalTable: "OfficeProdBranchProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ManageOffers_OfficeProductOffers_OfficeProductOfferId",
                table: "ManageOffers",
                column: "OfficeProductOfferId",
                principalTable: "OfficeProductOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProductOffers_OfficeCompanyBranches_OfficeCompanyBranchId",
                table: "OfficeProductOffers",
                column: "OfficeCompanyBranchId",
                principalTable: "OfficeCompanyBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProductOffers_OfficeProdBranchProducts_ProductId",
                table: "OfficeProductOffers",
                column: "ProductId",
                principalTable: "OfficeProdBranchProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
