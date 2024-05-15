using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class companycategoryaddappuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyCategoryId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyCategoryId",
                table: "AspNetUsers",
                column: "CompanyCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CompanyCategories_CompanyCategoryId",
                table: "AspNetUsers",
                column: "CompanyCategoryId",
                principalTable: "CompanyCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CompanyCategories_CompanyCategoryId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CompanyCategoryId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompanyCategoryId",
                table: "AspNetUsers");
        }
    }
}
