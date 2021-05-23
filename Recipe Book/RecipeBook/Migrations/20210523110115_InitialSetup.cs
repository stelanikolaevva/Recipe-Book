using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeBook.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_RecipeBook_RecipesBookId",
                table: "Recipe");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeBook_Recipe_RecipeId",
                table: "RecipeBook");

            migrationBuilder.DropIndex(
                name: "IX_RecipeBook_RecipeId",
                table: "RecipeBook");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_RecipesBookId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "RecipeBook");

            migrationBuilder.DropColumn(
                name: "RecipesBookId",
                table: "Recipe");

            migrationBuilder.AddColumn<int>(
                name: "RecipeManagerRef",
                table: "Recipe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_RecipeManagerRef",
                table: "Recipe",
                column: "RecipeManagerRef",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_RecipeBook_RecipeManagerRef",
                table: "Recipe",
                column: "RecipeManagerRef",
                principalTable: "RecipeBook",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_RecipeBook_RecipeManagerRef",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_RecipeManagerRef",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "RecipeManagerRef",
                table: "Recipe");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "RecipeBook",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipesBookId",
                table: "Recipe",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeBook_RecipeId",
                table: "RecipeBook",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_RecipesBookId",
                table: "Recipe",
                column: "RecipesBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_RecipeBook_RecipesBookId",
                table: "Recipe",
                column: "RecipesBookId",
                principalTable: "RecipeBook",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeBook_Recipe_RecipeId",
                table: "RecipeBook",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
