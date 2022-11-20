using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proj.Migrations
{
    public partial class Documents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DocumentModelId",
                table: "Products",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DocumentModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "text", nullable: false),
                    Provider = table.Column<Guid>(type: "uuid", nullable: false),
                    Stock = table.Column<Guid>(type: "uuid", nullable: false),
                    Sum = table.Column<double>(type: "double precision", nullable: false),
                    DateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_DocumentModelId",
                table: "Products",
                column: "DocumentModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_DocumentModels_DocumentModelId",
                table: "Products",
                column: "DocumentModelId",
                principalTable: "DocumentModels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_DocumentModels_DocumentModelId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "DocumentModels");

            migrationBuilder.DropIndex(
                name: "IX_Products_DocumentModelId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DocumentModelId",
                table: "Products");
        }
    }
}
