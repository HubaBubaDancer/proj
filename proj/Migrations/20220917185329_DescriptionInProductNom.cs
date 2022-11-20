using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proj.Migrations
{
    public partial class DescriptionInProductNom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductsNOMs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductsNOMs");
        }
    }
}
