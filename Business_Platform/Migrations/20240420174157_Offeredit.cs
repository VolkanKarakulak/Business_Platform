using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class Offeredit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProductOffers_OfficeProdBranchProducts_OfficeProdBranchProductId",
                table: "OfficeProductOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProductOffers_OfficeProducts_OfficeProductId",
                table: "OfficeProductOffers");

            migrationBuilder.DropIndex(
                name: "IX_OfficeProductOffers_OfficeProdBranchProductId",
                table: "OfficeProductOffers");

            migrationBuilder.DropColumn(
                name: "OfficeProdBranchProductId",
                table: "OfficeProductOffers");

            migrationBuilder.AlterColumn<int>(
                name: "OfficeProductId",
                table: "OfficeProductOffers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OfficeProductOffers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OfficeProductOffers_ProductId",
                table: "OfficeProductOffers",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProductOffers_OfficeProdBranchProducts_ProductId",
                table: "OfficeProductOffers",
                column: "ProductId",
                principalTable: "OfficeProdBranchProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProductOffers_OfficeProducts_OfficeProductId",
                table: "OfficeProductOffers",
                column: "OfficeProductId",
                principalTable: "OfficeProducts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProductOffers_OfficeProdBranchProducts_ProductId",
                table: "OfficeProductOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProductOffers_OfficeProducts_OfficeProductId",
                table: "OfficeProductOffers");

            migrationBuilder.DropIndex(
                name: "IX_OfficeProductOffers_ProductId",
                table: "OfficeProductOffers");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OfficeProductOffers");

            migrationBuilder.AlterColumn<int>(
                name: "OfficeProductId",
                table: "OfficeProductOffers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfficeProdBranchProductId",
                table: "OfficeProductOffers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OfficeProductOffers_OfficeProdBranchProductId",
                table: "OfficeProductOffers",
                column: "OfficeProdBranchProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProductOffers_OfficeProdBranchProducts_OfficeProdBranchProductId",
                table: "OfficeProductOffers",
                column: "OfficeProdBranchProductId",
                principalTable: "OfficeProdBranchProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProductOffers_OfficeProducts_OfficeProductId",
                table: "OfficeProductOffers",
                column: "OfficeProductId",
                principalTable: "OfficeProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
