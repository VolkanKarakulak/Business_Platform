using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class OfficeProdBranchProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_RestaurantFoods_RestaurantFoodId",
                table: "Likes");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantFoodId",
                table: "Likes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OfficeProductId",
                table: "Likes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OfficeProdBranchProduct",
                table: "Likes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_OfficeProdBranchProduct",
                table: "Likes",
                column: "OfficeProdBranchProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_OfficeProdBranchProducts_OfficeProdBranchProduct",
                table: "Likes",
                column: "OfficeProdBranchProduct",
                principalTable: "OfficeProdBranchProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_RestaurantFoods_RestaurantFoodId",
                table: "Likes",
                column: "RestaurantFoodId",
                principalTable: "RestaurantFoods",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_OfficeProdBranchProducts_OfficeProdBranchProduct",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_RestaurantFoods_RestaurantFoodId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_OfficeProdBranchProduct",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "OfficeProdBranchProduct",
                table: "Likes");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantFoodId",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OfficeProductId",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_RestaurantFoods_RestaurantFoodId",
                table: "Likes",
                column: "RestaurantFoodId",
                principalTable: "RestaurantFoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
