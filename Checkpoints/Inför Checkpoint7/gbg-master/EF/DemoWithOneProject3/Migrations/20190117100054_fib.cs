using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoWithOneProject3.Migrations
{
    public partial class fib : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FruitInBasket_Baskets_BasketId",
                table: "FruitInBasket");

            migrationBuilder.DropForeignKey(
                name: "FK_FruitInBasket_Fruits_FruitId",
                table: "FruitInBasket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FruitInBasket",
                table: "FruitInBasket");

            migrationBuilder.RenameTable(
                name: "FruitInBasket",
                newName: "FruitInBaskets");

            migrationBuilder.RenameIndex(
                name: "IX_FruitInBasket_BasketId",
                table: "FruitInBaskets",
                newName: "IX_FruitInBaskets_BasketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FruitInBaskets",
                table: "FruitInBaskets",
                columns: new[] { "FruitId", "BasketId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FruitInBaskets_Baskets_BasketId",
                table: "FruitInBaskets",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FruitInBaskets_Fruits_FruitId",
                table: "FruitInBaskets",
                column: "FruitId",
                principalTable: "Fruits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FruitInBaskets_Baskets_BasketId",
                table: "FruitInBaskets");

            migrationBuilder.DropForeignKey(
                name: "FK_FruitInBaskets_Fruits_FruitId",
                table: "FruitInBaskets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FruitInBaskets",
                table: "FruitInBaskets");

            migrationBuilder.RenameTable(
                name: "FruitInBaskets",
                newName: "FruitInBasket");

            migrationBuilder.RenameIndex(
                name: "IX_FruitInBaskets_BasketId",
                table: "FruitInBasket",
                newName: "IX_FruitInBasket_BasketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FruitInBasket",
                table: "FruitInBasket",
                columns: new[] { "FruitId", "BasketId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FruitInBasket_Baskets_BasketId",
                table: "FruitInBasket",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FruitInBasket_Fruits_FruitId",
                table: "FruitInBasket",
                column: "FruitId",
                principalTable: "Fruits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
