using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoWithOneProject2.Migrations
{
    public partial class Sweetness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sweetness",
                table: "Fruits",
                type: "varchar(10)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sweetness",
                table: "Fruits");
        }
    }
}
