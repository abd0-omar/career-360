using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDay02_CodeFIrst.Models
{
    /// <inheritdoc />
    public partial class v8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "id",
                keyValue: 1,
                column: "datetime",
                value: new DateTime(2024, 12, 1, 18, 31, 21, 595, DateTimeKind.Local).AddTicks(268));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "id",
                keyValue: 1,
                column: "datetime",
                value: new DateTime(2024, 12, 1, 18, 30, 41, 34, DateTimeKind.Local).AddTicks(9750));
        }
    }
}
