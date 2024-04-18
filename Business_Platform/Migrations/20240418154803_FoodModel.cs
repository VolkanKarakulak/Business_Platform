using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class FoodModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodCompanyId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FoodCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCategoryId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EMail = table.Column<string>(type: "varchar(100)", nullable: false),
                    PostalCode = table.Column<string>(type: "char(5)", maxLength: 5, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodCompanies_CompanyCategories_CompanyCategoryId",
                        column: x => x.CompanyCategoryId,
                        principalTable: "CompanyCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodCompanies_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<byte>(type: "tinyint", nullable: false),
                    AppUserId = table.Column<long>(type: "bigint", nullable: false),
                    FoodCompanyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    PostalCode = table.Column<string>(type: "char(5)", maxLength: 5, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EMail = table.Column<string>(type: "varchar(100)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantBranches_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RestaurantBranches_FoodCompanies_FoodCompanyId",
                        column: x => x.FoodCompanyId,
                        principalTable: "FoodCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RestaurantBranches_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FoodCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StateId = table.Column<byte>(type: "tinyint", nullable: false),
                    RestaurantBranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodCategories_RestaurantBranches_RestaurantBranchId",
                        column: x => x.RestaurantBranchId,
                        principalTable: "RestaurantBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodCategories_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantBranchComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    CommmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RestaurantBranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantBranchComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantBranchComments_RestaurantBranches_RestaurantBranchId",
                        column: x => x.RestaurantBranchId,
                        principalTable: "RestaurantBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantBranchUsers",
                columns: table => new
                {
                    RestaurantBranchId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<long>(type: "bigint", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantBranchUsers", x => new { x.AppUserId, x.RestaurantBranchId });
                    table.ForeignKey(
                        name: "FK_RestaurantBranchUsers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantBranchUsers_RestaurantBranches_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "RestaurantBranches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RestaurantBranchFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<byte>(type: "tinyint", nullable: false),
                    RestaurantBranchId = table.Column<int>(type: "int", nullable: false),
                    FoodCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantBranchFoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantBranchFoods_FoodCategories_FoodCategoryId",
                        column: x => x.FoodCategoryId,
                        principalTable: "FoodCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RestaurantBranchFoods_RestaurantBranches_RestaurantBranchId",
                        column: x => x.RestaurantBranchId,
                        principalTable: "RestaurantBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RestaurantBranchFoods_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<byte>(type: "tinyint", nullable: false),
                    FoodCategoryId = table.Column<int>(type: "int", nullable: false),
                    FoodCompanyId = table.Column<int>(type: "int", nullable: true),
                    RestaurantBranchId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantFoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantFoods_FoodCategories_FoodCategoryId",
                        column: x => x.FoodCategoryId,
                        principalTable: "FoodCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantFoods_FoodCompanies_FoodCompanyId",
                        column: x => x.FoodCompanyId,
                        principalTable: "FoodCompanies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantFoods_RestaurantBranches_RestaurantBranchId",
                        column: x => x.RestaurantBranchId,
                        principalTable: "RestaurantBranches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantFoods_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FoodCompanyId",
                table: "AspNetUsers",
                column: "FoodCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCategories_RestaurantBranchId",
                table: "FoodCategories",
                column: "RestaurantBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCategories_StateId",
                table: "FoodCategories",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCompanies_CompanyCategoryId",
                table: "FoodCompanies",
                column: "CompanyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCompanies_StateId",
                table: "FoodCompanies",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantBranchComments_RestaurantBranchId",
                table: "RestaurantBranchComments",
                column: "RestaurantBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantBranches_AppUserId",
                table: "RestaurantBranches",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantBranches_FoodCompanyId",
                table: "RestaurantBranches",
                column: "FoodCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantBranches_StateId",
                table: "RestaurantBranches",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantBranchFoods_FoodCategoryId",
                table: "RestaurantBranchFoods",
                column: "FoodCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantBranchFoods_RestaurantBranchId",
                table: "RestaurantBranchFoods",
                column: "RestaurantBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantBranchFoods_StateId",
                table: "RestaurantBranchFoods",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantBranchUsers_RestaurantId",
                table: "RestaurantBranchUsers",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoods_FoodCategoryId",
                table: "RestaurantFoods",
                column: "FoodCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoods_FoodCompanyId",
                table: "RestaurantFoods",
                column: "FoodCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoods_RestaurantBranchId",
                table: "RestaurantFoods",
                column: "RestaurantBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoods_StateId",
                table: "RestaurantFoods",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_FoodCompanies_FoodCompanyId",
                table: "AspNetUsers",
                column: "FoodCompanyId",
                principalTable: "FoodCompanies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_FoodCompanies_FoodCompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "RestaurantBranchComments");

            migrationBuilder.DropTable(
                name: "RestaurantBranchFoods");

            migrationBuilder.DropTable(
                name: "RestaurantBranchUsers");

            migrationBuilder.DropTable(
                name: "RestaurantFoods");

            migrationBuilder.DropTable(
                name: "FoodCategories");

            migrationBuilder.DropTable(
                name: "RestaurantBranches");

            migrationBuilder.DropTable(
                name: "FoodCompanies");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FoodCompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FoodCompanyId",
                table: "AspNetUsers");
        }
    }
}
