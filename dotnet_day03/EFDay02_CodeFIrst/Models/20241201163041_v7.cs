using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDay02_CodeFIrst.Models
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Catalog_CatalogId",
                table: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalog",
                table: "Catalog");

            migrationBuilder.RenameTable(
                name: "Catalog",
                newName: "Catalogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalogs",
                table: "Catalogs",
                column: "id");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "id",
                keyValue: 1,
                column: "datetime",
                value: new DateTime(2024, 12, 1, 18, 30, 41, 34, DateTimeKind.Local).AddTicks(9750));

            migrationBuilder.AddForeignKey(
                name: "FK_News_Catalogs_CatalogId",
                table: "News",
                column: "CatalogId",
                principalTable: "Catalogs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Catalogs_CatalogId",
                table: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalogs",
                table: "Catalogs");

            migrationBuilder.RenameTable(
                name: "Catalogs",
                newName: "Catalog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalog",
                table: "Catalog",
                column: "id");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "id",
                keyValue: 1,
                column: "datetime",
                value: new DateTime(2024, 12, 1, 18, 29, 11, 140, DateTimeKind.Local).AddTicks(3555));

            migrationBuilder.AddForeignKey(
                name: "FK_News_Catalog_CatalogId",
                table: "News",
                column: "CatalogId",
                principalTable: "Catalog",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
