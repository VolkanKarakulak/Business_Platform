using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class manageofferaddcompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfficeCompanyId",
                table: "ManageOffers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ManageOffers_OfficeCompanyId",
                table: "ManageOffers",
                column: "OfficeCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManageOffers_OfficeCompanies_OfficeCompanyId",
                table: "ManageOffers",
                column: "OfficeCompanyId",
                principalTable: "OfficeCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManageOffers_OfficeCompanies_OfficeCompanyId",
                table: "ManageOffers");

            migrationBuilder.DropIndex(
                name: "IX_ManageOffers_OfficeCompanyId",
                table: "ManageOffers");

            migrationBuilder.DropColumn(
                name: "OfficeCompanyId",
                table: "ManageOffers");
        }
    }
}
