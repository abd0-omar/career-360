using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDay02_CodeFIrst.Models
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "id", "bref", "joinDate", "name", "password", "username" },
                values: new object[] { 1, "3", new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abood", "hamada123", "hamada" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
