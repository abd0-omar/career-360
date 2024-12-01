using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDay02_CodeFIrst.Models
{
    /// <inheritdoc />
    public partial class v9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Catalogs",
                keyColumn: "id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "id", "bref", "joinDate", "name", "password", "username" },
                values: new object[] { 1, "3", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Local), "abood", "hamada123", "hamada" });

            migrationBuilder.InsertData(
                table: "Catalogs",
                columns: new[] { "id", "desc", "name" },
                values: new object[] { 1, "ok", "kataloog" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "id", "AuthorId", "CatalogId", "bref", "datetime", "desc", "title" },
                values: new object[] { 1, 1, 1, "m4 3aref", new DateTime(2024, 12, 1, 18, 31, 21, 595, DateTimeKind.Local).AddTicks(268), "eh dh", "3enwan" });
        }
    }
}
