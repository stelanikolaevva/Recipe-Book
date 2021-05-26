using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeBook.Migrations
{
    public partial class ChangeImageTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Recipe");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Steps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Recipe",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Recipe");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Steps",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Recipe",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
