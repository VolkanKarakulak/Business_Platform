using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class Clothing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClothingCompBranchProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClothingProductId = table.Column<int>(type: "int", nullable: false),
                    ClothingCompanyBranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothingCompBranchProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClothingCompBranchProduct_ClothingCompanyBranch_ClothingCompanyBranchId",
                        column: x => x.ClothingCompanyBranchId,
                        principalTable: "ClothingCompanyBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClothingCompBranchProduct_ClothingProduct_ClothingProductId",
                        column: x => x.ClothingProductId,
                        principalTable: "ClothingProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClothingCompBranchProduct_ClothingCompanyBranchId",
                table: "ClothingCompBranchProduct",
                column: "ClothingCompanyBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ClothingCompBranchProduct_ClothingProductId",
                table: "ClothingCompBranchProduct",
                column: "ClothingProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClothingCompBranchProduct");
        }
    }
}
