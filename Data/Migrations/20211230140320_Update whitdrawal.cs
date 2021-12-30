using Microsoft.EntityFrameworkCore.Migrations;

namespace JavaTech3.Data.Migrations
{
    public partial class Updatewhitdrawal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductUser_id",
                table: "Whitdrawals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductUser_id",
                table: "Whitdrawals");
        }
    }
}
