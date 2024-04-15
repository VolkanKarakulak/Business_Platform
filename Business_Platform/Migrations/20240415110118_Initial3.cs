using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseBranchModel_AspNetUsers_UserId",
                table: "BaseBranchModel");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseBranchModel_ClothingCompanies_ClothingCompanyId",
                table: "BaseBranchModel");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseBranchModel_States_StateId",
                table: "BaseBranchModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothingCompBranchUser_BaseBranchModel_ClothingCompBranchId",
                table: "ClothingCompBranchUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothingProducts_BaseBranchModel_ClothingCompanyBranchId",
                table: "ClothingProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseBranchModel",
                table: "BaseBranchModel");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseBranchModel");

            migrationBuilder.RenameTable(
                name: "BaseBranchModel",
                newName: "ClothingCompanyBranches");

            migrationBuilder.RenameIndex(
                name: "IX_BaseBranchModel_UserId",
                table: "ClothingCompanyBranches",
                newName: "IX_ClothingCompanyBranches_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseBranchModel_StateId",
                table: "ClothingCompanyBranches",
                newName: "IX_ClothingCompanyBranches_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseBranchModel_ClothingCompanyId",
                table: "ClothingCompanyBranches",
                newName: "IX_ClothingCompanyBranches_ClothingCompanyId");

            migrationBuilder.AlterColumn<int>(
                name: "ClothingCompanyId",
                table: "ClothingCompanyBranches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClothingCompanyBranches",
                table: "ClothingCompanyBranches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClothingCompanyBranches_AspNetUsers_UserId",
                table: "ClothingCompanyBranches",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClothingCompanyBranches_ClothingCompanies_ClothingCompanyId",
                table: "ClothingCompanyBranches",
                column: "ClothingCompanyId",
                principalTable: "ClothingCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClothingCompanyBranches_States_StateId",
                table: "ClothingCompanyBranches",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClothingCompBranchUser_ClothingCompanyBranches_ClothingCompBranchId",
                table: "ClothingCompBranchUser",
                column: "ClothingCompBranchId",
                principalTable: "ClothingCompanyBranches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClothingProducts_ClothingCompanyBranches_ClothingCompanyBranchId",
                table: "ClothingProducts",
                column: "ClothingCompanyBranchId",
                principalTable: "ClothingCompanyBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClothingCompanyBranches_AspNetUsers_UserId",
                table: "ClothingCompanyBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothingCompanyBranches_ClothingCompanies_ClothingCompanyId",
                table: "ClothingCompanyBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothingCompanyBranches_States_StateId",
                table: "ClothingCompanyBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothingCompBranchUser_ClothingCompanyBranches_ClothingCompBranchId",
                table: "ClothingCompBranchUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothingProducts_ClothingCompanyBranches_ClothingCompanyBranchId",
                table: "ClothingProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClothingCompanyBranches",
                table: "ClothingCompanyBranches");

            migrationBuilder.RenameTable(
                name: "ClothingCompanyBranches",
                newName: "BaseBranchModel");

            migrationBuilder.RenameIndex(
                name: "IX_ClothingCompanyBranches_UserId",
                table: "BaseBranchModel",
                newName: "IX_BaseBranchModel_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ClothingCompanyBranches_StateId",
                table: "BaseBranchModel",
                newName: "IX_BaseBranchModel_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_ClothingCompanyBranches_ClothingCompanyId",
                table: "BaseBranchModel",
                newName: "IX_BaseBranchModel_ClothingCompanyId");

            migrationBuilder.AlterColumn<int>(
                name: "ClothingCompanyId",
                table: "BaseBranchModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseBranchModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseBranchModel",
                table: "BaseBranchModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseBranchModel_AspNetUsers_UserId",
                table: "BaseBranchModel",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseBranchModel_ClothingCompanies_ClothingCompanyId",
                table: "BaseBranchModel",
                column: "ClothingCompanyId",
                principalTable: "ClothingCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseBranchModel_States_StateId",
                table: "BaseBranchModel",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClothingCompBranchUser_BaseBranchModel_ClothingCompBranchId",
                table: "ClothingCompBranchUser",
                column: "ClothingCompBranchId",
                principalTable: "BaseBranchModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClothingProducts_BaseBranchModel_ClothingCompanyBranchId",
                table: "ClothingProducts",
                column: "ClothingCompanyBranchId",
                principalTable: "BaseBranchModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
