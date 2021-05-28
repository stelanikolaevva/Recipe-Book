using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeBook.Migrations
{
    public partial class changeRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipe_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Recipe_RecipeId",
                table: "Steps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Ingredients");

            migrationBuilder.RenameTable(
                name: "Recipe",
                newName: "tblRecipe");

            migrationBuilder.RenameTable(
                name: "Ingredients",
                newName: "tblIngredient");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblRecipe",
                table: "tblRecipe",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblIngredient",
                table: "tblIngredient",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "tblRecipeIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipesId = table.Column<int>(type: "int", nullable: false),
                    IngredientsId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRecipeIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblRecipeIngredients_tblIngredient_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "tblIngredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblRecipeIngredients_tblRecipe_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "tblRecipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblRecipeIngredients_IngredientsId",
                table: "tblRecipeIngredients",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRecipeIngredients_RecipesId",
                table: "tblRecipeIngredients",
                column: "RecipesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_tblRecipe_RecipeId",
                table: "Steps",
                column: "RecipeId",
                principalTable: "tblRecipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Steps_tblRecipe_RecipeId",
                table: "Steps");

            migrationBuilder.DropTable(
                name: "tblRecipeIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblRecipe",
                table: "tblRecipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblIngredient",
                table: "tblIngredient");

            migrationBuilder.RenameTable(
                name: "tblRecipe",
                newName: "Recipe");

            migrationBuilder.RenameTable(
                name: "tblIngredient",
                newName: "Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipe_RecipeId",
                table: "Ingredients",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Recipe_RecipeId",
                table: "Steps",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
