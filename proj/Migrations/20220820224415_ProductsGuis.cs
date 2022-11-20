using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proj.Migrations
{
    public partial class ProductsGuis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductsNOMs_ProductsNomId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductsNomId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductsNomId",
                table: "Products",
                newName: "ProductsNom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductsNom",
                table: "Products",
                newName: "ProductsNomId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductsNomId",
                table: "Products",
                column: "ProductsNomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductsNOMs_ProductsNomId",
                table: "Products",
                column: "ProductsNomId",
                principalTable: "ProductsNOMs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
