using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDay02_CodeFIrst.Models
{
    /// <inheritdoc />
    public partial class v11last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Catalogs",
                columns: new[] { "id", "desc", "name" },
                values: new object[] { 1, "ok", "kataloog" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "id", "AuthorId", "CatalogId", "bref", "datetime", "desc", "title" },
                values: new object[] { 1, 1, 1, "m4 3aref", new DateTime(2005, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "eh dh", "3enwan" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Catalogs",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
