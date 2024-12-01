using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDay02_CodeFIrst.Models
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "id",
                keyValue: 1,
                column: "datetime",
                value: new DateTime(2024, 12, 1, 18, 29, 11, 140, DateTimeKind.Local).AddTicks(3555));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "id",
                keyValue: 1,
                column: "datetime",
                value: new DateTime(2024, 12, 1, 18, 27, 38, 121, DateTimeKind.Local).AddTicks(6022));
        }
    }
}
