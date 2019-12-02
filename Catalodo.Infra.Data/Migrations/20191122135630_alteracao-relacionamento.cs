using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalodo.Infra.Data.Migrations
{
    public partial class alteracaorelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hop",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Malt",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Water",
                table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "BeerId",
                table: "Recipes",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BottleSize",
                table: "Recipes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "RecipeIngredient",
                columns: table => new
                {
                    IngredientId = table.Column<int>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient", x => new { x.IngredientId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_BeerId",
                table: "Recipes",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_RecipeId",
                table: "RecipeIngredient",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Beers_BeerId",
                table: "Recipes",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Beers_BeerId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "RecipeIngredient");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_BeerId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "BeerId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "BottleSize",
                table: "Recipes");

            migrationBuilder.AddColumn<double>(
                name: "Hop",
                table: "Recipes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Malt",
                table: "Recipes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Water",
                table: "Recipes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
