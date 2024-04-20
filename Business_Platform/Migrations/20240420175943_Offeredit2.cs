using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class Offeredit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProdBranchProducts_OfficeProducts_OfficeProductId",
                table: "OfficeProdBranchProducts");

            migrationBuilder.RenameColumn(
                name: "OfficeProductId",
                table: "OfficeProdBranchProducts",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OfficeProdBranchProducts_OfficeProductId",
                table: "OfficeProdBranchProducts",
                newName: "IX_OfficeProdBranchProducts_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProdBranchProducts_OfficeProducts_ProductId",
                table: "OfficeProdBranchProducts",
                column: "ProductId",
                principalTable: "OfficeProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProdBranchProducts_OfficeProducts_ProductId",
                table: "OfficeProdBranchProducts");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OfficeProdBranchProducts",
                newName: "OfficeProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OfficeProdBranchProducts_ProductId",
                table: "OfficeProdBranchProducts",
                newName: "IX_OfficeProdBranchProducts_OfficeProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProdBranchProducts_OfficeProducts_OfficeProductId",
                table: "OfficeProdBranchProducts",
                column: "OfficeProductId",
                principalTable: "OfficeProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
