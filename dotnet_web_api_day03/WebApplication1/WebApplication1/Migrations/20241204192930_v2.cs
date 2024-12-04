using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Catalogs_Catalogid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "catalog_id",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Products",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Catalogid",
                table: "Products",
                newName: "CatalogId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Catalogid",
                table: "Products",
                newName: "IX_Products_CatalogId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Catalogs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "desc",
                table: "Catalogs",
                newName: "Desc");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Catalogs",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "CatalogId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Catalogs_CatalogId",
                table: "Products",
                column: "CatalogId",
                principalTable: "Catalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Catalogs_CatalogId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Products",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CatalogId",
                table: "Products",
                newName: "Catalogid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CatalogId",
                table: "Products",
                newName: "IX_Products_Catalogid");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Catalogs",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Desc",
                table: "Catalogs",
                newName: "desc");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Catalogs",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "Catalogid",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "catalog_id",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Catalogs_Catalogid",
                table: "Products",
                column: "Catalogid",
                principalTable: "Catalogs",
                principalColumn: "id");
        }
    }
}
