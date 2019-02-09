using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InförCheckpoint09.Data.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Adventure",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Days",
                table: "Adventure",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Adventure",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Adventure",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Adventure",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Diciplin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.TypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adventure_TypeId",
                table: "Adventure",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adventure_Type_TypeId",
                table: "Adventure",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adventure_Type_TypeId",
                table: "Adventure");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Adventure_TypeId",
                table: "Adventure");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Adventure");

            migrationBuilder.DropColumn(
                name: "Days",
                table: "Adventure");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Adventure");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Adventure");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Adventure");
        }
    }
}
