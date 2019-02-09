using Microsoft.EntityFrameworkCore.Migrations;

namespace InförCheckpoint6.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkidåkTyp_Skidåkares_SkidåkareId",
                table: "SkidåkTyp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkidåkTyp",
                table: "SkidåkTyp");

            migrationBuilder.RenameTable(
                name: "SkidåkTyp",
                newName: "SkidåkTyps");

            migrationBuilder.RenameIndex(
                name: "IX_SkidåkTyp_SkidåkareId",
                table: "SkidåkTyps",
                newName: "IX_SkidåkTyps_SkidåkareId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkidåkTyps",
                table: "SkidåkTyps",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkidåkTyps_Skidåkares_SkidåkareId",
                table: "SkidåkTyps",
                column: "SkidåkareId",
                principalTable: "Skidåkares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkidåkTyps_Skidåkares_SkidåkareId",
                table: "SkidåkTyps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkidåkTyps",
                table: "SkidåkTyps");

            migrationBuilder.RenameTable(
                name: "SkidåkTyps",
                newName: "SkidåkTyp");

            migrationBuilder.RenameIndex(
                name: "IX_SkidåkTyps_SkidåkareId",
                table: "SkidåkTyp",
                newName: "IX_SkidåkTyp_SkidåkareId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkidåkTyp",
                table: "SkidåkTyp",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkidåkTyp_Skidåkares_SkidåkareId",
                table: "SkidåkTyp",
                column: "SkidåkareId",
                principalTable: "Skidåkares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
