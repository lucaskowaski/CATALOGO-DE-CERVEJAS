using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalodo.Infra.Data.Migrations
{
    public partial class correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Beers_BeerId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_BeerId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "BeerId",
                table: "Ingredients");

            migrationBuilder.CreateTable(
                name: "BeerIngredient",
                columns: table => new
                {
                    BeerId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerIngredient", x => new { x.BeerId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_BeerIngredient_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeerIngredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeerIngredient_IngredientId",
                table: "BeerIngredient",
                column: "IngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeerIngredient");

            migrationBuilder.AddColumn<int>(
                name: "BeerId",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_BeerId",
                table: "Ingredients",
                column: "BeerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Beers_BeerId",
                table: "Ingredients",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
