using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class likemodelupdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_CompanyCategories_CompanyCategoryId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "CompmanyCategoryId",
                table: "Likes");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyCategoryId",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_CompanyCategories_CompanyCategoryId",
                table: "Likes",
                column: "CompanyCategoryId",
                principalTable: "CompanyCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_CompanyCategories_CompanyCategoryId",
                table: "Likes");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyCategoryId",
                table: "Likes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CompmanyCategoryId",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_CompanyCategories_CompanyCategoryId",
                table: "Likes",
                column: "CompanyCategoryId",
                principalTable: "CompanyCategories",
                principalColumn: "Id");
        }
    }
}
