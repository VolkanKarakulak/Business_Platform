using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class companycategoryadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyCategoryId",
                table: "OfficeCompanyBranches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OfficeCompanyBranches_CompanyCategoryId",
                table: "OfficeCompanyBranches",
                column: "CompanyCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeCompanyBranches_CompanyCategories_CompanyCategoryId",
                table: "OfficeCompanyBranches",
                column: "CompanyCategoryId",
                principalTable: "CompanyCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeCompanyBranches_CompanyCategories_CompanyCategoryId",
                table: "OfficeCompanyBranches");

            migrationBuilder.DropIndex(
                name: "IX_OfficeCompanyBranches_CompanyCategoryId",
                table: "OfficeCompanyBranches");

            migrationBuilder.DropColumn(
                name: "CompanyCategoryId",
                table: "OfficeCompanyBranches");
        }
    }
}
