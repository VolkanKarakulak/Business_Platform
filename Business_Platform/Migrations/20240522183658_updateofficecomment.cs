using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class updateofficecomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProductComment_AspNetUsers_UserId",
                table: "OfficeProductComment");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProductComment_OfficeProducts_OfficeProductId",
                table: "OfficeProductComment");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "OfficeProductComment",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_OfficeProductComment_UserId",
                table: "OfficeProductComment",
                newName: "IX_OfficeProductComment_AppUserId");

            migrationBuilder.AlterColumn<int>(
                name: "OfficeProductId",
                table: "OfficeProductComment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OfficeProdBranchProductId",
                table: "OfficeProductComment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OfficeProductComment_OfficeProdBranchProductId",
                table: "OfficeProductComment",
                column: "OfficeProdBranchProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProductComment_AspNetUsers_AppUserId",
                table: "OfficeProductComment",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProductComment_OfficeProdBranchProducts_OfficeProdBranchProductId",
                table: "OfficeProductComment",
                column: "OfficeProdBranchProductId",
                principalTable: "OfficeProdBranchProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProductComment_OfficeProducts_OfficeProductId",
                table: "OfficeProductComment",
                column: "OfficeProductId",
                principalTable: "OfficeProducts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProductComment_AspNetUsers_AppUserId",
                table: "OfficeProductComment");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProductComment_OfficeProdBranchProducts_OfficeProdBranchProductId",
                table: "OfficeProductComment");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProductComment_OfficeProducts_OfficeProductId",
                table: "OfficeProductComment");

            migrationBuilder.DropIndex(
                name: "IX_OfficeProductComment_OfficeProdBranchProductId",
                table: "OfficeProductComment");

            migrationBuilder.DropColumn(
                name: "OfficeProdBranchProductId",
                table: "OfficeProductComment");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "OfficeProductComment",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OfficeProductComment_AppUserId",
                table: "OfficeProductComment",
                newName: "IX_OfficeProductComment_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "OfficeProductId",
                table: "OfficeProductComment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProductComment_AspNetUsers_UserId",
                table: "OfficeProductComment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProductComment_OfficeProducts_OfficeProductId",
                table: "OfficeProductComment",
                column: "OfficeProductId",
                principalTable: "OfficeProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
