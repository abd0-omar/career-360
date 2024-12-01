using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDay02_CodeFIrst.Models
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "id",
                keyValue: 1,
                column: "datetime",
                value: new DateTime(2024, 12, 1, 18, 25, 58, 885, DateTimeKind.Local).AddTicks(5453));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "id",
                keyValue: 1,
                column: "datetime",
                value: new DateTime(2024, 12, 1, 18, 24, 26, 16, DateTimeKind.Local).AddTicks(856));
        }
    }
}
