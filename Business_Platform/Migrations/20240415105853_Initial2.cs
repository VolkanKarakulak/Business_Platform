using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseBranchModel_BaseCompanyModel_ClothingCompanyId",
                table: "BaseBranchModel");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseCompanyModel_CompanyCategories_CompanyCategoryId",
                table: "BaseCompanyModel");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseCompanyModel_States_StateId",
                table: "BaseCompanyModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothingProductOffers_BaseCompanyModel_ClothingCompanyId",
                table: "ClothingProductOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothingProducts_BaseCompanyModel_ClothingCompanyId",
                table: "ClothingProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseCompanyModel",
                table: "BaseCompanyModel");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseCompanyModel");

            migrationBuilder.RenameTable(
                name: "BaseCompanyModel",
                newName: "ClothingCompanies");

            migrationBuilder.RenameIndex(
                name: "IX_BaseCompanyModel_StateId",
                table: "ClothingCompanies",
                newName: "IX_ClothingCompanies_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseCompanyModel_CompanyCategoryId",
                table: "ClothingCompanies",
                newName: "IX_ClothingCompanies_CompanyCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClothingCompanies",
                table: "ClothingCompanies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseBranchModel_ClothingCompanies_ClothingCompanyId",
                table: "BaseBranchModel",
                column: "ClothingCompanyId",
                principalTable: "ClothingCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClothingCompanies_CompanyCategories_CompanyCategoryId",
                table: "ClothingCompanies",
                column: "CompanyCategoryId",
                principalTable: "CompanyCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClothingCompanies_States_StateId",
                table: "ClothingCompanies",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClothingProductOffers_ClothingCompanies_ClothingCompanyId",
                table: "ClothingProductOffers",
                column: "ClothingCompanyId",
                principalTable: "ClothingCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClothingProducts_ClothingCompanies_ClothingCompanyId",
                table: "ClothingProducts",
                column: "ClothingCompanyId",
                principalTable: "ClothingCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseBranchModel_ClothingCompanies_ClothingCompanyId",
                table: "BaseBranchModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothingCompanies_CompanyCategories_CompanyCategoryId",
                table: "ClothingCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothingCompanies_States_StateId",
                table: "ClothingCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothingProductOffers_ClothingCompanies_ClothingCompanyId",
                table: "ClothingProductOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothingProducts_ClothingCompanies_ClothingCompanyId",
                table: "ClothingProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClothingCompanies",
                table: "ClothingCompanies");

            migrationBuilder.RenameTable(
                name: "ClothingCompanies",
                newName: "BaseCompanyModel");

            migrationBuilder.RenameIndex(
                name: "IX_ClothingCompanies_StateId",
                table: "BaseCompanyModel",
                newName: "IX_BaseCompanyModel_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_ClothingCompanies_CompanyCategoryId",
                table: "BaseCompanyModel",
                newName: "IX_BaseCompanyModel_CompanyCategoryId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseCompanyModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseCompanyModel",
                table: "BaseCompanyModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseBranchModel_BaseCompanyModel_ClothingCompanyId",
                table: "BaseBranchModel",
                column: "ClothingCompanyId",
                principalTable: "BaseCompanyModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseCompanyModel_CompanyCategories_CompanyCategoryId",
                table: "BaseCompanyModel",
                column: "CompanyCategoryId",
                principalTable: "CompanyCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseCompanyModel_States_StateId",
                table: "BaseCompanyModel",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClothingProductOffers_BaseCompanyModel_ClothingCompanyId",
                table: "ClothingProductOffers",
                column: "ClothingCompanyId",
                principalTable: "BaseCompanyModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClothingProducts_BaseCompanyModel_ClothingCompanyId",
                table: "ClothingProducts",
                column: "ClothingCompanyId",
                principalTable: "BaseCompanyModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
