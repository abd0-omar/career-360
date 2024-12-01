using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDay02_CodeFIrst.Models
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Authors_authorid",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Catalog_catalogsid",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "authorid",
                table: "News",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "catalogsid",
                table: "News",
                newName: "CatalogId");

            migrationBuilder.RenameIndex(
                name: "IX_News_authorid",
                table: "News",
                newName: "IX_News_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_News_catalogsid",
                table: "News",
                newName: "IX_News_CatalogId");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "id", "brefNumber", "joinDate", "name", "password", "username" },
                values: new object[] { 1, 3, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Local), "abood", "hamada123", "hamada" });

            migrationBuilder.InsertData(
                table: "Catalog",
                columns: new[] { "id", "desc", "name" },
                values: new object[] { 1, "ok", "kataloog" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "id", "AuthorId", "CatalogId", "bref", "datetime", "desc", "title" },
                values: new object[] { 1, 1, 1, "m4 3aref", new DateTime(2024, 12, 1, 18, 24, 26, 16, DateTimeKind.Local).AddTicks(856), "eh dh", "3enwan" });

            migrationBuilder.AddForeignKey(
                name: "FK_News_Authors_AuthorId",
                table: "News",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Catalog_CatalogId",
                table: "News",
                column: "CatalogId",
                principalTable: "Catalog",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Authors_AuthorId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Catalog_CatalogId",
                table: "News");

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Catalog",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "News",
                newName: "authorid");

            migrationBuilder.RenameColumn(
                name: "CatalogId",
                table: "News",
                newName: "catalogsid");

            migrationBuilder.RenameIndex(
                name: "IX_News_AuthorId",
                table: "News",
                newName: "IX_News_authorid");

            migrationBuilder.RenameIndex(
                name: "IX_News_CatalogId",
                table: "News",
                newName: "IX_News_catalogsid");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Authors_authorid",
                table: "News",
                column: "authorid",
                principalTable: "Authors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Catalog_catalogsid",
                table: "News",
                column: "catalogsid",
                principalTable: "Catalog",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
