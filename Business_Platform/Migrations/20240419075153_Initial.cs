using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfficeProductType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "MainCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_MainCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainCompanies_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficeCompanies",
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
                    table.PrimaryKey("PK_OfficeCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficeCompanies_CompanyCategories_CompanyCategoryId",
                        column: x => x.CompanyCategoryId,
                        principalTable: "CompanyCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficeCompanies_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OfficeCompanyBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<byte>(type: "tinyint", nullable: false),
                    OfficeCompanyId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_OfficeCompanyBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficeCompanyBranches_OfficeCompanies_OfficeCompanyId",
                        column: x => x.OfficeCompanyId,
                        principalTable: "OfficeCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficeCompanyBranches_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StateId = table.Column<byte>(type: "tinyint", nullable: false),
                    OfficeCompanyId = table.Column<int>(type: "int", nullable: true),
                    OfficeCompanyBranchId = table.Column<int>(type: "int", nullable: true),
                    MainCompanyId = table.Column<int>(type: "int", nullable: true),
                    FoodCompanyId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_FoodCompanies_FoodCompanyId",
                        column: x => x.FoodCompanyId,
                        principalTable: "FoodCompanies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_MainCompanies_MainCompanyId",
                        column: x => x.MainCompanyId,
                        principalTable: "MainCompanies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_OfficeCompanies_OfficeCompanyId",
                        column: x => x.OfficeCompanyId,
                        principalTable: "OfficeCompanies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_OfficeCompanyBranches_OfficeCompanyId",
                        column: x => x.OfficeCompanyId,
                        principalTable: "OfficeCompanyBranches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficeCompBranchUser",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    OfficeCompanyBranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeCompBranchUser", x => new { x.UserId, x.OfficeCompanyBranchId });
                    table.ForeignKey(
                        name: "FK_OfficeCompBranchUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficeCompBranchUser_OfficeCompanyBranches_OfficeCompanyBranchId",
                        column: x => x.OfficeCompanyBranchId,
                        principalTable: "OfficeCompanyBranches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OfficeProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    AppUserId = table.Column<long>(type: "bigint", nullable: false),
                    StateId = table.Column<byte>(type: "tinyint", nullable: false),
                    ProductTypId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: true),
                    OfficeCompanyId = table.Column<int>(type: "int", nullable: false),
                    OfficeCompanyBranchId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficeProducts_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OfficeProducts_OfficeCompanies_OfficeCompanyId",
                        column: x => x.OfficeCompanyId,
                        principalTable: "OfficeCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OfficeProducts_OfficeCompanyBranches_OfficeCompanyBranchId",
                        column: x => x.OfficeCompanyBranchId,
                        principalTable: "OfficeCompanyBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OfficeProducts_OfficeProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "OfficeProductType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfficeProducts_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id");
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
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_OfficeProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "OfficeProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficeProdBranchProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OfficeProductId = table.Column<int>(type: "int", nullable: false),
                    OfficeCompanyBranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeProdBranchProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficeProdBranchProducts_OfficeCompanyBranches_OfficeCompanyBranchId",
                        column: x => x.OfficeCompanyBranchId,
                        principalTable: "OfficeCompanyBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficeProdBranchProducts_OfficeProducts_OfficeProductId",
                        column: x => x.OfficeProductId,
                        principalTable: "OfficeProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficeProductComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    CommmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfficeProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeProductComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficeProductComment_OfficeProducts_OfficeProductId",
                        column: x => x.OfficeProductId,
                        principalTable: "OfficeProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficeStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeProductId = table.Column<int>(type: "int", nullable: false),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficeStocks_OfficeProducts_OfficeProductId",
                        column: x => x.OfficeProductId,
                        principalTable: "OfficeProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "BranchProductComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    CommmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfficeProdBranchProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchProductComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchProductComment_OfficeProdBranchProducts_OfficeProdBranchProductId",
                        column: x => x.OfficeProdBranchProductId,
                        principalTable: "OfficeProdBranchProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficeProductOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferPrice = table.Column<double>(type: "float", nullable: false),
                    OfferDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    OfficeProductId = table.Column<int>(type: "int", nullable: false),
                    OfficeCompanyId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OfficeProdBranchProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeProductOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficeProductOffers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficeProductOffers_OfficeCompanies_OfficeCompanyId",
                        column: x => x.OfficeCompanyId,
                        principalTable: "OfficeCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficeProductOffers_OfficeProdBranchProducts_OfficeProdBranchProductId",
                        column: x => x.OfficeProdBranchProductId,
                        principalTable: "OfficeProdBranchProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfficeProductOffers_OfficeProducts_OfficeProductId",
                        column: x => x.OfficeProductId,
                        principalTable: "OfficeProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FoodCompanyId",
                table: "AspNetUsers",
                column: "FoodCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MainCompanyId",
                table: "AspNetUsers",
                column: "MainCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OfficeCompanyId",
                table: "AspNetUsers",
                column: "OfficeCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StateId",
                table: "AspNetUsers",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BranchProductComment_OfficeProdBranchProductId",
                table: "BranchProductComment",
                column: "OfficeProdBranchProductId");

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
                name: "IX_Likes_AppUserId",
                table: "Likes",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ProductId",
                table: "Likes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MainCompanies_StateId",
                table: "MainCompanies",
                column: "StateId");

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

            migrationBuilder.CreateIndex(
                name: "IX_OfficeCompanies_CompanyCategoryId",
                table: "OfficeCompanies",
                column: "CompanyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeCompanies_StateId",
                table: "OfficeCompanies",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeCompanyBranches_OfficeCompanyId",
                table: "OfficeCompanyBranches",
                column: "OfficeCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeCompanyBranches_StateId",
                table: "OfficeCompanyBranches",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeCompBranchUser_OfficeCompanyBranchId",
                table: "OfficeCompBranchUser",
                column: "OfficeCompanyBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeProdBranchProducts_OfficeCompanyBranchId",
                table: "OfficeProdBranchProducts",
                column: "OfficeCompanyBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeProdBranchProducts_OfficeProductId",
                table: "OfficeProdBranchProducts",
                column: "OfficeProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeProductComment_OfficeProductId",
                table: "OfficeProductComment",
                column: "OfficeProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeProductOffers_OfficeCompanyId",
                table: "OfficeProductOffers",
                column: "OfficeCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeProductOffers_OfficeProdBranchProductId",
                table: "OfficeProductOffers",
                column: "OfficeProdBranchProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeProductOffers_OfficeProductId",
                table: "OfficeProductOffers",
                column: "OfficeProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeProductOffers_UserId",
                table: "OfficeProductOffers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeProducts_AppUserId",
                table: "OfficeProducts",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeProducts_OfficeCompanyBranchId",
                table: "OfficeProducts",
                column: "OfficeCompanyBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeProducts_OfficeCompanyId",
                table: "OfficeProducts",
                column: "OfficeCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeProducts_ProductTypeId",
                table: "OfficeProducts",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeProducts_StateId",
                table: "OfficeProducts",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeStocks_OfficeProductId",
                table: "OfficeStocks",
                column: "OfficeProductId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BranchProductComment");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "ManageOffers");

            migrationBuilder.DropTable(
                name: "OfficeCompBranchUser");

            migrationBuilder.DropTable(
                name: "OfficeProductComment");

            migrationBuilder.DropTable(
                name: "OfficeStocks");

            migrationBuilder.DropTable(
                name: "RestaurantBranchComments");

            migrationBuilder.DropTable(
                name: "RestaurantBranchFoods");

            migrationBuilder.DropTable(
                name: "RestaurantBranchUsers");

            migrationBuilder.DropTable(
                name: "RestaurantFoods");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "OfficeProductOffers");

            migrationBuilder.DropTable(
                name: "FoodCategories");

            migrationBuilder.DropTable(
                name: "OfficeProdBranchProducts");

            migrationBuilder.DropTable(
                name: "RestaurantBranches");

            migrationBuilder.DropTable(
                name: "OfficeProducts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "OfficeProductType");

            migrationBuilder.DropTable(
                name: "FoodCompanies");

            migrationBuilder.DropTable(
                name: "MainCompanies");

            migrationBuilder.DropTable(
                name: "OfficeCompanyBranches");

            migrationBuilder.DropTable(
                name: "OfficeCompanies");

            migrationBuilder.DropTable(
                name: "CompanyCategories");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
