using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class nullfoodcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCategories_RestaurantBranches_RestaurantBranchId",
                table: "FoodCategories");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantBranchId",
                table: "FoodCategories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCategories_RestaurantBranches_RestaurantBranchId",
                table: "FoodCategories",
                column: "RestaurantBranchId",
                principalTable: "RestaurantBranches",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCategories_RestaurantBranches_RestaurantBranchId",
                table: "FoodCategories");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantBranchId",
                table: "FoodCategories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCategories_RestaurantBranches_RestaurantBranchId",
                table: "FoodCategories",
                column: "RestaurantBranchId",
                principalTable: "RestaurantBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
