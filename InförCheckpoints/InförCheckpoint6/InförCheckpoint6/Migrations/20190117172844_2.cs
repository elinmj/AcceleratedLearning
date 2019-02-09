using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InförCheckpoint6.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Efternamn",
                table: "Skidåkares",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Förnamn",
                table: "Skidåkares",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SkidåkTyp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    typ = table.Column<string>(nullable: true),
                    SkidåkareId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkidåkTyp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkidåkTyp_Skidåkares_SkidåkareId",
                        column: x => x.SkidåkareId,
                        principalTable: "Skidåkares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkidåkTyp_SkidåkareId",
                table: "SkidåkTyp",
                column: "SkidåkareId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkidåkTyp");

            migrationBuilder.DropColumn(
                name: "Efternamn",
                table: "Skidåkares");

            migrationBuilder.DropColumn(
                name: "Förnamn",
                table: "Skidåkares");
        }
    }
}
