using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class likeuptade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyCategoryId",
                table: "RestaurantBranchFoods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyCategoryId",
                table: "OfficeProdBranchProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyCategoryId",
                table: "Likes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompmanyCategoryId",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantBranchFoods_CompanyCategoryId",
                table: "RestaurantBranchFoods",
                column: "CompanyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeProdBranchProducts_CompanyCategoryId",
                table: "OfficeProdBranchProducts",
                column: "CompanyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_CompanyCategoryId",
                table: "Likes",
                column: "CompanyCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_CompanyCategories_CompanyCategoryId",
                table: "Likes",
                column: "CompanyCategoryId",
                principalTable: "CompanyCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProdBranchProducts_CompanyCategories_CompanyCategoryId",
                table: "OfficeProdBranchProducts",
                column: "CompanyCategoryId",
                principalTable: "CompanyCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantBranchFoods_CompanyCategories_CompanyCategoryId",
                table: "RestaurantBranchFoods",
                column: "CompanyCategoryId",
                principalTable: "CompanyCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_CompanyCategories_CompanyCategoryId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProdBranchProducts_CompanyCategories_CompanyCategoryId",
                table: "OfficeProdBranchProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantBranchFoods_CompanyCategories_CompanyCategoryId",
                table: "RestaurantBranchFoods");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantBranchFoods_CompanyCategoryId",
                table: "RestaurantBranchFoods");

            migrationBuilder.DropIndex(
                name: "IX_OfficeProdBranchProducts_CompanyCategoryId",
                table: "OfficeProdBranchProducts");

            migrationBuilder.DropIndex(
                name: "IX_Likes_CompanyCategoryId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "CompanyCategoryId",
                table: "RestaurantBranchFoods");

            migrationBuilder.DropColumn(
                name: "CompanyCategoryId",
                table: "OfficeProdBranchProducts");

            migrationBuilder.DropColumn(
                name: "CompanyCategoryId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "CompmanyCategoryId",
                table: "Likes");
        }
    }
}
