using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDay02_CodeFIrst.Models
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "brefNumber",
                table: "Authors",
                newName: "bref");

            migrationBuilder.AlterColumn<string>(
                name: "bref",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "id",
                keyValue: 1,
                column: "bref",
                value: "3");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "id",
                keyValue: 1,
                column: "datetime",
                value: new DateTime(2024, 12, 1, 18, 27, 38, 121, DateTimeKind.Local).AddTicks(6022));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "bref",
                table: "Authors",
                newName: "brefNumber");

            migrationBuilder.AlterColumn<int>(
                name: "brefNumber",
                table: "Authors",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "id",
                keyValue: 1,
                column: "brefNumber",
                value: 3);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "id",
                keyValue: 1,
                column: "datetime",
                value: new DateTime(2024, 12, 1, 18, 25, 58, 885, DateTimeKind.Local).AddTicks(5453));
        }
    }
}
