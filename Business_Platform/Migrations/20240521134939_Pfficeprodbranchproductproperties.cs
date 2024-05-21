using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class Pfficeprodbranchproductproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "OfficeProdBranchProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OfficeProdBranchProducts",
                type: "nvarchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "OfficeProdBranchProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "OfficeProdBranchProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId",
                table: "OfficeProdBranchProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "StateId",
                table: "OfficeProdBranchProducts",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_OfficeProdBranchProducts_ProductTypeId",
                table: "OfficeProdBranchProducts",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeProdBranchProducts_StateId",
                table: "OfficeProdBranchProducts",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProdBranchProducts_OfficeProductType_ProductTypeId",
                table: "OfficeProdBranchProducts",
                column: "ProductTypeId",
                principalTable: "OfficeProductType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProdBranchProducts_States_StateId",
                table: "OfficeProdBranchProducts",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProdBranchProducts_OfficeProductType_ProductTypeId",
                table: "OfficeProdBranchProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProdBranchProducts_States_StateId",
                table: "OfficeProdBranchProducts");

            migrationBuilder.DropIndex(
                name: "IX_OfficeProdBranchProducts_ProductTypeId",
                table: "OfficeProdBranchProducts");

            migrationBuilder.DropIndex(
                name: "IX_OfficeProdBranchProducts_StateId",
                table: "OfficeProdBranchProducts");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "OfficeProdBranchProducts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OfficeProdBranchProducts");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "OfficeProdBranchProducts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OfficeProdBranchProducts");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                table: "OfficeProdBranchProducts");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "OfficeProdBranchProducts");
        }
    }
}
