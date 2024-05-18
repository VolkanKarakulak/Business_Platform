using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class updateLike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodCompanyId",
                table: "Likes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfficeCompanyId",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_FoodCompanyId",
                table: "Likes",
                column: "FoodCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_OfficeCompanyId",
                table: "Likes",
                column: "OfficeCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_FoodCompanies_FoodCompanyId",
                table: "Likes",
                column: "FoodCompanyId",
                principalTable: "FoodCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_OfficeCompanies_OfficeCompanyId",
                table: "Likes",
                column: "OfficeCompanyId",
                principalTable: "OfficeCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_FoodCompanies_FoodCompanyId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_OfficeCompanies_OfficeCompanyId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_FoodCompanyId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_OfficeCompanyId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "FoodCompanyId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "OfficeCompanyId",
                table: "Likes");
        }
    }
}
