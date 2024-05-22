using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class likemodelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_RestaurantBranchFoods_RestaurantBranchFoodId",
                table: "Likes");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantBranchFoodId",
                table: "Likes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_RestaurantBranchFoods_RestaurantBranchFoodId",
                table: "Likes",
                column: "RestaurantBranchFoodId",
                principalTable: "RestaurantBranchFoods",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_RestaurantBranchFoods_RestaurantBranchFoodId",
                table: "Likes");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantBranchFoodId",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_RestaurantBranchFoods_RestaurantBranchFoodId",
                table: "Likes",
                column: "RestaurantBranchFoodId",
                principalTable: "RestaurantBranchFoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
