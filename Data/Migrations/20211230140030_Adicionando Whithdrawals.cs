using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JavaTech3.Data.Migrations
{
    public partial class AdicionandoWhithdrawals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Users_Products_ProductId",
                table: "Product_Users");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Product_Users",
                newName: "Product_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Users_ProductId",
                table: "Product_Users",
                newName: "IX_Product_Users_Product_Id");

            migrationBuilder.CreateTable(
                name: "Whitdrawals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Product_id = table.Column<int>(type: "int", nullable: false),
                    ExitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity_Exit = table.Column<int>(type: "int", nullable: false),
                    _ProductId = table.Column<int>(type: "int", nullable: true),
                    _UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Whitdrawals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Whitdrawals_AspNetUsers__UserId",
                        column: x => x._UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Whitdrawals_Products__ProductId",
                        column: x => x._ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Whitdrawals__ProductId",
                table: "Whitdrawals",
                column: "_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Whitdrawals__UserId",
                table: "Whitdrawals",
                column: "_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Users_Products_Product_Id",
                table: "Product_Users",
                column: "Product_Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Users_Products_Product_Id",
                table: "Product_Users");

            migrationBuilder.DropTable(
                name: "Whitdrawals");

            migrationBuilder.RenameColumn(
                name: "Product_Id",
                table: "Product_Users",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Users_Product_Id",
                table: "Product_Users",
                newName: "IX_Product_Users_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Users_Products_ProductId",
                table: "Product_Users",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
