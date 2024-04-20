using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class ManageOfferEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManageOffers_OfficeProducts_ProductId",
                table: "ManageOffers");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ManageOffers");

            migrationBuilder.AddForeignKey(
                name: "FK_ManageOffers_OfficeProdBranchProducts_ProductId",
                table: "ManageOffers",
                column: "ProductId",
                principalTable: "OfficeProdBranchProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManageOffers_OfficeProdBranchProducts_ProductId",
                table: "ManageOffers");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ManageOffers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ManageOffers_OfficeProducts_ProductId",
                table: "ManageOffers",
                column: "ProductId",
                principalTable: "OfficeProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
