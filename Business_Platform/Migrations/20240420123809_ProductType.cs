﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_Platform.Migrations
{
    public partial class ProductType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProducts_OfficeProductType_ProductTypeId",
                table: "OfficeProducts");

            migrationBuilder.DropColumn(
                name: "ProductTypId",
                table: "OfficeProducts");

            migrationBuilder.AlterColumn<int>(
                name: "ProductTypeId",
                table: "OfficeProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProducts_OfficeProductType_ProductTypeId",
                table: "OfficeProducts",
                column: "ProductTypeId",
                principalTable: "OfficeProductType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeProducts_OfficeProductType_ProductTypeId",
                table: "OfficeProducts");

            migrationBuilder.AlterColumn<int>(
                name: "ProductTypeId",
                table: "OfficeProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductTypId",
                table: "OfficeProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeProducts_OfficeProductType_ProductTypeId",
                table: "OfficeProducts",
                column: "ProductTypeId",
                principalTable: "OfficeProductType",
                principalColumn: "Id");
        }
    }
}
