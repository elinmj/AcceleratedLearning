using Microsoft.EntityFrameworkCore.Migrations;

namespace InförCheckpoint09.Data.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdventureLocations_Adventure_AdventureId",
                table: "AdventureLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_AdventureLocations_Locations_LocationId",
                table: "AdventureLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdventureLocations",
                table: "AdventureLocations");

            migrationBuilder.RenameTable(
                name: "AdventureLocations",
                newName: "AdventureLocation");

            migrationBuilder.RenameIndex(
                name: "IX_AdventureLocations_LocationId",
                table: "AdventureLocation",
                newName: "IX_AdventureLocation_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdventureLocation",
                table: "AdventureLocation",
                columns: new[] { "AdventureId", "LocationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AdventureLocation_Adventure_AdventureId",
                table: "AdventureLocation",
                column: "AdventureId",
                principalTable: "Adventure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdventureLocation_Locations_LocationId",
                table: "AdventureLocation",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdventureLocation_Adventure_AdventureId",
                table: "AdventureLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_AdventureLocation_Locations_LocationId",
                table: "AdventureLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdventureLocation",
                table: "AdventureLocation");

            migrationBuilder.RenameTable(
                name: "AdventureLocation",
                newName: "AdventureLocations");

            migrationBuilder.RenameIndex(
                name: "IX_AdventureLocation_LocationId",
                table: "AdventureLocations",
                newName: "IX_AdventureLocations_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdventureLocations",
                table: "AdventureLocations",
                columns: new[] { "AdventureId", "LocationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AdventureLocations_Adventure_AdventureId",
                table: "AdventureLocations",
                column: "AdventureId",
                principalTable: "Adventure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdventureLocations_Locations_LocationId",
                table: "AdventureLocations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
