using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class ManageOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfficeProdBranchProductId",
                table: "OfficeProductOffers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ManageOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OfferPrice = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OfficeProductOfferId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManageOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManageOffers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ManageOffers_OfficeProductOffers_OfficeProductOfferId",
                        column: x => x.OfficeProductOfferId,
                        principalTable: "OfficeProductOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ManageOffers_OfficeProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "OfficeProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfficeProductOffers_OfficeProdBranchProductId",
                table: "OfficeProductOffers",
                column: "OfficeProdBranchProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ManageOffers_AppUserId",
                table: "ManageOffers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ManageOffers_OfficeProductOfferId",
                table: "ManageOffers",
                column: "OfficeProductOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_ManageOffers_ProductId",
                table: "ManageOffers",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProductOffers_OfficeProdBranchProducts_OfficeProdBranchProductId",
                table: "OfficeProductOffers",
                column: "OfficeProdBranchProductId",
                principalTable: "OfficeProdBranchProducts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProductOffers_OfficeProdBranchProducts_OfficeProdBranchProductId",
                table: "OfficeProductOffers");

            migrationBuilder.DropTable(
                name: "ManageOffers");

            migrationBuilder.DropIndex(
                name: "IX_OfficeProductOffers_OfficeProdBranchProductId",
                table: "OfficeProductOffers");

            migrationBuilder.DropColumn(
                name: "OfficeProdBranchProductId",
                table: "OfficeProductOffers");
        }
    }
}
