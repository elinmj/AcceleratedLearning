using Microsoft.EntityFrameworkCore.Migrations;

namespace InförCheckpoint09.Data.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Adventure",
                newName: "DiciplinId");

            migrationBuilder.CreateIndex(
                name: "IX_Adventure_DiciplinId",
                table: "Adventure",
                column: "DiciplinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adventure_Diciplin_DiciplinId",
                table: "Adventure",
                column: "DiciplinId",
                principalTable: "Diciplin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adventure_Diciplin_DiciplinId",
                table: "Adventure");

            migrationBuilder.DropIndex(
                name: "IX_Adventure_DiciplinId",
                table: "Adventure");

            migrationBuilder.RenameColumn(
                name: "DiciplinId",
                table: "Adventure",
                newName: "MyProperty");
        }
    }
}
